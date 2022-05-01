using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpHeight : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player")
        {
            PlayerController.instance.jumpHeight = 0.85f;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        PlayerController.instance.jumpHeight = 0.5f;
    }
}
