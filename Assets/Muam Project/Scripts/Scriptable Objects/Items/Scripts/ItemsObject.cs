using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// [CreateAssetMenu(fileName ="New Item", menuName="Item/Create New Item")]

public enum ItemType
{
    Mask,
    Sanitizer,
    Suplemen,
    Default
}
public abstract class ItemsObject : ScriptableObject 
{
    public GameObject prefab;
    public ItemType type;
     public string itemName;
    [TextArea(15,20)]
    public string description;
}
