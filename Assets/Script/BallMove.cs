using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMove : MonoBehaviour
{
    [SerializeField] Transform start;
    [SerializeField] Transform end;
    [SerializeField] private float cd = 0.5f;
    [SerializeField] private float speed = 5f;
    private float tempTime = 0;
    private float x = 0;
    void Start()
    {
        x = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Mathf.PingPong(Time.time * speed, Vector3.Distance(start.position, end.position));
        transform.position = new Vector3(x + distance, transform.position.y, transform.position.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (Time.time - tempTime > cd)
        {
            if (other.gameObject.tag == "Player")
            {
                PlayerController.instance.playerHealth -= 5;
                PlayerController.instance.GetComponent<Animator>().SetTrigger("GitHit");
                tempTime = Time.time;
            }
        }
            
    }
}
