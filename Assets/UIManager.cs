using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] Inventory _inventory;
    [SerializeField] GameUI _gamePlayUI;

    #region ╫л╠шео
    private static UIManager instance = null;
    private void Awake()
    {
        if (null == instance)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }

    }
    public static UIManager Instance
    {
        get
        {
            if (null == instance)
            {
                return null;
            }
            return instance;
        }
    }
    #endregion


    private void Start()
    {
        _inventory.Init();
        _gamePlayUI.Init();
    }
    #region GamePlayUI
    public void TimeBarUpdate(float timer, int dayCount)
    {
        _gamePlayUI.TimeBarUpdate(timer, dayCount);
    }

    public void HungryUpdate(float hungryValue)
    {
        _gamePlayUI.HungryBarUpdate(hungryValue);
    }
    public void ThirstUpdate(float thirstValue)
    {
        _gamePlayUI.ThirstBarUpdate(thirstValue);
    }
    #endregion

    #region Inventory
    public void InventoryOpen()
    {
        _inventory.InventoryOpen();
    }
    public void InventoryClose()
    {
        _inventory.InventoryClose();
    }

    public void AddItem(ItemData addItem)
    {
        _inventory.AddItem(addItem);
    }
    #endregion
}
