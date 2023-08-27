using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundParallax : MonoBehaviour
{

    [SerializeField] private float parallaxOffset = -0.15f;
    [SerializeField] private Vector2 transformOffset;

    private Camera cam;
    private Vector2 startPos;
    private Vector2 travel => (Vector2)cam.transform.position - startPos;


    private void Awake()
    {
        cam = Camera.main;
    }

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }
    private void FixedUpdate()
    {
        transform.position = ((startPos + travel) + transformOffset) * parallaxOffset;
    }
}
