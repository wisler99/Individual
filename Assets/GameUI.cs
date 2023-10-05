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
    // �κ��丮 ���� ���Կ� �ִ� ���� �����ͼ� �ֱ�


    // �κ��丮���� �������� ���������� ����

    public void Init()
    {
        gameObject.SetActive(true);
        UpdateSlot();
        InitBar();
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
                Debug.Log("aaa");
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

    public void HungryBarUpdate(float value)  // ���� ����� ��ġ�� �޾ƿͼ� ������ �������� ��ȯ
    {
        _hungryBar.GetComponent<Image>().fillAmount = value / 100;
    }
    public void ThirstBarUpdate(float value)  // ���� �񸶸� ��ġ�� �޾ƿͼ� ������ �������� ��ȯ
    {
        _thirstBar.GetComponent<Image>().fillAmount = value / 100;
    }



}
