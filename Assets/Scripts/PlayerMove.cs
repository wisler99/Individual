using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEngine.UIElements.UxmlAttributeDescription;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] GameObject _inventory;
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

    }
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

}
