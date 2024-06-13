using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float speed = 5;
    private Rigidbody2D rb;
    public float jumpHigh = 5;
    private bool isGrounded = false;

    private Animator anim;
    private Vector3 rotation;

    private CoinManager m;

    public GameObject panel;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        rotation = transform.eulerAngles;
        m = GameObject.FindGameObjectWithTag("Text").GetComponent<CoinManager>();
    }

    void Update()
    {
        float direction = Input.GetAxis("Horizontal");

        if (direction != 0) {
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }

        //chainging the direction
        if (direction < 0)
        {
            transform.eulerAngles = rotation - new Vector3(0,180,0);
            transform.Translate(Vector2.right * speed * -direction * Time.deltaTime);
        }
        if (direction > 0)
        {
            transform.eulerAngles = rotation;
            transform.Translate(Vector2.right * speed * direction * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpHigh, ForceMode2D.Impulse);
            isGrounded = false;
        }

        //jumping animation
        if (isGrounded == false)
        {
            anim.SetBool("isJumping", true);
        }
        else
        {
            anim.SetBool("isJumping", false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            isGrounded = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Coin")
        {
            m.AddMoney();
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Spike")
        {
            panel.SetActive(true);
            Destroy(gameObject);
        }
    }
}