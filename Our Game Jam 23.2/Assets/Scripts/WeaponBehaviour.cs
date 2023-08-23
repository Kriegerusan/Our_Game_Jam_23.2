using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponBehaviour : MonoBehaviour
{
    [SerializeField] protected GameObject projectile;
    [SerializeField] protected GameObject muzzle;
    [SerializeField] protected float fireRate;
    [SerializeField] protected float projectileSpeed;
    protected bool isFiring;
    
    public abstract void Shoot();

}
