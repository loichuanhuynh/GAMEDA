using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Click : MonoBehaviour
{
    public Status status;

    public void click(int i)
    {
        status.id = i;
    }
}
