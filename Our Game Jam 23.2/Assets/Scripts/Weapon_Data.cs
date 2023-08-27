using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Weapon Data")]
public class Weapon_Data : ScriptableObject
{
    public Vector2 weaponOffset;
    public Vector2 muzzleOffset;
    public float fireRate;
    public GameObject projectile;
    public Sprite sprite;
    public int ammo;
    public bool countAmmo;
}
