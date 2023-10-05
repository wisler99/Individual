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
    List<GameObject> _itemSlots = new List<GameObject>(); // 획득한 아이템들 목록 리스트
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
        for (int i = 0; i < _inventoryItemList.Count; i++)  // 인벤토리에 같은 아이템이 있을 경우
        {
            if (data._itemID == _inventoryItemList[i]._itemID)
            {
                // 아이템 인벤토리안에 같은 아이템이 있을경우 갯수를 눌려주는 함수
                _itemSlots[i].GetComponent<Slot>().SlotUpdate(1);
                CheckCombine();
                return;
            }
        }
        // 인벤토리에 같은 아이템이 없을 경우
        // 아이템 인벤토리안에 같은 아이템이 없을경우 슬롯을 새로 생성
        // 리소스 로드를 통해서 아이템 이미지를 가져오고 아이템 갯수를 1로 지정
        Sprite _dropItemImage = Resources.Load<Sprite>("ItemImage/ItemID" + data._itemID); //  리소스 파일안에서 아이템아이디에 맞는 이미지 파일을 가져옴
        ItemData _invenItemData = new ItemData(data._itemID);

        _inventoryItemList.Add(_invenItemData); // 회득한 아이템 정보를 인벤토리 리스트 안에 넣어줌
        GameObject temp = Instantiate(_slot, _bag); // 아이템 슬롯 추가
        _itemSlots.Add(temp);
        temp.GetComponent<Slot>().Init(data._itemID, _dropItemImage);
        CheckCombine();
    }

    public bool CheckIDAndCount(int itemID, int needCount)  // 인벤토리안에 아이템이있는지 검사와 아이템 수량 검사
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

    public void UseMaterial(int itemID, int useCount)  // 아이템을 만들었을때 아이템 수량을 빼는 함수
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

    public void AddCombineItem(int itemID)  // 조합한 아이템을 만드는 함수 나중에  AddItem과 통합할 예정 임시
    {
        Sprite _dropItemImage = Resources.Load<Sprite>("ItemImage/ItemID" + itemID); //  리소스 파일안에서 아이템아이디에 맞는 이미지 파일을 가져옴
        ItemData _invenItemData = new ItemData(itemID);

        _inventoryItemList.Add(_invenItemData); // 회득한 아이템 정보를 인벤토리 리스트 안에 넣어줌
        GameObject temp = Instantiate(_slot, _bag); // 아이템 슬롯 추가
        _itemSlots.Add(temp);
        temp.GetComponent<Slot>().Init(itemID, _dropItemImage);
        CheckCombine();
    }
    #endregion

    #region ActiveBtn
    public void CheckCombine()  // 아이템 수량이 변할때마다 호출
    {
        AllBtnBlack();
        CheckCooking();
        CheckMaking();
    }

    public void CheckMaking()
    {
        if (CheckIDAndCount(1, 3) && CheckIDAndCount(2, 1))  // 돌도끼가 제작 가능할 경우
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
    // 제작대에 trigger가 호출될경우 아이템 제작 버튼 활성화
    // 인벤토리를 검사
    // 아이템이 충족이되면 버튼 색깔 활성화
    // 아이템 재료가 부족할 시 버튼 색깔 비활성화
    // 색깔이 활성화된 버튼을 누른경우 BAG로 아이템 생성

    public void MakeRockAxeBtn()
    {
        if(CheckIDAndCount(1,3) == true && CheckIDAndCount(2,1))
        {
            // 만든 아이템을 아이템 슬롯에 추가
            // 사용한 아이템을 아이템리스트에서 카운트 다운
            UseMaterial(1,3);
            UseMaterial(2, 1);
            AddCombineItem(11);
            Debug.Log("완성");
        }
        else
        {
            Debug.Log("아이템 수량이 부족합니다.");
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

