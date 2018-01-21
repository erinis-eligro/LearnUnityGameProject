using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public static PlayerController instance;
    public float jumpforce = 30f;
    public float runnungSpeed = 1.5f;

    public LayerMask groundLayer;
    public Animator animator;

    private Rigidbody2D rigidbody;
    private Vector3 startingPosition;

    // Use this for initialization
    void Start () {
        animator.SetBool("isAlive", true);
		
	}

    public void StartGame()
    {
        animator.SetBool("isAlive", true);
        this.transform.position = this.startingPosition;
    }

    private void Awake()
    {
        instance = this;
        rigidbody = GetComponent<Rigidbody2D>();
        startingPosition = this.transform.position;
    }

    // Update is called once per frame
    void Update () {
        if (GameManager.instance.currentGameState == GameState.inGame)
        {
            if (Input.GetMouseButtonDown(0) == true)
            {
                Debug.Log("Left mouse button clicked");
                this.Jump();
            }
            animator.SetBool("isStandGround", IsGrounded());
        }
        

    }

    

    private void FixedUpdate()
    {
        if (GameManager.instance.currentGameState == GameState.inGame)
        {
            if (rigidbody.velocity.x < runnungSpeed)
            {
                rigidbody.velocity = new Vector2(runnungSpeed, rigidbody.velocity.y);
            }
        }
        
    }

    void Jump()
    {
        if (IsGrounded()) rigidbody.AddForce(Vector2.up * jumpforce, ForceMode2D.Impulse);
    }

    bool IsGrounded()
    {
        bool returnValue = false;
        if (Physics2D.Raycast(this.transform.position, Vector2.down, 0.2f, groundLayer.value)) returnValue = true;

        return returnValue;
    }

    public void Killed ()
    {
        GameManager.instance.GameOver();
        animator.SetBool("isAlive",false);
        rigidbody.velocity = new Vector2(-1 * runnungSpeed, rigidbody.velocity.y);

    }

}
