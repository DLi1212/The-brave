using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LabyrinthTigger2 : MonoBehaviour
{
    [SerializeField] BoxCollider wall1;
    [SerializeField] BoxCollider wall2;
    [SerializeField] Text timeText;
    [SerializeField] LabyrinthTigger1 tigger1;
    [SerializeField] GameObject time;
    [SerializeField] GameObject piece;
    [SerializeField] GameObject worm;
    [SerializeField] GameObject door;
    public float Interval2;
    private string timePreText = "Total Time: ";

    void Start()
    {
        timeText.text = timePreText;
        time.SetActive(false);
        piece.SetActive(false);
        worm.SetActive(true);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && tigger1.hasStarted == true)
        {
            wall1.enabled = false;
            wall2.enabled = true;
            Interval2 = Time.timeSinceLevelLoad;
            string timer = (Interval2 - tigger1.Interval1).ToString("f2");
            timeText.text = timePreText + timer;
            time.SetActive(true);
            if((Interval2 - tigger1.Interval1) < 180.00)
            {
                piece.SetActive(true);
                worm.SetActive(false);
                door.SetActive(true);
            }
            tigger1.hasStarted = false;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            time.SetActive(false);
        }
    }

}
