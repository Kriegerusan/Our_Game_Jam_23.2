using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{

    private enum aimDirections { up, down, left, right, upLeft, upRight, downLeft, downRight }

    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpThrust;
    [SerializeField] private GameObject weaponPivot;

    private Vector2 aimVector;
    private Vector2 moveVector;
    private Rigidbody2D playerRigidbody;

    aimDirections aimDirection;

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



        moveVector = new Vector2(Input.GetAxisRaw("Horizontal"),0);
        aimVector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

    }

    private void FixedUpdate()
    {
        Move();
    }

    private void LateUpdate()
    {
        AimWeapon();
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

        //GameObject Flip direction
        if (moveVector.x == -1)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (moveVector.x == 1)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z);

    }

    private void AimWeapon()
    {

        if(weaponPivot != null)
        {

            float angle = Mathf.Atan2(aimVector.y, aimVector.x) * Mathf.Rad2Deg;
            if(aimVector.x < 0)
            {
                weaponPivot.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle +180));
            }else if(transform.localScale.x < 0 && aimVector.y != 0)
            {
                weaponPivot.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + 180));
            }
            else
            {
                weaponPivot.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
            }

        }
    }

    private void UseItem()
    {
        //throw grenade
    }

    private void UseWeapon()
    {
        //shoot the gun
    }

}
