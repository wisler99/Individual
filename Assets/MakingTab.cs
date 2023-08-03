using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MakingTab : MonoBehaviour
{
    [SerializeField] GameObject[] _Tools;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            for (int i = 0; i < _Tools.Length; i++)
            {
                _Tools[i].SetActive(true);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            for (int i = 0; i < _Tools.Length; i++)
            {
                _Tools[i].SetActive(false);
            }
        }
    }
}
