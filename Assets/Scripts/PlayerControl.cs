using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEngine.UIElements.UxmlAttributeDescription;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] GameObject _inventory;
    [SerializeField] GameObject _AddItemExplain;
    [SerializeField] GameObject _cam;
    public int _mouseSpeed;
    public float _jumpForce;
    public float _charcterSpeed;

    

    Rigidbody rb;

    float mouseX = 0;
    float mouseY = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.I))
        {
            _inventory.GetComponent<Inventory>().InventoryOpen();
            rb.velocity = Vector3.zero;
        }
        if (_inventory.activeSelf == true) return;
        Move();
        Jump();
        CheckItem();

    }
    #region 플레이어 움직임

    public void SetCamera(Transform cam)
    {
        _cam = cam;
    }
    void Move()
    {
        if (_cam == null)
        {
            GameObject camera = GameObject.FindGameObjectWithTag("Camera");
            _cam = camera.transform;
        }


        Vector3 camRot = new Vector3(_cam.transform.forward.x, 0, _cam.transform.forward.z);
        transform.rotation = Quaternion.LookRotation(camRot);

        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        Vector3 v3 = (transform.forward * y + transform.right * x) * 4;
        Rigidbody rig = GetComponent<Rigidbody>();


    }

    void Jump()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
        }
    }
    #endregion

    #region 아이템 회득

    void CheckItem()
    {
        RaycastHit hit;
        Debug.DrawRay(transform.position, transform.forward, Color.red, 5f);
        if(Physics.Raycast(transform.position , transform.forward, out hit, 3))
        {
            if(hit.transform.tag == "Item")
            {
                _AddItemExplain.GetComponent<CheckItemUI>().AddItemExplain(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    //인벤토리에 넣는 함수
                    _inventory.GetComponent<Inventory>().AddItem(hit.transform.GetComponent<Item>().GetItem());
                }
            }
        }
        else
        {
            _AddItemExplain.GetComponent<CheckItemUI>().AddItemExplain(false);
        }
    }

    void AddItem()
    {

    }

    #endregion

}
