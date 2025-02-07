using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jump;
    private Rigidbody2D body;
    private Animator anim;
    private bool grounded;
    private int Life = 3;
    private bool isDead = false;
    public TextMeshProUGUI LifeText;
    public GameObject GameOver;
    
    private void Awake()
    {

        //ดึงข้อมูลอ้างอิงสำหรับ rigidbody และ animator จากgame object.
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

    }
 
    private void Update()
    {

        float horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);
 
        //Flip player when facing left/right.
        if (horizontalInput > 0.01f)
            transform.localScale = new Vector3(-1, 1, 1);
        else if (horizontalInput < -0.01f)
            transform.localScale = Vector3.one;
 
        if (Input.GetKey(KeyCode.Space) && grounded)
            Jump();
 
        //sets animation parameters
        anim.SetBool("Walk", horizontalInput != 0);
        anim.SetBool("grounded", grounded);

        if (isDead)
        {
            body.velocity = Vector2.zero;
            anim.SetBool("Walk", false);
            anim.SetBool("grounded", true);
            GameOver.SetActive(true);
            return;
        }
    }
 
    private void Jump()
    {

        body.velocity = new Vector2(body.velocity.x, jump);
        //anim.SetTrigger("Jump");
        grounded = false;

    }
 
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Ground")
            grounded = true;

        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Life--;
            LifeText.text = "LIFE : " + Life.ToString();

            if (Life <= 0)
            {
                Die();
            }
        }
        if (collision.gameObject.CompareTag("Play"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        if (collision.gameObject.tag == "Die")
        {
            isDead = true;
        }
        if (collision.gameObject.tag == "Heal")
        {
            Life++;
            LifeText.text = "LIFE : " + Life.ToString();
        }
    }

    private void Die()
    {
        isDead = true;
        body.velocity = Vector2.zero;
        body.isKinematic = true;
    }

    



}