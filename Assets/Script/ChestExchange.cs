using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChestExchange : MonoBehaviour
{
    [SerializeField] Button Button;
    [SerializeField] Button Button1;
    [SerializeField] GameObject Chest;
    [SerializeField] GameObject piece;
    [SerializeField] GameObject text;
    [SerializeField] GameObject ExchageUI;

    private bool inTrigger = false;
    public bool isOpen = false;
    void Start()
    {
        Chest.SetActive(true);
        piece.SetActive(false);
        ExchageUI.SetActive(false);
        text.SetActive(false);
        Button.onClick.AddListener(Button_1);
        Button1.onClick.AddListener(Button_2);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G) && inTrigger == true)
        {
            GameObject.Find("SwordShieldCenturion").GetComponent<PlayerController>().enabled = false;
            ExchageUI.SetActive(true);
            isOpen = true;
        }
    }
    void Button_1()
    {
        if (PlayerController.instance.coins >= 50)
        {
            PlayerController.instance.coins -= 50;
            text.SetActive(false);
            ExchageUI.SetActive(false);
            Chest.SetActive(false);
            piece.SetActive(true);
            GameObject.Find("SwordShieldCenturion").GetComponent<PlayerController>().enabled = true;
            isOpen = false;
        }
    }
    void Button_2()
    {
        GameObject.Find("SwordShieldCenturion").GetComponent<PlayerController>().enabled = true;
        ExchageUI.SetActive(false);
        text.SetActive(false);
        isOpen = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            text.SetActive(true);
            inTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        text.SetActive(false);
        inTrigger = false;
    }
}
