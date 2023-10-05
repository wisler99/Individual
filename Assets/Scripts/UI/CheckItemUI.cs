using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckItemUI : MonoBehaviour
{
    void Start()
    {
        gameObject.SetActive(false);
    }
    

    public void AddItemExplain(bool _itemActive)
    {
        if(_itemActive == true) gameObject.SetActive(true);
        else gameObject.SetActive(false);
    }
}
