using System.Collections;
using System.Collections.Generic;
using UnityEngine;



enum ItemType
{
    Tool,
    Material,
    Food,
}

public class ItemDatabase : MonoBehaviour
{

    List<Item> items = new List<Item>();

}

public class Item
{
    string _itemName;

    
}

public class Material : Item
{

}

public class Tool : Item
{

}
public class Food : Item
{

}
