using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu_Demo : MonoBehaviour
{

    private int sceneIndex;
    [SerializeField]private AudioSource audioSourceSFX;
    [SerializeField] private AudioClip coinClip;

    [SerializeField] private Image fader;
    [SerializeField] private float fadeSpeed;
    private float fadeCountdown;

    private void Awake()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        
    }
    // Start is called before the first frame update
    void Start()
    {
        fadeSpeed = coinClip.length;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            EnterGame();
        }
    }

    private void EnterGame()
    {
        StartCoroutine(EnterGameCoroutine());
    }

    private IEnumerator FadeCoroutine(float targetAlpha)
    {
        yield return new WaitForSeconds(0.1f);
        while (!Mathf.Approximately(fader.color.a, targetAlpha))
        {
            float alpha = Mathf.MoveTowards(fader.color.a, targetAlpha, (fadeSpeed * Time.deltaTime));
            fader.color = new Color(fader.color.r, fader.color.g, fader.color.b, alpha);
            yield return null;
        }
    }

    private IEnumerator EnterGameCoroutine()
    {
        StartCoroutine(FadeCoroutine(1));
        audioSourceSFX.PlayOneShot(coinClip);
        yield return new WaitForSeconds(coinClip.length);
        SceneManager.LoadScene(sceneIndex + 1);
    }
}
