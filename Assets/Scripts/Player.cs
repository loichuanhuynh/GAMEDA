using System;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
[CreateAssetMenu]
public class Player: MonoBehaviour
{
    public Status player_Status;
    public Image hp;
    public Image stamina;

    private void Update()
    {
        hp.transform.localScale = new Vector3((float)player_Status.HP / player_Status.HP_Max, 1, 1);
    }
}
