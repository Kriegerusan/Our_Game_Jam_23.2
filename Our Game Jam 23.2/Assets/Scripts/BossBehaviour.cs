using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehaviour : MonoBehaviour
{

    [SerializeField] private int maxHealth;
    [SerializeField] private BossState[] bossStates;
    [SerializeField] private GameObject[] weaponPivots;

    private int currentState;
    private int currentHealth;
    private bool bossDead, isShooting;

    public int CurrentHealth { get { return currentHealth; } }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        AimPlayer();
    }

    private void AimPlayer()
    {
        weaponPivots[0].transform.rotation = Quaternion.Euler(0,0,Mathf.Atan2(PlayerController.Instance.transform.position.y - weaponPivots[0].transform.position.y,
            PlayerController.Instance.transform.position.x - weaponPivots[0].transform.position.x) * Mathf.Rad2Deg);
    }

    private void Shoot()
    {

    }

    private IEnumerator ShootCoroutine()
    {
        isShooting = true;

        yield return new WaitForSeconds(1);

        isShooting = false;
    }


    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth < bossStates[currentState].endStateHealth)
        {
            currentState++;
        }
    }





}

[System.Serializable]
public class BossActions
{
    [Header("General")]
    public float actionLength;

    [Header("Shooting")]
    [SerializeField] private bool shouldShoot;
    [SerializeField] private bool shouldAimPlayer;
    [SerializeField] private GameObject projectile;
    [SerializeField] private float fireRate;
    [SerializeField] private Transform firepoint;

    [Header("Movement")]
    [SerializeField] private bool shouldMove;
    [SerializeField] private bool shouldChasePlayer;
    [SerializeField] private bool shouldPatrol;
    [SerializeField] private float moveSpeed;
    [SerializeField] private GameObject waypoint;

}

[System.Serializable]
public class BossState
{
    [SerializeField] private BossActions[] bossActions;

    public int endStateHealth;
}
