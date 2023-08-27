using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{

    [SerializeField] private GameObject enemyProjectile;
    [SerializeField] private float shootDistance = 7;
    [SerializeField] private float chaseTolerance;
    [SerializeField] private float moveSpeed;
    [SerializeField] private int pointsGiven = 100;
    [SerializeField] private float fireRate = 0.4f;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private bool chasePlayer;

    private PlayerController player;
    private SpriteRenderer enemySprite;
    private Rigidbody2D enemyRigidbody;
    private bool inShootingState, isShooting;
    private bool isDead;
    private DamageBlink blinker;

    private void Awake()
    {
        enemySprite = GetComponent<SpriteRenderer>();
        enemyRigidbody = GetComponent<Rigidbody2D>();
        blinker = GetComponent<DamageBlink>();
        
    }

    // Start is called before the first frame update
    void Start()
    {
        player = PlayerController.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemySprite.isVisible && !isDead)
        {
            ShootPlayer();
            
        }

    }

    private void FixedUpdate()
    {
        if (enemySprite.isVisible && chasePlayer && !isDead)
        {
            ChasePlayer();
        }
        
    }

    private void ShootPlayer()
    {
        if (Vector2.Distance(player.transform.position, transform.position) < shootDistance)
        {
            inShootingState = true;

            
            if (!isShooting)
            {
                StartCoroutine(ShootCoroutine());
            }
            
        }
        else inShootingState = false;
    }

    private void ChasePlayer()
    {
        if (!inShootingState)
        {
            enemyRigidbody.velocity = new Vector2(Mathf.Clamp(player.transform.position.x - transform.position.x, -1,1) * moveSpeed, enemyRigidbody.velocity.y);
        }
        else enemyRigidbody.velocity = new Vector2(0,enemyRigidbody.velocity.y);
    }

    public void TakeDamage()
    {
        if (!isDead)
        {
            enemyRigidbody.velocity = Vector2.zero;
            GameManager.Instance.AddScore(pointsGiven);
            blinker.Blink();
            Destroy(gameObject, 1);
        }

        isDead = true;
    }

    private IEnumerator ShootCoroutine()
    {
        isShooting = true;

        GameObject bullet = Instantiate(enemyProjectile, transform.position, Quaternion.Euler(
                transform.eulerAngles.x,
                transform.eulerAngles.y,
                Mathf.Atan2(player.transform.position.y - transform.position.y, player.transform.position.x - transform.position.x) * Mathf.Rad2Deg));

        bullet.GetComponent<EnemyProjectile>().SetBulletSpeed(bulletSpeed);

        yield return new WaitForSeconds(fireRate);

        isShooting = false;
    }


}
