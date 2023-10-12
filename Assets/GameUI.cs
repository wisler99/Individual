using System;
using UnityEngine;
using UnityEngine.UI;


public class GameUI : MonoBehaviour
{
    [SerializeField] EquipmentSlot[] _equipmentSlots;
    [SerializeField] GameObject[] _slots;

    [SerializeField] GameObject _hungryBar;
    [SerializeField] GameObject _thirstBar;
    [SerializeField] GameObject _timerBar;

    [SerializeField] Text _dayText;
    [SerializeField] GameObject _gameUI;

    public void Init()
    {
        _gameUI.SetActive(true);
        UpdateSlot();
        InitBar();
        EquimentSlotDisable();

    }
    public void UpdateSlot()
    {
        EquimentSlotDisable();
        for (int i = 0; i < _equipmentSlots.Length; i++)
        {
            if (_equipmentSlots[i].transform.Find("Image").gameObject.activeSelf)
            {
                _slots[i].transform.Find("Image").GetComponent<Image>().sprite = _equipmentSlots[i].itemIcon;
                _slots[i].transform.Find("Image").gameObject.SetActive(true);
            }
        }
    }

    void EquimentSlotDisable()
    {
        for (int i = 0; i < _slots.Length; i++)
        {
            _slots[i].transform.Find("Image").gameObject.SetActive(false);
        }
    }

    void InitBar()
    {
        _timerBar.SetActive(true);
        _timerBar.GetComponent<Image>().fillAmount = 0;
        _thirstBar.SetActive(true);
        _thirstBar.GetComponent<Image>().fillAmount = 1;
        _hungryBar.SetActive(true);
        _hungryBar.GetComponent<Image>().fillAmount = 1;
    }

    public void TimeBarUpdate(float timer , int dayCount)
    {
        _timerBar.GetComponent<Image>().fillAmount = timer;
        DayTextUpdate(dayCount);
    }

    void DayTextUpdate(int dayCount)
    {
        _dayText.text = "DAY" + dayCount.ToString();
    }

    public void HungryBarUpdate(float value)  // 현재 배고픔 수치를 받아와서 게이지 형식으로 변환
    {
        _hungryBar.GetComponent<Image>().fillAmount = value / 100;
    }
    public void ThirstBarUpdate(float value)  // 현재 목마름 수치를 받아와서 게이지 형식으로 변환
    {
        _thirstBar.GetComponent<Image>().fillAmount = value / 100;
    }



}
