using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public AudioSource source;
    public AudioClip Clip;
    Rigidbody2D rb;
    Animator anim;
    public float speed = 5f;
    public float jumpForce = 12f;
    bool isGrounded;
    public Transform groundCheck;
    public LayerMask Ground;
    public GameObject pausePanel;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    void Start()
    {
        // anim.SetBool("IsRunning", false);
        // anim.SetBool("IsJumping", false);
        pausePanel.SetActive(false);
    }

    void Update()
    {
        charMove();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded)
            {
                jump();
            }
        }

        if (isGrounded)
        {
            anim.SetBool("IsJumping", false);
        }
        else
        {
            anim.SetBool("IsJumping", true);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0;
            pausePanel.SetActive(true);
        }
    }
    void charMove()
    {
        float h = Input.GetAxis("Horizontal");
        anim.SetFloat("Speedy", Mathf.Abs(h));

        Vector2 targetVelocity = new Vector2(h * speed, rb.velocity.y);

        rb.velocity = Vector2.Lerp(rb.velocity, targetVelocity, 0.5f); // You can adjust the smoothing factor (0.2f) to control the smoothness

        if (h != 0)
        {
            changeDirection(Mathf.Sign(h));
        }

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, Ground);
    }

    void changeDirection(float direction)
    {
        Vector3 tempscale = transform.localScale;
        tempscale.x = direction;
        transform.localScale = tempscale;
    }
    void jump()
    {
        rb.velocity = Vector2.up * jumpForce;
        //anim.SetBool("IsJumping", true);
    }

    void Die()
    {
        rb.bodyType = RigidbodyType2D.Static;
        //Destroy(gameObject);
        anim.SetTrigger("death");
        source.PlayOneShot(Clip);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Trap")
        {
            Die();
        }

        if (collision.gameObject.tag == "Flag")
        {
            SceneManager.LoadScene("Win");
        }

        if (collision.gameObject.name == "Enemy")
        {
            Die();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Enemy")
        {
            Destroy(collision.gameObject);
            jump();
            source.PlayOneShot(Clip);
        }
    }

    public void resumeButton()
    {
        Time.timeScale = 1.0f;
        pausePanel.SetActive(false);
    }

    public void QuitButton()
    {
        Application.Quit();
    }
    void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}