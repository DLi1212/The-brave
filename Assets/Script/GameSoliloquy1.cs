using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSoliloquy1 : MonoBehaviour
{
    [SerializeField] GameObject gui1;
    [SerializeField] GameObject gui2;
    [SerializeField] GameObject gui3;
    [SerializeField] GameObject gui4;
    [SerializeField] Text1 text1;
    private bool isOpen = false;
    private bool hasOpen = false;

    private void Start()
    {
        gui1.SetActive(false);
        gui2.SetActive(false);
        gui4.SetActive(false);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G) && isOpen == true && text1.isActive == false && hasOpen == false)
        {
            gui1.SetActive(false);
            gui2.SetActive(false);
            gui4.SetActive(true);
            hasOpen = true;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (isOpen == false)
            {
                gui1.SetActive(true);
                gui2.SetActive(true);
                gui3.SetActive(false);
                isOpen = true;
            }
        }
    }
}
