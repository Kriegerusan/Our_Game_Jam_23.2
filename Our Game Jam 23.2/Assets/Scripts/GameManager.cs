using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;
    [SerializeField] private TextMeshProUGUI livesText, timerText, scoreText, creditsText;
    [SerializeField] private int levelTime = 180;
    [SerializeField] private int pointsByTime;
    [SerializeField] private Vector2 cameraOffset;
    
    private bool gameOver;
    private Camera mainCamera;
    private int maxLives = 3;
    private int currentLives = 0;
    private int credits = 0;
    private int score = 0;
    private Vector2 cameraDirection;

    private void Awake()
    {
        Instance = this;
        mainCamera = Camera.main;
    }

    // Start is called before the first frame update
    void Start()
    {
        currentLives = maxLives;
        livesText.text = "x " +currentLives.ToString();
        timerText.text = levelTime.ToString();
        creditsText.text = "credits : " + credits.ToString();
        scoreText.text = score.ToString();
        StartCoroutine(CountdownCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            credits++;

            creditsText.text = "credits : " + credits.ToString();
        }

        if(Input.GetKeyDown(KeyCode.Return) && credits > 0)
        {
            UseCredits();
        }

        CameraManagement();
    }

    public void AddCredits()
    {
        credits++;
    }

    public void UseCredits()
    {
        if (credits > 0)
        {
            credits--;

            creditsText.text = "credits : " + credits.ToString();

            currentLives = maxLives;

            livesText.text = "x " + currentLives.ToString();
        }
    }


    public void AddScore(int amount)
    {
        score += amount;

        scoreText.text = score.ToString();
    }

    private IEnumerator CountdownCoroutine()
    {
        yield return new WaitForSeconds(1);

        levelTime--;

        timerText.text = levelTime.ToString();

        if(levelTime > 0)
        {
            StartCoroutine(CountdownCoroutine());
        }
        else
        {
            PlayerLostLive();
        }
        
    }

    //Player Management

    public void PlayerLostLive()
    {
        if (currentLives > 0)
        {
            PlayerController.Instance.SetDeath(true);

            currentLives--;

            livesText.text = "x " + currentLives.ToString();
        }
        else if (currentLives == 0 && credits > 0)
        {
            UseCredits();
        }
        else
        {
            gameOver = true;
        }
    }

    //Game Winning

    public void WinLevel()
    {
        score += pointsByTime * levelTime;
    }

    //Camera Management

    void CameraManagement()
    {
        if((PlayerController.Instance.gameObject.transform.position.x - mainCamera.transform.position.x) > 0)
        {
            cameraDirection = new Vector2((PlayerController.Instance.gameObject.transform.position.x + cameraOffset.x),
            (PlayerController.Instance.gameObject.transform.position.y + cameraOffset.y));

        }
        else
        {
            cameraDirection = new Vector2(mainCamera.transform.localPosition.x,
            (PlayerController.Instance.gameObject.transform.position.y + cameraOffset.y));
        }

        mainCamera.transform.position = cameraDirection;


    }

}
