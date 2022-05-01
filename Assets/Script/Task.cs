using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Task : MonoBehaviour
{
    [SerializeField] GameObject gui1;
    [SerializeField] GameObject gui2;
    [SerializeField] Inventory inventory;
    [SerializeField] Text text1;
    void Start()
    {
        text1.text = "";
        gui2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        text1.text = "Task:\r\nPieces collection(" + inventory.pieces + "/4).\r\n\r\nPlease go to the four corners of the map to take on the challenge.";
        if (inventory.pieces == 4)
        {
            gui1.SetActive(false);
            gui2.SetActive(true);
        }
    }
}
