using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory/Inventory")]
public class InventoryScripTable : ScriptableObject
{
    public List<Inventory> inventory;
    public List<Inventory> equipment;
    public Caterory sword;
    public Caterory potion;
    public Caterory Shield;
    public Caterory Bow;
    public Caterory Armor;
}
