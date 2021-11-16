using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using UnityEngine;

public class ScoreHandler : MonoBehaviour
{
    public GameObject scoreItemPrefab,scoreVerticalGroup,scorePanel;
    private float LastScore = 9.50f;
    private bool thisRoundOutHand = false;
    public static GameObject Instance;
    public static float[] scoreList =new float[5];
    public static float OverallScore
    {
        get
        {
            float num = 0;
            foreach (var Var in scoreList)
            {
                num += Var;
            }
            return num / (RoundManager.Round-1);
        }
    }
    private void Awake()
    {
        scoreList =new float[5];
        Instance = gameObject;
    }

    public void CalculateScore()
    {
        if (RoundManager.isInfiniteRound)
        {
            LastScore = 0;
            return;
        }
        var distance = Vector3.Distance(Aim.AimGameobj.transform.position, Vector3.zero);
        LastScore = 10.2f - distance*3.5f;
        if (LastScore < 0)
        {
            LastScore = 0;
        }
        if (LastScore > 10)
        {
            LastScore = 10f;
        }
        scoreList[RoundManager.Round - 1] = LastScore;
    }
    
    

    public void OnRoundEnded()
    {
        
        CalculateScore();
        GenerateScore();
        ExpandPanel();
        StartCoroutine(WaitNextRound());
    }
    IEnumerator WaitNextRound()
    {
        yield return new WaitForSeconds(3f);
        RoundManager.Instance.StartRound();
    }
    
    
    public void GenerateScore()
    {
        var clone = Instantiate(scoreItemPrefab,scoreVerticalGroup.transform);
        var item = clone.GetComponent<ScoreItem>();
        item.IDNum = scoreVerticalGroup.transform.childCount-1;
        item.ScoreNum = LastScore;
        if (thisRoundOutHand)
        {
            thisRoundOutHand = false;
            item.outHand = true;
        }
        item.RefreshUI();
    }

    public void ExpandPanel()
    {
        
        scorePanel.GetComponent<RectTransform>().DOLocalMove(new Vector3(0,0,0), 1.4f).SetEase(Ease.OutQuint);
    }

    public void HidePanel()
    {
        scorePanel.GetComponent<RectTransform>().DOLocalMove(new Vector3(-400,0,0), 0.8f).SetEase(Ease.OutQuint);   
    }

    public void OnOutHand()
    {
        thisRoundOutHand = true;
    }
}
