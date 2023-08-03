using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class Inventory : MonoBehaviour
{
    [SerializeField] GameObject _slot;
    [SerializeField] Transform _bag;
    List<GameObject> _itemSlots = new List<GameObject>(); // 획득한 아이템들 목록 리스트
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
                // 아이템 인벤토리안에 같은 아이템이 있을경우 갯수를 눌려주는 함수
                _itemSlots[i].GetComponent<Slot>().SlotUpdate();
                return;
            }
        }
        // 아이템 인벤토리안에 같은 아이템이 없을경우 슬롯을 새로 생성
        // 리소스 로드를 통해서 아이템 이미지를 가져오고 아이템 갯수를 1로 지정
        Sprite _dropItemImage = Resources.Load<Sprite>("ItemImage/ItemID" + data._itemID); //  리소스 파일안에서 아이템아이디에 맞는 이미지 파일을 가져옴
        ItemData _invenItemData = new ItemData(data._itemID);

        _inventoryItemList.Add(_invenItemData); // 회득한 아이템 정보를 인벤토리 리스트 안에 넣어줌
        GameObject temp = Instantiate(_slot, _bag); // 아이템 슬롯 추가
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

