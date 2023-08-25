using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponBehaviour : MonoBehaviour
{
    [SerializeField] protected Weapon_Data weaponData;
    [SerializeField] protected GameObject muzzle;
    [SerializeField] protected float projectileSpeed;
    protected bool isFiring;
    protected SpriteRenderer weaponSprite;

    protected void Awake()
    {
        weaponSprite = GetComponent<SpriteRenderer>();
    }

    public abstract void Shoot();



}
