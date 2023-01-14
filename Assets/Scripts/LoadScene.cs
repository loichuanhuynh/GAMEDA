using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public Status status;
    public int id;
    bool isOk;
    bool isTrigger;
    // Start is called before the first frame update
    void Start()
    {
        isOk = false;
        isTrigger = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.KeypadEnter))
        {
            isOk = true;
        }
        if (isTrigger && isOk)
        {
            status.id_s = id;
            SceneManager.LoadScene(id);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isTrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isTrigger = false;
        }
    }
}
