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

    private Vector3 lastEnemyPosition;
    public List<GameObject> enemyPrefabs;

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
        if (collision.gameObject.tag == "Gate_1")
        {
            SceneManager.LoadScene("Map_2");
        }
        if (collision.gameObject.tag == "Gate_2")
        {
            SceneManager.LoadScene("GameWin");
        }
        if (collision.gameObject.tag == "Limit")
        {
            SceneManager.LoadScene("GameOver");
        }
        if (collision.gameObject.tag == "Enemy1" && isJumping == false)
        {
            alive--;
            aliveText.text = alive.ToString();
        }
        if (collision.gameObject.tag == "Enemy2" && isJumping == false)
        {
            alive--;
            aliveText.text = alive.ToString();
        }
        if (collision.gameObject.tag == "Enemy3" && isJumping == false)
        {
            alive--;
            aliveText.text = alive.ToString();
        }
        if (collision.gameObject.tag == "Enemy4" && isJumping == false)
        {
            alive--;
            aliveText.text = alive.ToString();
        }
        if (collision.gameObject.tag == "Enemy1" && isJumping == true)
        {
            Renderer enemyRenderer = collision.gameObject.GetComponent<Renderer>();
            if (enemyRenderer != null)
            {
                enemyRenderer.material.color = new Color(1f, 1f, 1f, 0.5f); // Make the enemy object semi-transparent
            }
            lastEnemyPosition = collision.gameObject.transform.position; // Get the position of the destroyed enemy object
            Destroy(collision.gameObject, 0.2f); // Destroy the enemy object after 1 second
            Invoke("GenerateEnemy", 5f); // Call the GenerateEnemy method after a delay of delayTime seconds
        }
        if (collision.gameObject.tag == "Enemy2" && isJumping == true)
        {
            Renderer enemyRenderer = collision.gameObject.GetComponent<Renderer>();
            if (enemyRenderer != null)
            {
                enemyRenderer.material.color = new Color(1f, 1f, 1f, 0.5f); // Make the enemy object semi-transparent
            }
            lastEnemyPosition = collision.gameObject.transform.position; // Get the position of the destroyed enemy object
            Destroy(collision.gameObject, 0.2f); // Destroy the enemy object after 1 second
            Invoke("GenerateEnemy", 5f); // Call the GenerateEnemy method after a delay of delayTime seconds
        }
        if (collision.gameObject.tag == "Enemy3" && isJumping == true)
        {
            Renderer enemyRenderer = collision.gameObject.GetComponent<Renderer>();
            if (enemyRenderer != null)
            {
                enemyRenderer.material.color = new Color(1f, 1f, 1f, 0.5f); // Make the enemy object semi-transparent
            }
            lastEnemyPosition = collision.gameObject.transform.position; // Get the position of the destroyed enemy object
            Destroy(collision.gameObject, 0.2f); // Destroy the enemy object after 1 second
            Invoke("GenerateEnemy", 5f); // Call the GenerateEnemy method after a delay of delayTime seconds
        }
        if (collision.gameObject.tag == "Enemy4" && isJumping == true)
        {
            Renderer enemyRenderer = collision.gameObject.GetComponent<Renderer>();
            if (enemyRenderer != null)
            {
                enemyRenderer.material.color = new Color(1f, 1f, 1f, 0.5f); // Make the enemy object semi-transparent
            }
            lastEnemyPosition = collision.gameObject.transform.position; // Get the position of the destroyed enemy object
            Destroy(collision.gameObject, 0.2f); // Destroy the enemy object after 1 second
            Invoke("GenerateEnemy", 5f); // Call the GenerateEnemy method after a delay of delayTime seconds
        }
    }
    void GenerateEnemy()
    {
        GameObject enemyPrefabToSpawn = enemyPrefabs[Random.Range(0, enemyPrefabs.Count)];
        GameObject newEnemy = Instantiate(enemyPrefabToSpawn, lastEnemyPosition, Quaternion.identity);
        newEnemy.transform.localScale = new Vector3(120f, 120f, 120f);
        // Add any additional behavior to the new enemy object as needed
    }
}

