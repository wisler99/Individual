using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEngine.UIElements.UxmlAttributeDescription;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] GameObject _inventory;
    [SerializeField] GameObject _AddItemExplain;
    Transform _cam;

    public int _mouseSpeed;
    public float _jumpForce;
    public float _charcterSpeed;

    Rigidbody rb;

    float mouseX = 0;
    float mouseY = 0;

    float _hungryValue = 100;

    bool _isInventory;

    public float hungryValue
    {
        get { return _hungryValue; }
        set
        {
            _hungryValue = value;
            UIManager.Instance.HungryUpdate(_hungryValue);
        }
    }
    float _thirstValue = 100;
    public float thirstValue
    {
        get { return _thirstValue; }
        set
        {
            _thirstValue = value;
            UIManager.Instance.ThirstUpdate(_thirstValue);
        }
    }

    #region 싱글턴
    private static PlayerControl instance = null;
    private void Awake()
    {
        if (null == instance)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }

    }
    public static PlayerControl Instance
    {
        get
        {
            if (null == instance)
            {
                return null;
            }
            return instance;
        }
    }
    #endregion

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        _isInventory = false;
    }
    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.I))
        {
            if (_isInventory)
            {
                UIManager.Instance.InventoryClose();
                _isInventory = false;
            }
            else 
            {
                UIManager.Instance.InventoryOpen();
                _isInventory = true;
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (_isInventory)
            {
                UIManager.Instance.InventoryClose();
                _isInventory = false;
            }
        }
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
        Vector3 v3 = (transform.forward * y + transform.right * x) * Time.deltaTime * _charcterSpeed;
        Vector3 playerMove = transform.position;
        playerMove.x += x * Time.deltaTime * _charcterSpeed;
        playerMove.y += y * Time.deltaTime * _charcterSpeed;
        transform.position += v3;
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
                    UIManager.Instance.AddItem(hit.transform.GetComponent<Item>().GetItem());
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
