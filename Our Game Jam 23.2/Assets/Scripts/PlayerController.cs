using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{

    public static PlayerController Instance;

    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpThrust;
    [SerializeField] private GameObject weaponPivot;
    [SerializeField] private GameObject throwable;
    [SerializeField] private LayerMask layerJump;
    
    private WeaponBehaviour weaponBehaviour;
    private Vector2 aimVector;
    private Vector2 moveVector;
    private Rigidbody2D playerRigidbody;
    private bool hasBeenKilled, isTouchingGround;

    public DamageBlink blinker;

    void Awake()
    {
        blinker = GetComponent<DamageBlink>();
        playerRigidbody = GetComponent<Rigidbody2D>();
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
        weaponBehaviour = weaponPivot.GetComponentInChildren<WeaponBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasBeenKilled)
        {
            if (Input.GetKeyDown(KeyCode.J))
            {
                Jump();
            }

            if (Input.GetKey(KeyCode.K))
            {
                UseWeapon();
            }

            /*
            if (Input.GetKeyDown(KeyCode.L))
            {
                UseBomb();
            }
            */
        }



        moveVector = new Vector2(Input.GetAxisRaw("Horizontal"),0);
        aimVector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

    }

    private void FixedUpdate()
    {
        if (!hasBeenKilled)
        {
            Move();
        }
    }

    private void LateUpdate()
    {
        if (!hasBeenKilled)
        {
            AimWeapon();
        }
    }

    private void Jump()
    {
        if (playerRigidbody != null)
        {
            
            if(isTouchingGround)
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

        /*
        //option 2: Velocity
        if (playerRigidbody != null)
        {
            playerRigidbody.velocity = new Vector2(moveVector.x * moveSpeed, playerRigidbody.velocity.y);
        }
        /*

        /*
        //option 3: Transform.Translate
        transform.Translate(moveVector * moveSpeed * Time.deltaTime );
        */

        //Option 4: transform Direction
        Vector2 direction = transform.TransformDirection(new Vector2(Input.GetAxisRaw("Horizontal"), 0)).normalized * moveSpeed;

        if(playerRigidbody != null)
        {
            playerRigidbody.velocity = new Vector2(direction.x, playerRigidbody.velocity.y);
        }

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
            }
            else if(transform.localScale.x < 0 && aimVector.y != 0)
            {
                weaponPivot.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + 180));
            }
            else
            {
                weaponPivot.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
            }

        }
    }

    private void UseBomb()
    {
        //a changer pour une coroutine pour eviter de spam
        //instancie le prefab grenade et applique une force a env 45 degree
        GameObject grenade = Instantiate(throwable, transform.position, transform.rotation);

        if (transform.localScale.x < 0)
        {
            grenade.GetComponent<Rigidbody2D>().AddForce(new Vector2(-6, 7), ForceMode2D.Impulse);

        }
        else
        {
            grenade.GetComponent<Rigidbody2D>().AddForce(new Vector2(6, 7), ForceMode2D.Impulse);

        }


    }


    private void UseWeapon()
    {
        if(weaponBehaviour != null)
        {
            weaponBehaviour.Shoot();
        }
        //shoot the gun
    }

    public void ChangeWeapon() { }

    public void SetDeath(bool value)
    {
        hasBeenKilled = value;
        blinker.Blink();
        playerRigidbody.velocity = Vector2.zero;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ground")
        {
            isTouchingGround = true;
        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Ground")
        {
            isTouchingGround = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Ground")
        {
            isTouchingGround = false;
        }
    }

}
