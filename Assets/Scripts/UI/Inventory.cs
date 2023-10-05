using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using static UnityEditor.Progress;

public class Inventory : MonoBehaviour
{
    [SerializeField] GameObject _slot;
    [SerializeField] Transform _bag;
    List<GameObject> _itemSlots = new List<GameObject>(); // ȹ���� �����۵� ��� ����Ʈ
    List<ItemData> _inventoryItemList = new List<ItemData>();

    [SerializeField] Button[] _makingBtns;
    [SerializeField] Button[] _cookingBtns;
    


    public void Init()
    {
        gameObject.SetActive(false);
        AllBtnDisable();
        CheckCombine();
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
        for (int i = 0; i < _inventoryItemList.Count; i++)  // �κ��丮�� ���� �������� ���� ���
        {
            if (data._itemID == _inventoryItemList[i]._itemID)
            {
                // ������ �κ��丮�ȿ� ���� �������� ������� ������ �����ִ� �Լ�
                _itemSlots[i].GetComponent<Slot>().SlotUpdate(1);
                CheckCombine();
                return;
            }
        }
        // �κ��丮�� ���� �������� ���� ���
        // ������ �κ��丮�ȿ� ���� �������� ������� ������ ���� ����
        // ���ҽ� �ε带 ���ؼ� ������ �̹����� �������� ������ ������ 1�� ����
        Sprite _dropItemImage = Resources.Load<Sprite>("ItemImage/ItemID" + data._itemID); //  ���ҽ� ���Ͼȿ��� �����۾��̵� �´� �̹��� ������ ������
        ItemData _invenItemData = new ItemData(data._itemID);

        _inventoryItemList.Add(_invenItemData); // ȸ���� ������ ������ �κ��丮 ����Ʈ �ȿ� �־���
        GameObject temp = Instantiate(_slot, _bag); // ������ ���� �߰�
        _itemSlots.Add(temp);
        temp.GetComponent<Slot>().Init(data._itemID, _dropItemImage);
        CheckCombine();
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
        CheckCombine();
    }

    public void AddCombineItem(int itemID)  // ������ �������� ����� �Լ� ���߿�  AddItem�� ������ ���� �ӽ�
    {
        Sprite _dropItemImage = Resources.Load<Sprite>("ItemImage/ItemID" + itemID); //  ���ҽ� ���Ͼȿ��� �����۾��̵� �´� �̹��� ������ ������
        ItemData _invenItemData = new ItemData(itemID);

        _inventoryItemList.Add(_invenItemData); // ȸ���� ������ ������ �κ��丮 ����Ʈ �ȿ� �־���
        GameObject temp = Instantiate(_slot, _bag); // ������ ���� �߰�
        _itemSlots.Add(temp);
        temp.GetComponent<Slot>().Init(itemID, _dropItemImage);
        CheckCombine();
    }
    #endregion

    #region ActiveBtn
    public void CheckCombine()  // ������ ������ ���Ҷ����� ȣ��
    {
        AllBtnBlack();
        CheckCooking();
        CheckMaking();
    }

    public void CheckMaking()
    {
        if (CheckIDAndCount(1, 3) && CheckIDAndCount(2, 1))  // �������� ���� ������ ���
        {
            _makingBtns[0].transform.Find("Image").GetComponent<Image>().color = Color.white;
        }    
    }
    public void CheckCooking()
    {
        
    }
    public void AllBtnDisable()
    {
        for (int i = 0; i < _makingBtns.Length; i++)
        {
            _makingBtns[i].gameObject.SetActive(false);
        }
        for (int i = 0; i < _cookingBtns.Length; i++)
        {
            _cookingBtns[i].gameObject.SetActive(false);
        }
    }

    void AllBtnBlack()
    {
        for(int i = 0; i < _makingBtns.Length; i++)
        {
            _makingBtns[i].transform.Find("Image").GetComponent<Image>().color = Color.black;
        }
        for(int i = 0; i<_cookingBtns.Length; i++)
        {
            _cookingBtns[i].transform.Find("Image").GetComponent<Image>().color = Color.black;
        }
    }
    
    public void MakingBtnActive()
    {
        for (int i = 0; i < _makingBtns.Length; i++) 
        {
            _makingBtns[i].gameObject.SetActive(true);
        }
    }
    public void CookingBtnActive()
    {
        for (int i = 0; i < _makingBtns.Length; i++) 
        {
            _cookingBtns[i].gameObject.SetActive(true);
        } 
    }
    #endregion

    #region MakingTab
    // ���۴뿡 trigger�� ȣ��ɰ�� ������ ���� ��ư Ȱ��ȭ
    // �κ��丮�� �˻�
    // �������� �����̵Ǹ� ��ư ���� Ȱ��ȭ
    // ������ ��ᰡ ������ �� ��ư ���� ��Ȱ��ȭ
    // ������ Ȱ��ȭ�� ��ư�� ������� BAG�� ������ ����

    public void MakeRockAxeBtn()
    {
        if(CheckIDAndCount(1,3) == true && CheckIDAndCount(2,1))
        {
            // ���� �������� ������ ���Կ� �߰�
            // ����� �������� �����۸���Ʈ���� ī��Ʈ �ٿ�
            UseMaterial(1,3);
            UseMaterial(2, 1);
            AddCombineItem(11);
            Debug.Log("�ϼ�");
        }
        else
        {
            Debug.Log("������ ������ �����մϴ�.");
        }
        CheckCombine();
    }

    public void MakeRockPickAxBtn()
    {


        CheckCombine();
    }
    public void MakeRopeBtn()
    {


        CheckCombine();
    }
    #endregion

    #region CookingTab

    #endregion

}

