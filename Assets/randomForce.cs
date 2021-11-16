using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class randomForce : MonoBehaviour
{
    public static float limitForce = 3f;
    public static float limitSpeed = 3f;
    public static float mouseModifier = 3f;

    public float publicLimitForce, publicLimitSpeed, publicMouseModifier;

    private Vector2 lastMouseDirection;
    // public GameObject aimPrefab;
    // Start is called before the first frame update
    private void Awake()
    {
        limitForce = publicLimitForce;
        limitSpeed = publicLimitSpeed;
        mouseModifier = publicMouseModifier;
    }
    private void Start()
    {
        lastMouseDirection = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 direction = new Vector2((float)Random.Range(-limitForce, limitForce), Random.Range(-limitForce, limitForce));
        float force = (float)Random.Range(-limitSpeed, limitSpeed);

        Vector2 mouseDirection = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"))*mouseModifier;
        GetComponent<Rigidbody2D>().AddForce(direction*force);
        GetComponent<Rigidbody2D>().AddForce(mouseDirection);
    }

    
    

    
}
