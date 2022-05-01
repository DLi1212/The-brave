using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tigger1 : MonoBehaviour
{
    [SerializeField] GameObject object1;

    private void Start()
    {
        object1.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            object1.SetActive(true);
        }
    }

}
