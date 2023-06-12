using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Sanitizer Object", menuName ="Inventory System/Items/Sanitizer")]

public class SanitizerObject : ItemsObject
{
    public float energyBonus;
    public float defenceBonus;
    private void Awake() 
    {
        type = ItemType.Sanitizer;
    }
    
}
