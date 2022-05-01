using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Devil : MonoBehaviour
{
    [SerializeField] int enemyHealth = 100;
    [SerializeField] int currentHealth;
    [SerializeField] float speed = 3f;
    [SerializeField] GameObject win;
    [SerializeField] GameObject StartPoints;
    [SerializeField] GameObject StartDir;
    [SerializeField] HealthBar1 healthbar1;
    [SerializeField] GameObject UI;

    public Animator animator;
    private Transform player;
    private Rigidbody rigid;

    void Start()
    {
        player = PlayerController.instance.GetComponent<Transform>();
        animator = GetComponent<Animator>();
        currentHealth = enemyHealth;
        healthbar1.MaxHealth(enemyHealth);
        rigid = transform.GetComponent<Rigidbody>();
        UI.SetActive(false);
        win.SetActive(false);
    }

    //take damage after attack

    void Update()
    {
        Vector3 direction = player.position - transform.position;
        direction.y = 0;
        if (direction.magnitude >= 5)
        {
            animator.SetBool("Attack", false);
            animator.SetBool("Idle", true);
            animator.SetBool("Run", false);

           
            if(Vector3.Distance(StartPoints.transform.position,transform.position) >1f)
            {
                transform.forward = StartPoints.transform.position - transform.position;
                transform.Translate(0, 0, Time.deltaTime * speed);
                animator.SetBool("Attack", false);
                animator.SetBool("Idle", false);
                animator.SetBool("Run", true);
            }
            else
            {
                animator.SetBool("Attack", false);
                animator.SetBool("Idle", true);
                animator.SetBool("Run", false);
                transform.forward = StartDir.transform.position - transform.position;
            }
            UI.SetActive(false);
        }
        else if (direction.magnitude < 5 && direction.magnitude >= 2)
        {
            animator.SetBool("Run", true);
            animator.SetBool("Attack", false);
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
            animator.SetBool("Idle", false);
            rigid.velocity = Vector3.zero;
            UI.SetActive(true);
        }
        if (currentHealth <= 0)
        {
            animator.SetBool("Die", true);
            Invoke("GameOver", 1.5f);
            Destroy(gameObject, 1.5f);
        }
    }
    void GameOver()
    {
        win.SetActive(true);
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthbar1.SetHealth(currentHealth);
    }
}
