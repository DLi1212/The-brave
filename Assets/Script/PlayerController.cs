using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Text coinText;
    [SerializeField] float gravity = -12;
    [SerializeField] Transform cam;

    [SerializeField] float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    [SerializeField] float speedSmoothTime = 0.1f;
    float speedSmoothVelocity;
    float currentSpeed;
    float velocityY;

    private Animator animator;
    private CharacterController controller;

    [SerializeField] AudioClip[] footstepSounds;
    [SerializeField] AudioClip jumpSound;
    [SerializeField] AudioClip landingSound;
    [SerializeField] bool isGrounded;
    [SerializeField] float groundDistance = 0.1f;
    [SerializeField] LayerMask groundMask;
    [SerializeField] Transform groundCheckPos;
    [SerializeField] GameObject DeadPage;
    [SerializeField] GameObject map;
    [SerializeField] GameObject map1;
    [SerializeField] GameObject camera1;
    [SerializeField] GameObject camera2;
    [SerializeField] GameObject arrow;
    [SerializeField] Cursor1 cursor1;
    [SerializeField] Cursor2 cursor2;

    [Min(1.0f)] [SerializeField] private float stepRate = 1.2f;
    public static PlayerController instance;
    public bool attack = false;
    public bool hasdefended = false;
    public int playerHealth;
    public int playerMaxHealth = 100;
    public float jumpHeight = 0.5f;
    public float walkSpeed =3;
    public float runSpeed =5;
    public int coins = 10;
    public bool isDead = false;

    private bool isOpen;
    private float walk;
    private float run;
    private float height;
    private float nextStep = 0.0f;
    private AudioSource audioSource;
    private bool hasJump = false;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        playerHealth = playerMaxHealth;
        animator = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
        audioSource = GetComponent<AudioSource>();
        map.SetActive(false);
        map1.SetActive(false);
    }


    void Update()
    {
        height = jumpHeight;
        run = runSpeed;
        walk = walkSpeed;
        coinText.text = coins.ToString();
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        Vector2 inputDir = input.normalized;
        bool running = Input.GetKey(KeyCode.R);
        Move(inputDir, running);
        Jump();
        Attack();
        Defence();
        Die();
        Cursor();
        fallDamage();
        Map();
    }

    void Cursor()
    {
        if(SceneManager.GetActiveScene().buildIndex == 1)
        {
            cursor1.enabled = true;
            cursor2.enabled = false;
        }
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            cursor1.enabled = false;
            cursor2.enabled = true;
        }
    }

    void Move(Vector2 inputDir, bool running)
    {

        if (inputDir != Vector2.zero)
        {
            float targetRotation = Mathf.Atan2(inputDir.x, inputDir.y) * Mathf.Rad2Deg + cam.eulerAngles.y;
            transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRotation, ref turnSmoothVelocity, turnSmoothTime);
        }

        float targetSpeed = ((running) ? run : walk) * inputDir.magnitude;

        currentSpeed = Mathf.SmoothDamp(currentSpeed, targetSpeed, ref speedSmoothVelocity, speedSmoothTime);

        velocityY += Time.deltaTime * gravity;

        Vector3 velocity = transform.forward * currentSpeed + Vector3.up * velocityY;

        controller.Move(velocity * Time.deltaTime);
        currentSpeed = new Vector2(controller.velocity.x, controller.velocity.z).magnitude;

        if (controller.isGrounded && controller.velocity.y <0)
        {
            velocityY = 0;
        }
        float animationSpeedPercent = ((running) ? currentSpeed / run : currentSpeed / walk * .5f);
        animator.SetFloat("speedPercent", animationSpeedPercent, speedSmoothTime, Time.deltaTime);
        PlayFootStepAudio();
    }

    void Jump()
    {
        if (controller.isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                float jumpVelocity = Mathf.Sqrt(-3 * gravity * height);
                velocityY = jumpVelocity;
                animator.SetTrigger("isJump");
                audioSource.PlayOneShot(jumpSound);
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.Space))
            {
                hasJump = true;
            }
                
        }
        if (hasJump && controller.isGrounded)
        {
            audioSource.PlayOneShot(landingSound);
            hasJump = false;
        }

    }
    void PlayFootStepAudio()
    {
        if (controller.isGrounded && currentSpeed > 0.0f && Time.time > nextStep)
        {
            float offset = currentSpeed;
            if (currentSpeed >= stepRate)
            {
                offset = (stepRate / currentSpeed);
            }
            nextStep = Time.time + offset;
            int n = Random.Range(1, footstepSounds.Length);
            audioSource.clip = footstepSounds[n];
            audioSource.PlayOneShot(audioSource.clip);
            footstepSounds[n] = footstepSounds[0];
            footstepSounds[0] = audioSource.clip;
        }
    }
    
    void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            animator.SetTrigger("Attack");
            if (attack == false)
            {
                Invoke("CloseAttack", 0.5f);
            }
            attack = true;
        }
    }
    void CloseAttack()
    {
        attack = false;
    }
    void Defence()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            animator.SetBool("Defend",true);
            hasdefended = true;
        }
        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            animator.SetBool("Defend", false);
            hasdefended = false;
        }
    }
    void Die()
    {
        if (playerHealth <= 0)
        {
            animator.SetBool("Die", true);
            this.enabled = false;
            Invoke("GameOver", 1.5f);
        }
    }
    void GameOver()
    {
        isDead = true;
        DeadPage.SetActive(true);
    }
    void fallDamage()
    {
        bool preGround = isGrounded;
        isGrounded = Physics.CheckSphere(groundCheckPos.position, groundDistance, groundMask, QueryTriggerInteraction.Ignore);
        if (!preGround && isGrounded)
        {
            if (controller.velocity.y <= -12 && controller.velocity.y > -16)
            {
                playerHealth -= 5;
                animator.SetTrigger("GitHit");
            }
            else if (controller.velocity.y <= -16)
            {
                playerHealth -= 10;
                animator.SetTrigger("GitHit");
            }
        }
    }
    void Map()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            camera1.SetActive(true);
            camera2.SetActive(false);
            if (Input.GetKeyDown(KeyCode.M))
            {
                isOpen = !isOpen;
            }

            if (isOpen == true)
            {
                map.SetActive(true);
            }
            else
            {
                map.SetActive(false);
            }
        }
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            camera1.SetActive(false);
            camera2.SetActive(true);
            arrow.transform.localScale = new Vector3(5f, 6f, 1f);
            if (Input.GetKeyDown(KeyCode.M))
            {
                isOpen = !isOpen;
            }

            if (isOpen == true)
            {
                map1.SetActive(true);
            }
            else
            {
                map1.SetActive(false);
            }
        }
        
    }
    public void TakeDamage(int _damage)
    {
        if (playerHealth > 0)
        {
            playerHealth -= _damage;
        }
     
    }

}

