using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunTest : WeaponBehaviour
{

    Vector3 muzzleRotation;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

        Debug.Log(muzzle.transform.eulerAngles);
    }

    public override void Shoot()
    {
        if (!isFiring)
        {
            StartCoroutine(ShootCoroutine());
        }
        
    }

    private IEnumerator ShootCoroutine()
    {
        isFiring = true;
        if (transform.lossyScale.x < 0)
        {
            muzzleRotation = new Vector3(0, 0, -180);
        }
        else muzzleRotation = new Vector3(0, 0, 0);
        GameObject bullet = Instantiate(projectile, muzzle.transform.position, Quaternion.Euler(muzzle.transform.eulerAngles.x, muzzle.transform.eulerAngles.y, muzzle.transform.eulerAngles.z + muzzleRotation.z));
        bullet.GetComponent<Projectile>().SetBulletSpeed(projectileSpeed);
        yield return new WaitForSeconds(fireRate);
        isFiring = false;
    }

}
