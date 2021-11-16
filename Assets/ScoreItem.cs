using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class ScoreItem : MonoBehaviour
{
    public Text ID, Score;

    public int IDNum = 0;
    public float ScoreNum = 0.00f;
    public bool outHand = false; 
    private void Start()
    {
        RefreshUI();
        GetComponent<CanvasGroup>().alpha = 0f; 
        GetComponent<CanvasGroup>().DOFade(1f, 1.5f);
    }

    public void RefreshUI()
    {
        ID.text = "#" + IDNum.ToString();
        Score.text = ScoreNum.ToString("#0.00");
        if (outHand || ScoreNum<=0.1f)
        {
            Score.text = "脱靶";
        }
    }
}
