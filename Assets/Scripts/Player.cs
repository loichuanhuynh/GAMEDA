using System;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

[Serializable]
[CreateAssetMenu]
public class Player: MonoBehaviour
{
    public Status player_Status;
    public Image hp;
    public Image stamina;
    public int characterType;
    public InventoryScripTable inventoryScripTable;
    public List<Image> inv;
    public List<Image> equips;

    public GameObject UI;
    bool isInv = false;

    private void Start()
    {
        fillInv();

    }
    private void Update()
    {
        hp.transform.localScale = new Vector3((float)player_Status.HP / player_Status.HP_Max, 1, 1);
        if (Input.GetKeyDown(KeyCode.I) && !isInv)
        {
            isInv = true;
            UI.SetActive(true);
            fillInv();
        }
        else if (Input.GetKeyDown(KeyCode.I) && isInv)
        {
            isInv = false;
            UI.SetActive(false);
            fillInv();
        }
        
    }

    private void fillInv()
    {
        for (int i = 0; i < inventoryScripTable.inventory.Count; i++)
        {
            if (i >= 24)
                break;
            inv[i].sprite = inventoryScripTable.inventory[i].sprite;
        }
        for (int i = 0; i < inventoryScripTable.equipment.Count; i++)
        {
            if (i >= 4)
                break;
            equips[i].sprite = inventoryScripTable.equipment[i].sprite;
        }
    }
    
}
