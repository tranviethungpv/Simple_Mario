using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    private new Rigidbody2D rigidbody2D;

    public float moveSpeed = 500.0f;
    public float jumpForce = 10000.0f;

    private bool isGrounded = true;

    private float lastHorizontalInput;

    private Animator anim;
    private int state;
    private bool isJumping;
    private string STATE_ANIMATION = "state";

    public int alive;
    public Text aliveText;

    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        state = 0;
        isJumping = false;
        alive = 3;
        aliveText.text = alive.ToString();
    }

    private void Update()
    {
        controlPlayer();
        playerAnimation();
        if(alive <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
    private void controlPlayer()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.position += new Vector3(horizontalInput * moveSpeed * Time.deltaTime, 0, 0);

        if (horizontalInput > 0 && lastHorizontalInput <= 0)
        {
            transform.localScale = new Vector3((float)101.4606, (float)101.4606, (float)101.4606);
        }
        else if (horizontalInput < 0 && lastHorizontalInput >= 0)
        {
            transform.localScale = new Vector3(-(float)101.4606, (float)101.4606, (float)101.4606);
        }

        lastHorizontalInput = horizontalInput;
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rigidbody2D.AddForce(new Vector2(0, jumpForce));
            isGrounded = false;
            isJumping = true;
        }
    }
    private void playerAnimation()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        if (isJumping)
        {
            state = 2;
        }
        else
        {
            if(horizontalInput != 0)
            {
                state = 1;
            }
            else
            {
                state = 0;
            }
        }
        anim.SetInteger(STATE_ANIMATION, state);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
            isJumping = false;
        }
        if (collision.gameObject.tag == "Finish")
        {
            SceneManager.LoadScene("GameWin");
        }
        if (collision.gameObject.tag == "Limit")
        {
            SceneManager.LoadScene("GameOver");
        }
        if (collision.gameObject.tag == "Enemy" && isJumping == false)
        {
            alive--;
            aliveText.text = alive.ToString();
        }
        if (collision.gameObject.tag == "Enemy" && isJumping == true)
        {
            KillEnemy(collision.gameObject);
        }
    }
    private void KillEnemy(GameObject enemy)
    {
        Destroy(enemy);
    }
}

