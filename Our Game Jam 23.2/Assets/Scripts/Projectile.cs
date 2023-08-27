using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    
    private float moveSpeed;
    private SpriteRenderer bulletRenderer;

    private void Awake()
    {
        bulletRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(1, 0, 0) * moveSpeed * Time.deltaTime);
        if (!bulletRenderer.isVisible)
        {
            Destroy(gameObject);
        }
    }


    public void SetBulletSpeed(float amount)
    {
        moveSpeed = amount;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            

            collision.gameObject.GetComponent<EnemyBehaviour>().TakeDamage();
        }
        Destroy(gameObject);

    }


}
