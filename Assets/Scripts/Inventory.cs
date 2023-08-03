using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class Inventory : MonoBehaviour
{
    [SerializeField] GameObject _slot;
    [SerializeField] Transform _bag;
    List<GameObject> _itemSlots = new List<GameObject>(); // ȹ���� �����۵� ��� ����Ʈ
    List<ItemData> _inventoryItemList = new List<ItemData>();
    

    private void Start()
    {
        gameObject.SetActive(false);
    }
    
    public void InventoryOpen()
    {
        if (gameObject.activeSelf == false) gameObject.SetActive(true);
        else
        {
            gameObject.SetActive(false);
        }
    }

    public void AddItem(ItemData data)
    {
        bool check = false;

        for (int i = 0; i < _inventoryItemList.Count; i++)
        {
            if (data._itemID == _inventoryItemList[i]._itemID)
            {
                // ������ �κ��丮�ȿ� ���� �������� ������� ������ �����ִ� �Լ�
                _itemSlots[i].GetComponent<Slot>().SlotUpdate();
                return;
            }
        }
        // ������ �κ��丮�ȿ� ���� �������� ������� ������ ���� ����
        // ���ҽ� �ε带 ���ؼ� ������ �̹����� �������� ������ ������ 1�� ����
        Sprite _dropItemImage = Resources.Load<Sprite>("ItemImage/ItemID" + data._itemID); //  ���ҽ� ���Ͼȿ��� �����۾��̵� �´� �̹��� ������ ������
        ItemData _invenItemData = new ItemData(data._itemID);

        _inventoryItemList.Add(_invenItemData); // ȸ���� ������ ������ �κ��丮 ����Ʈ �ȿ� �־���
        GameObject temp = Instantiate(_slot, _bag); // ������ ���� �߰�
        _itemSlots.Add(temp);
        temp.GetComponent<Slot>().Init(data, _dropItemImage);
        Text tempText = temp.GetComponentInChildren<Text>();
        tempText.text = _inventoryItemList[_inventoryItemList.Count - 1]._itemCount.ToString();
    }
    public void InventoryUpdate()
    {

    }
    public void InventoryDiable()
    {

    }
 }

