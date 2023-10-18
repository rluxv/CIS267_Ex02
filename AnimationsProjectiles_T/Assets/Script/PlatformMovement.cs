using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private bool moveLeft;
    public float movementSpeed;
    private float startPosX;
    public float offset;
    void Start()
    {
        moveLeft = false;
        startPosX = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        movePlatform();
    }

    private void movePlatform()
    {
        if (moveLeft)
        {
            transform.Translate(Vector2.left * movementSpeed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.right * movementSpeed * Time.deltaTime);

        }

        if (transform.position.x >= startPosX)
        {
            moveLeft = true;
        }
        if(transform.position.x <= startPosX - offset)
        {
            moveLeft = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag.Equals("Orc"))
        {
            collision.transform.parent = gameObject.transform;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Orc"))
        {
            collision.transform.parent = null;
        }
    }
}
