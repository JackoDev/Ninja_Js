using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Variables for character movements
    public float jumpForce = 15f;
    public float runningSpeed = 4f;

    Rigidbody2D rigidBody;
    Animator animator;
    Vector3 startPosition;

    const string STATE_ALIVE = "isAlive";
    const string STATE_ON_THE_GROUND = "isOnTheGround";

    public LayerMask groundMask;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        startPosition = this.transform.position;
    }

    public void StartGame()
    {
        animator.SetBool(STATE_ALIVE, true);
        animator.SetBool(STATE_ON_THE_GROUND, true);

        Invoke("RestartPosition", 0.5f);
    }

    void RestartPosition()
    {
        this.transform.position = startPosition;
        this.rigidBody.velocity = Vector2.zero;
        GameObject mainCamera = GameObject.Find("Main Camera");
        mainCamera.GetComponent<CameraFollow>().ResetCameraPosition();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        } else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))

            animator.SetBool(STATE_ON_THE_GROUND, IsTouchingTheGround());
        // Debug.DrawRay(this.transform.position, Vector2.down * 1.5f, Color.yellow);
    }

    void FixedUpdate()
    {
        if (GameManager.sharedInstance.currentGameState == GameState.inGame)
        {
            if (rigidBody.velocity.x < runningSpeed)
            {
                rigidBody.velocity = new Vector2(runningSpeed,
                    rigidBody.velocity.y);
            }
        } else
        {
            rigidBody.velocity = new Vector2(0, rigidBody.velocity.y);
        }
    }

    void Jump()
    {
        if (IsTouchingTheGround())
        {
            GetComponent<AudioSource>().Play();
            rigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
    // method for indicate if the character is on the floor or not
    bool IsTouchingTheGround()
    {
        if(Physics2D.Raycast(this.transform.position,
            Vector2.down,
            1.5f, groundMask))
        {
            animator.enabled = true;
            return true;
        }
        else
        {
            animator.enabled = false;
            return false;
        }
    }
    public void Die()
    {
        this.animator.SetBool(STATE_ALIVE, false);
        GameManager.sharedInstance.GameOver();
    }
}
