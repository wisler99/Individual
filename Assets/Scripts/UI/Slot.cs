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
        // �������� ��� ���� ��ġ�� �ƴ� ������ ��� �Ǿ����� ���ƿ;��� ��ġ ����
        // �������� �ű�°� �ƴ� ����(����)�̱� ������ ������ �����ܸ� ����
        _defultPostion = gameObject.GetComponent<Transform>().position;
        _dragItem = Instantiate(_itmeImage, transform);
        _dragItem.gameObject.AddComponent<DragSlot>();
        DragSlot.Instance.setItemData(_itemID, _itmeImage);
    }
    public void Drag(BaseEventData data)
    {
        // ������ ������ �������� ���콺�� ���� �ٴϵ��� ���� 
        Vector2 _followPostion = Input.mousePosition;
        _dragItem.GetComponent<Transform>().position = _followPostion;
    }
    public void EndDrag(BaseEventData data)
    {
        // �巡�װ� ������ ������ ������ ������ ����
        Destroy(_dragItem);
    }
    #endregion

}
