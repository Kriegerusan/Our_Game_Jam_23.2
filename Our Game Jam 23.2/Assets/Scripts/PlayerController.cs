using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpThrust;

    private Vector2 moveVector;
    private Rigidbody2D playerRigidbody;

    void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        moveVector = new Vector2(Input.GetAxis("Horizontal"),0);
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Jump()
    {
        if (playerRigidbody != null)
        {
            playerRigidbody.AddForce(transform.up * jumpThrust, ForceMode2D.Impulse);
        }
    }


    private void Move()
    {
        if(playerRigidbody != null)
        {
            playerRigidbody.AddForce(moveVector * moveSpeed, ForceMode2D.Force);
            
        }
    }

}
