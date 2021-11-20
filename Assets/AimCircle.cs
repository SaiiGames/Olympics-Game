using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimCircle : MonoBehaviour
{
    public GameObject aimPrefab;

    public static GameObject Instance;

    private void Awake()
    {
        Instance = gameObject;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        this.gameObject.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            var transform1 = transform;
            Instantiate(aimPrefab, transform1.position, transform1.rotation);
            RoundManager.EndRound();
        }
    }
    
    private void OnBecameInvisible()
    {
        if (RoundManager.isRoundStarted)
        {
            var transform1 = transform;
            Instantiate(aimPrefab, transform1.position, transform1.rotation);
            ScoreHandler.Instance.GetComponent<ScoreHandler>().OnOutHand();
            RoundManager.EndRound();  
        }
        
    }
}
