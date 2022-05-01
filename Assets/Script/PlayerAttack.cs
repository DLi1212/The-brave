using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private float tempTime = 0;
    [SerializeField] private float cd = 0.5f;
    public static int weaponDamage =8;
    [SerializeField] private int Damage;

    void Update()
    {
        Damage = weaponDamage;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Monster")
        {
            if (Time.time - tempTime > cd)
            {
                if (PlayerController.instance.attack == true)
                {
                    other.gameObject.GetComponent<Monster>().animator.SetTrigger("GitHit");
                    other.gameObject.GetComponent<Monster>().TakeDamage(Damage);
                    tempTime = Time.time;

                }
            }
        }
        if (other.gameObject.tag == "Devil")
        {
            if (Time.time - tempTime > cd)
            {
                if (PlayerController.instance.attack == true)
                {
                    other.gameObject.GetComponent<Devil>().animator.SetTrigger("GitHit");
                    other.gameObject.GetComponent<Devil>().TakeDamage(Damage);
                    tempTime = Time.time;

                }
            }
        }
    }

}
