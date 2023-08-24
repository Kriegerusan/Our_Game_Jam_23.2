using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{

    [SerializeField] private float explosionTimer;


    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, explosionTimer);
    }

}
