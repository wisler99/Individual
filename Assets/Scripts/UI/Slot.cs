using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    [SerializeField]Image _itmeImage;
    [SerializeField] Text _countText;


    int _itemID;
    public int itemID
    {
        get { return _itemID; }
        set { _itemID = value; }
    }

    int _itemCount;
    public int itemCount
    {
        get { return _itemCount; }
        set { _itemCount = value; }
    }

    ItemType _itemType;
    public ItemType ItemType
    {
        get { return _itemType; }
        set { _itemType = value; }
    }

    public void Init(int itemID, Sprite spr)
    {
        _itemID = itemID;
        _itmeImage.sprite = spr;
        SlotUpdate(1);
    }

    public void SlotUpdate(int count)
    {
        _itemCount += count;
        _countText.text = _itemCount.ToString();
        if(_itemCount <= 0)
        {
            Destroy(gameObject);
        }
    }
    #region DragAndDrop

    Vector3 _defultPostion;
    Image _dragItem;

    public void BeginDrag(BaseEventData data)
    {
        // 아이템이 장비 장착 위치가 아닌 곧으로 드롭 되었을때 돌아와야할 위치 저장
        // 아이템을 옮기는게 아닌 장착(복붙)이기 때문에 아이템 아이콘만 복사
        _defultPostion = gameObject.GetComponent<Transform>().position;
        _dragItem = Instantiate(_itmeImage, transform);
        _dragItem.gameObject.AddComponent<DragSlot>();
        DragSlot.Instance.setItemData(_itemID, _itmeImage);
    }
    public void Drag(BaseEventData data)
    {
        // 복사한 아이템 아이콘이 마우스를 따라 다니도록 설정 
        Vector2 _followPostion = Input.mousePosition;
        _dragItem.GetComponent<Transform>().position = _followPostion;
    }
    public void EndDrag(BaseEventData data)
    {
        // 드래그가 끝나면 복사한 아이템 아이콘 삭제
        Destroy(_dragItem);
    }
    #endregion

}
