using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField] GameObject _slot;
    [SerializeField] Transform _bag;
    List<ItemData> _itemSlots = new List<ItemData>(); // ȹ���� �����۵� ��� ����Ʈ
    List<InvenItemData> _inventoryItemList = new List<InvenItemData>();
    

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
        Debug.Log("aaa");
        bool check = false;
        
        for(int i = 0; i < _inventoryItemList.Count; i++)
        {
            if(data._itemID == _inventoryItemList[i]._slotItemID)
            {
                // ������ �κ��丮�ȿ� ���� �������� ������� ������ �����ִ� �Լ�
                _inventoryItemList[i]._invenCount++;
                break;
                check = true;
            }
        }
        if(check == false)
        {
            // ������ �κ��丮�ȿ� ���� �������� ������� ������ ���� ����
            // ���ҽ� �ε带 ���ؼ� ������ �̹����� �������� ������ ������ 1�� ����
            Sprite _dropItemImage = Resources.Load<Sprite>("ItemImage/ItemID" + data._itemID); //  ���ҽ� ���Ͼȿ��� �����۾��̵� �´� �̹��� ������ ������
            InvenItemData _invenItemData = new InvenItemData(data, _dropItemImage);

            _inventoryItemList.Add(_invenItemData); // ȸ���� ������ ������ �κ��丮 ����Ʈ �ȿ� �־���

            GameObject temp = Instantiate(_slot, _bag); // ������ ���� �߰�
            Sprite tempImage = temp.GetComponentInChildren<Sprite>();
            Text tempText = temp.GetComponentInChildren<Text>();

            tempImage = _dropItemImage;
            tempText.text = _inventoryItemList[_inventoryItemList.Count - 1]._invenCount.ToString();
        }
    }
}

public class InvenItemData
{
    public int _invenCount;
    public int _slotItemID;
    public Sprite _slotItemImage;
    public InvenItemData(ItemData data , Sprite _addItemImage)
    {
        _slotItemID = data._itemID;
        _slotItemImage = _addItemImage;
        _invenCount = 1;
    }
}
