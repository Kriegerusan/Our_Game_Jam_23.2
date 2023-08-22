using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpThrust;
    [SerializeField] private GameObject weaponPivot;

    private Vector2 aimVector;
    private Vector2 moveVector;
    private Rigidbody2D playerRigidbody;
    private enum aimDirection { up, down, left, right, upLeft, upRight, downLeft, downRight }

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
        aimVector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Jump()
    {
        if (playerRigidbody != null)
        {
            if(playerRigidbody.velocity.y == 0)
            {
                playerRigidbody.AddForce(transform.up * jumpThrust, ForceMode2D.Impulse);
            }
            
        }
    }


    private void Move()
    {
        /*
        //Option 1: AddForce
        if(playerRigidbody != null)
        {
            if(moveVector != Vector2.zero)
            {
                playerRigidbody.AddForce(moveVector * moveSpeed, ForceMode2D.Force);
            }
            else
            {
                playerRigidbody.AddForce(-playerRigidbody.velocity);
            }
            
        }*/

        //option 2: Velocity
        if (playerRigidbody != null)
        {
            playerRigidbody.velocity = new Vector2(moveVector.x * moveSpeed, playerRigidbody.velocity.y);
        }

        /*
        //option 3: Transform.Translate
        transform.Translate(moveVector * moveSpeed * Time.deltaTime );
        */

    }

    private void AimWeapon()
    {
        if(weaponPivot != null)
        {
            
        }
    }

}
