using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MakingTab : MonoBehaviour
{
    [SerializeField] GameObject[] _Tools;
    [SerializeField] Inventory _inventory;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _inventory.MakingBtnActive();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _inventory.AllBtnDisable();
        }
    }
}
