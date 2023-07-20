using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField] GameObject _slot;
    [SerializeField] Transform _bag;
    List<ItemData> _itemSlots = new List<ItemData>(); // 획득한 아이템들 목록 리스트
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
                // 아이템 인벤토리안에 같은 아이템이 있을경우 갯수를 눌려주는 함수
                _inventoryItemList[i]._invenCount++;
                break;
                check = true;
            }
        }
        if(check == false)
        {
            // 아이템 인벤토리안에 같은 아이템이 없을경우 슬롯을 새로 생성
            // 리소스 로드를 통해서 아이템 이미지를 가져오고 아이템 갯수를 1로 지정
            Sprite _dropItemImage = Resources.Load<Sprite>("ItemImage/ItemID" + data._itemID); //  리소스 파일안에서 아이템아이디에 맞는 이미지 파일을 가져옴
            InvenItemData _invenItemData = new InvenItemData(data, _dropItemImage);

            _inventoryItemList.Add(_invenItemData); // 회득한 아이템 정보를 인벤토리 리스트 안에 넣어줌

            GameObject temp = Instantiate(_slot, _bag); // 아이템 슬롯 추가
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
