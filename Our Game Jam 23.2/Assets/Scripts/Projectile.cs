using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    private float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 1);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(1, 0, 0) * moveSpeed * Time.deltaTime);
    }

    public void SetBulletSpeed(float amount)
    {
        moveSpeed = amount;
    }


}
