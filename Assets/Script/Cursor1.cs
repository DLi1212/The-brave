using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor1 : MonoBehaviour
{
    [SerializeField] PauseMenu pause;
    [SerializeField] shop shop;
    [SerializeField] Inventory inventory;
    [SerializeField] ChestExchange exchange;
    [SerializeField] LoadingScene loading;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void Update()
    {
        if (pause.GamePaused == true)
        {
            Cursor.lockState = CursorLockMode.None;
        }
        else if(shop.isOpen == true)
        {
            Cursor.lockState = CursorLockMode.None;
        }
        else if(inventory.isOpen == true)
        {
            Cursor.lockState = CursorLockMode.None;
        }
        else if(exchange.isOpen == true)
        {
            Cursor.lockState = CursorLockMode.None;
        }
        else if (PlayerController.instance.isDead == true)
        {
            Cursor.lockState = CursorLockMode.None;
        }
        else if (loading.isOpen1 == true)
        {
            Cursor.lockState = CursorLockMode.None;
        }
        else if (loading.isOpen2 == true)
        {
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

    }

}
