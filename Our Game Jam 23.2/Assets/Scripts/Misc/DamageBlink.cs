using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class DamageBlink : MonoBehaviour
{

    [SerializeField] private float blinkRate;
    [SerializeField] private float blinkLength;
    [SerializeField] private Material damageMaterial, defaultMaterial;

    private SpriteRenderer sprite;
    private bool blinking;

    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    public void Blink()
    {
        blinking = true;
        StartCoroutine(BlinkCountdown());
        StartCoroutine(DamageBlinkCoroutine());
    }

    private IEnumerator DamageBlinkCoroutine()
    {

        sprite.material = damageMaterial;
        yield return new WaitForSeconds(blinkRate);
        sprite.material = defaultMaterial;
        yield return new WaitForSeconds(blinkRate);
        if (blinking)
        {
            StartCoroutine(DamageBlinkCoroutine());
        }
        
    }

    private IEnumerator BlinkCountdown()
    {

        yield return new WaitForSeconds(1);
        blinkLength--;
        if(blinkLength > 0)
        {
            StartCoroutine(BlinkCountdown());
        }else
        {
            blinking = false;
        }

    }

}
