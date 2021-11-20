using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class rotate : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 punch;
    public float duration;
    public int vibrato;
    public float elasticity;
    public float modi = 1;
    void Start()
    {
        DOUITranslate();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void DOUIRotate()
    {
        
        
        transform.DOPunchRotation(modi*punch, duration, vibrato, elasticity).OnComplete(DOUIRotate);
        modi = -modi;   

    }

    void DOUITranslate()
    {
        transform.DOPunchPosition(modi * punch, duration, vibrato, elasticity).OnComplete(DOUITranslate);
        modi = -modi;   

    }
}
