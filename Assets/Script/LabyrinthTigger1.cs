using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LabyrinthTigger1 : MonoBehaviour
{
    [SerializeField] BoxCollider wall1;
    [SerializeField] BoxCollider wall2;
    public bool hasStarted = false;
    public float Interval1;

    void Start()
    {
        wall1.enabled = false;
        wall2.enabled = true;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && hasStarted == false)
        {
            wall1.enabled = true;
            wall2.enabled = false;
            Interval1 = Time.timeSinceLevelLoad;
            hasStarted = true;
        }
    }

}
