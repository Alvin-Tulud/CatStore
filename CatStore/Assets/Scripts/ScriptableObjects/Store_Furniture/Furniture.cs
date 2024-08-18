using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Furniture", menuName = "Furniture")]
public class Furniture : ScriptableObject
{
    public string Furniture_Name;
    public Sprite Furniture_Image;
    public ItemStorageType Furniture_storageType;
    public FurnitureType Furniture_Type;
    public int Furniture_BuyValue;
}
