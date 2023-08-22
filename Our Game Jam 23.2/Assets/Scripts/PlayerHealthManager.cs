using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour
{
    //a voir pour passer la classe en Singleton.
    static PlayerHealthManager instance;

    [SerializeField] private int maxLives;

    private int credits;
    private int currentLives;
    private bool gameOver;
    
    public int CurrentLives { get { return currentLives; } }
    public int Credits { get { return credits; } }

    private void Awake()
    {
        instance = this;
        credits = 0;
        gameOver = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddCredits()
    {
        credits++;
    }

    public void UseCredits()
    {
        if(credits > 0)
        {
            credits--;
            currentLives = maxLives;
        }
    }


    public void TakeDamage()
    {
        if(currentLives > 0)
        {
            currentLives--;
        }else if(currentLives == 0 && credits > 0)
        {
            UseCredits();
        }
        else
        {
            gameOver = true;
        }
        

    }


}
