using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Mask Object", menuName ="Inventory System/Items/Mask")]


public class MaskObject : ItemsObject
{
    public float restoreHealthValue;
    private void Awake() 
    {
        type = ItemType.Mask;
    }

}
