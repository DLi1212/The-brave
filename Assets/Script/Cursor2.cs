using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor2 : MonoBehaviour
{
    [SerializeField] PauseMenu pause;
    [SerializeField] Inventory inventory;

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
        else if (inventory.isOpen == true)
        {
            Cursor.lockState = CursorLockMode.None;
        }
        else if (PlayerController.instance.isDead == true)
        {
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
