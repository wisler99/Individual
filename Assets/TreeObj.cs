using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeObj : MonoBehaviour
{
    int _hp;
    private void Start()
    {
        _hp = 2;
    }

    void TreeHPControll()
    {
        _hp--;
        if(_hp == 0)
        {
            Destroy(gameObject);
        }
    }
}
