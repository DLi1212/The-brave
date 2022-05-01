using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevilAttack : MonoBehaviour
{
    public Devil devil;

    private float tempTime = 0;
    [SerializeField] private float cd = 0.5f;
    [SerializeField] private int Damage = 10;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (Time.time - tempTime > cd)
            {
                if (devil.animator.GetBool("Attack") == true && PlayerController.instance.hasdefended == false)
                {
                    PlayerController.instance.TakeDamage(Damage);
                    PlayerController.instance.GetComponent<Animator>().SetTrigger("GitHit");
                    tempTime = Time.time;
                }
            }

        }

    }
}
