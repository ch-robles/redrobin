using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private Transform leftEdge;
    [SerializeField] private Transform rightEdge;
    public float speed = 2f;
    public int destination;

    private Transform player;
    public bool isChasing;
    public float lineOfSight = 2f;

    public Player playerHealth;
    public Enemy enemyHealth;

    private SpriteRenderer spriteRenderer;

    public float KBForce = 0.7f;
    public float KBCounter;
    public float KBTotalTime = 0.2f;
    public bool KnockFromRight;

    public Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if (enemyHealth.GetHealth() > 0)
        {
            if (isChasing)
            {
                if (transform.position.x > player.position.x)
                {
                    spriteRenderer.flipX = true;
                    transform.position += Vector3.left * speed * Time.deltaTime;
                }
                if (transform.position.x < player.position.x)
                {
                    spriteRenderer.flipX = false;
                    transform.position += Vector3.right * speed * Time.deltaTime;
                }
            }
            else
            {
                if (Vector2.Distance(transform.position, player.position) < lineOfSight)
                {
                    isChasing = true;
                }

                if (destination == 0)
                {
                    transform.position = Vector2.MoveTowards(transform.position, leftEdge.position, speed * Time.deltaTime);
                    spriteRenderer.flipX = true;

                    if (Vector2.Distance(transform.position, leftEdge.position) < 0.02f)
                    {
                        spriteRenderer.flipX = false;
                        destination = 1;
                    }
                }

                if (destination == 1)
                {
                    transform.position = Vector2.MoveTowards(transform.position, rightEdge.position, speed * Time.deltaTime);

                    if (Vector2.Distance(transform.position, rightEdge.position) < 0.02f)
                    {
                        spriteRenderer.flipX = true;
                        destination = 0;
                    }
                }
            }
        }
    }

    void FixedUpdate()
    {
        if (isChasing)
        {
            if (transform.position.x > player.position.x)
            {
                rb.velocity = new Vector2(-0.04f, rb.velocity.y); // Move left
            }
            else
            {
                rb.velocity = new Vector2(0.04f, rb.velocity.y); // Move right
            }
        }
        else
        {
            // Move along a predefined path
            if (destination == 0)
            {
                rb.velocity = new Vector2(-0.04f, rb.velocity.y); // Move left

                if (Vector2.Distance(transform.position, leftEdge.position) < 0.02f)
                {
                    destination = 1;
                }
            }
            else if (destination == 1)
            {
                rb.velocity = new Vector2(0.04f, rb.velocity.y); // Move right

                if (Vector2.Distance(transform.position, rightEdge.position) < 0.02f)
                {
                    destination = 0;
                }
            }
        }

        if (KBCounter > 0)
        {
            rb.velocity = KnockFromRight ? new Vector2(-KBForce, KBForce) : new Vector2(KBForce, KBForce);
            KBCounter -= Time.deltaTime;
        }
    }

    public bool IsChasing()
    {
        return isChasing;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, lineOfSight);
    }

}
