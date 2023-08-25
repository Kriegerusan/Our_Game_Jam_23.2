using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Weapon Data")]
public class Weapon_Data : ScriptableObject
{
    public float fireRate;
    public GameObject projectile;
    public Sprite sprite;
}
