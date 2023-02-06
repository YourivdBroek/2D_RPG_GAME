using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Itemype
{
    Weapon,
    Armor,
    Consumable,
    Gold
}

//[CreateAssetMenu(fileName = "New Item", menuName = "New/Item")]
public class Item : ScriptableObject
{
    public string itemName;
    public Itemype itemType;
    public bool stackable;
    public float currentAmount;
    public Sprite image;    
}
