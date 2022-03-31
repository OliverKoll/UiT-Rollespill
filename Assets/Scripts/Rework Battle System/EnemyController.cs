using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform player;
    public float moveSpeed;
    public Rigidbody2D rb;
    private Vector2 moveDirection;
    private Vector3 originalSize;
    private Vector3 playerDirection;
    bool inBattle;

    protected virtual void Start()
    {
        inBattle = player.gameObject.GetComponent<PlayerController>().inBattle;
        originalSize = transform.localScale;
    }

    void Update()
    {
        ProcessInputs();
        playerDirection = player.position - transform.position;
    }

    void FixedUpdate()
    {
        if (player.gameObject.GetComponent<PlayerController>().inBattle)
        {
            rb.constraints = RigidbodyConstraints2D.FreezePosition;
        }
        else if (!player.gameObject.GetComponent<PlayerController>().inBattle)
        {
            rb.constraints = RigidbodyConstraints2D.None;
        }
        Move();
    }

    void ProcessInputs()
    {
        float moveX = playerDirection.x;
        float moveY = playerDirection.y;

        if (moveDirection.x > 0)
        {
            transform.localScale = originalSize;
        }
        else if (moveDirection.x < 0)
        {
            transform.localScale = new Vector3(originalSize.x * -1, originalSize.y, originalSize.z);
        }

        moveDirection = new Vector2(moveX, moveY).normalized;
    }

    void Move()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }
}
