using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class RoundManager : MonoBehaviour
{
    public static RoundManager Instance;
    public static bool isRoundStarted = false;
    public static int Round = 0;
    public static bool isGameOver = false;
    public static bool isInfiniteRound = false;

    public GameObject endScreen,overallScoreText;
    private void Awake()
    {
        isGameOver = false;
        Round = 0;
        isRoundStarted = false;
        Instance = this;
    }

    private void Update()
    {
        if (isGameOver)
        {
            if (Input.anyKeyDown)
            {
                
                SceneManager.LoadScene(0);
            }
        }
    }
    private void Start()
    {
        StartRound();
    }
    public void StartRound()
    {
        if (isRoundStarted)
        {
            return;
        }
        
        Round++;
        if (Round >= 5)
        {
            if (!isInfiniteRound)
            {
                isGameOver = true;
            }
        }
        if (isGameOver)
        {
            ScoreHandler.Instance.GetComponent<ScoreHandler>().ExpandPanel();
            endScreen.GetComponent<CanvasGroup>().alpha = 0f;
            endScreen.SetActive(true);
            endScreen.GetComponent<CanvasGroup>().DOFade(1f, 0.4f);
            overallScoreText.GetComponent<Text>().text = ScoreHandler.OverallScore.ToString("#0.00");
            return;
        }
        isRoundStarted = true;
        ScoreHandler.Instance.GetComponent<ScoreHandler>().HidePanel();
        Destroy(Aim.AimGameobj);
        AimCircle.Instance.SetActive(true);
        AimCircle.Instance.transform.position = new Vector3(Random.Range(-5,5),Random.Range(-3,3),0);
    }

    public static void EndRound()
    {
        if (!isRoundStarted)
        {
            return;
        }
        isRoundStarted = false;
        AimCircle.Instance.SetActive(false);
        var sm = ScoreHandler.Instance.GetComponent<ScoreHandler>();
        sm.OnRoundEnded();
    }
    
}
