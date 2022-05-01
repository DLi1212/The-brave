using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Guidepost : MonoBehaviour
{
    [SerializeField] GameObject gui1;
    [SerializeField] GameObject gui2;
    [SerializeField] GameObject gui3;

    private bool isOpen = false;
    private bool inTrigger = false;


    private void Start()
    {
        gui1.SetActive(false);
        gui2.SetActive(false);
        gui3.SetActive(false);
    }

    private void Update()
    {
        if ((Input.GetKeyDown(KeyCode.G)) && inTrigger && isOpen == false)
        {
            gui2.SetActive(true);
            isOpen = true;
            gui1.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && isOpen == false)
        {
            gui1.SetActive(true);
            inTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {

        if (other.tag == "Player")
        {
            gui1.SetActive(false);
            gui2.SetActive(false);
            inTrigger = false;
            if (isOpen == true)
            {
                gui3.SetActive(true);
            }
        }
    }
}
