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
    public void InventoryUpdate()
    {

    }
    #region ItemAdd
    public void AddItem(ItemData data)
    {
        bool check = false;

        for (int i = 0; i < _inventoryItemList.Count; i++)
        {
            if (data._itemID == _inventoryItemList[i]._itemID)
            {
                // ������ �κ��丮�ȿ� ���� �������� ������� ������ �����ִ� �Լ�
                _itemSlots[i].GetComponent<Slot>().SlotUpdate(1);
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
    }

    public bool CheckIDAndCount(int itemID, int needCount)  // �κ��丮�ȿ� ���������ִ��� �˻�� ������ ���� �˻�
    {
        for (int i = 0; i < _itemSlots.Count; i++)
        {
            if (_itemSlots[i].GetComponent<Slot>().itemID == itemID)
            {
                if (_itemSlots[i].GetComponent<Slot>().itemCount >= needCount)
                {
                    return true;
                }
            }
        }
        return false;
    }

    public void UseMaterial(int itemID, int useCount)  // �������� ��������� ������ ������ ���� �Լ�
    {
        for(int i = 0; i < _itemSlots.Count; i++)
        {
            if (_itemSlots[i].GetComponent<Slot>().itemID == itemID)
            {
                _itemSlots[i].GetComponent<Slot>().SlotUpdate(-useCount);
            }
        }
    }

    #endregion

    #region MakingTab
    // ���۴뿡 trigger�� ȣ��ɰ�� ������ ���� ��ư Ȱ��ȭ
    // �κ��丮�� �˻�
    // �������� �����̵Ǹ� ��ư ���� Ȱ��ȭ
    // ������ ��ᰡ ������ �� ��ư ���� ��Ȱ��ȭ
    // ������ Ȱ��ȭ�� ��ư�� ������� BAG�� ������ ����
    
    public void MakeAxeBtn()
    {
        if(CheckIDAndCount(1,3) == true && CheckIDAndCount(2,1))
        {
            // ���� �������� ������ ���Կ� �߰�
            // ����� �������� �����۸���Ʈ���� ī��Ʈ �ٿ�
            UseMaterial(1,1);
            UseMaterial(2, 1);
            Debug.Log("�ϼ�");
        }
        else
        {
            Debug.Log("������ ������ �����մϴ�.");
        }
    }



    #endregion

}

