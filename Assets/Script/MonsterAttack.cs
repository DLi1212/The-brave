using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAttack : MonoBehaviour
{
    // Start is called before the first frame update
    public Monster monster1;

    private float tempTime = 0;
    [SerializeField] private float cd = 0.5f;
    [SerializeField] private int Damage = 4;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (Time.time - tempTime > cd)
            {
                if (monster1.animator.GetBool("Attack") == true && PlayerController.instance.hasdefended == false)
                {
                    PlayerController.instance.TakeDamage(Damage);
                    PlayerController.instance.GetComponent<Animator>().SetTrigger("GitHit");
                    tempTime = Time.time;
                }
            }

        }

    }
}
