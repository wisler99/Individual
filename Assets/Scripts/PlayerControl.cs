using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEngine.UIElements.UxmlAttributeDescription;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] GameObject _inventory;
    [SerializeField] GameObject _AddItemExplain;
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
        Move();
        Jump();
        MouseMove();
        if (Input.GetKeyDown(KeyCode.I))
        {
            _inventory.GetComponent<Inventory>().InventoryOpen();
        }
        CheckItem();

    }
    #region 플레이어 움직임
    void MouseMove()
    {
        mouseY += Input.GetAxis("Mouse Y") * _mouseSpeed;
        mouseY = Mathf.Clamp(mouseY, -55.0f, 55.0f);
        mouseX += Input.GetAxis("Mouse X") * _mouseSpeed;
        transform.eulerAngles = new Vector3(-mouseY, mouseX, 0);
    }

    void Move()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(moveX, 0, moveZ);

        transform.Translate((new Vector3(moveX, 0, moveZ) * _charcterSpeed) * Time.deltaTime);


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
