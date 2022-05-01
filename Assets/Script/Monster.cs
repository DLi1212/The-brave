using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [SerializeField] int enemyHealth = 100;
    [SerializeField] int currentHealth;
    [SerializeField] GameObject[] waypoints;
    [SerializeField] float rotSpeed = 0.5f;
    [SerializeField] float speed = 3f;
    [SerializeField] HealthBar1 healthbar1;
    [SerializeField] GameObject UI;

    public Animator animator;
    private Transform player;
    private Rigidbody rigid;
    private float distance = 5.0f;
    private int currentWP = 0;
    private bool hasPassed = false;

    void Start()
    {
        player = PlayerController.instance.GetComponent<Transform>();
        animator = GetComponent<Animator>();
        currentHealth = enemyHealth;
        healthbar1.MaxHealth(enemyHealth);
        rigid = transform.GetComponent<Rigidbody>();
        UI.SetActive(false);
    }

    //take damage after attack

    void Update()
    {
        Vector3 direction = player.position - transform.position;
        direction.y = 0;
        if (direction.magnitude >= 10 && waypoints.Length > 0)
        {
                animator.SetBool("Attack", false);
                animator.SetBool("Idle", false);
                animator.SetBool("Run", true);
                animator.SetBool("Warn", false);
                if (Vector3.Distance(waypoints[currentWP].transform.position, transform.position) < distance)
                {
                    currentWP = Random.Range(0, waypoints.Length);
                }

                transform.rotation = Quaternion.Slerp(transform.rotation,
                                                 Quaternion.LookRotation(waypoints[currentWP].transform.position - transform.position), rotSpeed * Time.deltaTime);
                transform.Translate(0, 0, Time.deltaTime * speed);
                UI.SetActive(false);
        }
        else if (direction.magnitude < 10 && direction.magnitude >= 6)
        {
            animator.SetBool("Run", false);
            animator.SetBool("Warn", true);
            transform.forward = direction;
            UI.SetActive(true);
        }
        else if (direction.magnitude < 6 && direction.magnitude >= 2)
        {
            animator.SetBool("Run", true);
            animator.SetBool("Attack", false);
            animator.SetBool("Warn", false);
            animator.SetBool("Idle", false);
            transform.forward = direction;
            transform.Translate(0, 0, Time.deltaTime * speed);
            UI.SetActive(true);
        }
        else
        {
            transform.forward = direction;
            animator.SetBool("Run", false);
            animator.SetBool("Attack", true);
            animator.SetBool("Warn", false);
            animator.SetBool("Idle", false);
            rigid.velocity = Vector3.zero;
            UI.SetActive(true);
        }
        if (currentHealth <= 0)
        {
            animator.SetBool("Die", true);
            Destroy(gameObject, 1.5f);
            if(hasPassed == false)
            {
                PlayerController.instance.coins += 5;
                hasPassed = true;
            }
        }
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthbar1.SetHealth(currentHealth);
    }

}


