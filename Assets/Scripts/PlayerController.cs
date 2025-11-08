using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    public Vector2 move;
    public float speed = 5f;
    public Rigidbody2D rb;
    public float jumpingPower = 4f;
    public bool isJumping;
    public float jump;
    public bool grounded;
    public Animator animator;

    private bool isFacingRight;

    public float KBForce = 0.7f;
    public float KBCounter;
    public float KBTotalTime = 0.2f;
    public bool KnockFromRight;

    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        isFacingRight = true;
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") && grounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            animator.SetBool("isJumping", true);
            audioManager.PlaySFX(audioManager.jump);
        }

        else
        {
            animator.SetBool("isJumping", false);
        }


        if (move.x != 0)
        {
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }

        

        if (!isFacingRight && move.x > 0)
        {
            Flip();
        }
        else if (isFacingRight && move.x < 0)
        {
            Flip();
        }

    }

    void FixedUpdate()
    {
        move = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if (KBCounter <= 0)
        {
            rb.velocity = new Vector2(move.x * speed, rb.velocity.y);
        }

        else
        {
            if (KnockFromRight == true)
            {
                rb.velocity = new Vector2(-KBForce, KBForce);
            }
            if (KnockFromRight == false)
            {
                rb.velocity = new Vector2(KBForce, KBForce);
            }

            KBCounter -= Time.deltaTime;
        }
    }

    public void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            grounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            grounded = false;
        }
    }
}