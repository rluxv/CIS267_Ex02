using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrcController : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb;
    public float movementSpeed;
    private float inputHorizontal;
    public float jumpForce;
    private Animator playerAnimator;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        moveLateral();
        jump();
    }

    private void moveLateral()
    {
        inputHorizontal = Input.GetAxisRaw("Horizontal");

        rb.velocity = new Vector2(movementSpeed * inputHorizontal, rb.velocity.y);

        if(inputHorizontal == 0)
        {
            playerAnimator.SetBool("isWalking", false);
        }
        else
        {
            playerAnimator.SetBool("isWalking", true);
        }

        flipPlayer(inputHorizontal);
    }

    private void jump()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    private void flipPlayer(float input)
    {
        if(input > 0)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        else if (input < 0)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
    }
}
