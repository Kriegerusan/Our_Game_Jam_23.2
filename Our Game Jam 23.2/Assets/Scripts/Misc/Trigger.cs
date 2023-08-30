using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    [SerializeField] private bool winTrigger;

    private bool triggered;



    // Start is called before the first frame update
    void Start()
    {
        triggered = false;
    }

    public bool GetTriggered()
    {
        return triggered;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (winTrigger && !triggered)
            {
                GameManager.Instance.WinLevel();
            }
            triggered = true;
            Destroy(gameObject,0.5f);

        }
    }
}
