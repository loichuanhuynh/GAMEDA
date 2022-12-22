using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Caterory", menuName = "Inventory/Caterory")]
public class Caterory : ScriptableObject
{
    public int id;
    public List<Item> items;
    public GameObject gameItem;
}
