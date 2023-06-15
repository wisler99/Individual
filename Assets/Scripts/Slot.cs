using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    [SerializeField] GameObject _takeItem; // ȸ���� ������
    Item _item; // ȸ���� ������ ����
    Text _textCount; // �� ������ ���� �ؽ�Ʈ�� ���
    public int _count; // �� ������ ���� ����
    Image _itemImage; // ������ �̹���

    private void Update()
    {
        _textCount.text = "X " + _count; // �� ������ ���� �ؽ�Ʈ�� ���
    }

    void AddItem(Item item , int count =1) // �������� ȸ��������
    {
        _item = item;
        _itemImage.sprite = item.GetComponent<Sprite>();
        _count += count;
    }


}
