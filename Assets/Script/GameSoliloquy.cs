using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSoliloquy : MonoBehaviour
{

    [SerializeField] GameObject gui1;
    [SerializeField] GameObject gui2;
    [SerializeField] Text1 text1;
    private bool isOpen = false;

    private void Start()
    {
        gui1.SetActive(false);
        gui2.SetActive(false);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G) && isOpen == true && text1.isActive == false)
        {
            gui1.SetActive(false);
            gui2.SetActive(false);
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
                isOpen = true;
            }
        }
    }
}
