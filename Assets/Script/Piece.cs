using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour
{
    [SerializeField] GameObject guardian;
    private void Start()
    {
        guardian.SetActive(true);
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player")
        {
            guardian.SetActive(false);
        }
    }
}
