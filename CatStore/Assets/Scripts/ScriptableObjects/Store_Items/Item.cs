using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Item", menuName = "Item")]
public class Item : ScriptableObject
{
    public string Item_Name;
    public Sprite Item_Image;
    public ItemStorageType Item_storageType;
    public int Item_SellValue;
    public int Item_BuyValue;
}
