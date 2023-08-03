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

    Vector3 _tvPos;

    private void Start()
    {
        _tvPos = _realCam.localPosition;
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
    }
}
