using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{

    private float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 2);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(1, 0, 0) * moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag != "Enemy")
        {
            if (collision.tag == "Player")
            {
                
                Debug.Log("Player got shot");
            }
            Destroy(gameObject);
        }
        
        
    }
    public void SetBulletSpeed(float amount)
    {
        moveSpeed = amount;
    }
}
