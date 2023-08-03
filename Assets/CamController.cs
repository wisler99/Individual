using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour
{
    [SerializeField] Transform _realCam;
    [SerializeField] Transform _fvPos;
    Transform _follow;
    float rotX;
    float rotY;
    float WheelPos;

    Vector3 _tvPos;

    private void Start()
    {
        _tvPos = _realCam.localPosition;
        WheelPos = 1;
        _realCam.position = gameObject.GetComponent<Transform>().position;

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        _follow = player.GetComponent<Transform>();

    }

    private void Update()
    {
        rotX -= Input.GetAxis("Mouse Y");
        rotY += Input.GetAxis("Mouse X");
        transform.rotation = Quaternion.Euler(rotX, rotY, 0);
        transform.position = _follow.position;

        float wheelInput = Input.GetAxis("Mouse ScrollWheel");
        if (wheelInput != 0)
        {
            Debug.Log("wheel Input value : " + wheelInput);
            WheelPos += wheelInput;
            if (WheelPos > 1) WheelPos = 1;
            if (WheelPos < 0) WheelPos = 0;
            _realCam.localPosition = Vector3.Lerp(_fvPos.localPosition, _tvPos, WheelPos);
        }
        if (Input.GetMouseButtonDown(0))
        {
            _realCam.position = gameObject.GetComponent<Transform>().position;
        }
        if (Input.GetMouseButtonDown(1))
        {
            _realCam.position = _fvPos.position;
        }
    }
}
