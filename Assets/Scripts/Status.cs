using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Status", menuName = "Player/Status")] 
public class Status : ScriptableObject
{
    public int STR;
    public int VIT;
    public int AGI;
    public int DEX;
    public int HP;
    public int HP_Max;
    public int Attack;
    public int Defend_Physic;
    public int Defend_Magic;
}
