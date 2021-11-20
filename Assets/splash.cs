using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class splash : MonoBehaviour
{
    private Image image;
    public Sprite frame1, frame2;
    // Start is called before the first frame update
    private void Awake()
    {
        image = GetComponent<Image>();
    }
    void Start()
    {
        
        StartCoroutine(showFrameOne());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator showFrameOne()
    {
        image.sprite = frame1;
        yield return new WaitForSeconds(1f);

        StartCoroutine(showFrameTwo());
    }
    IEnumerator showFrameTwo()
    {
        image.sprite = frame2;
        yield return new WaitForSeconds(1f);

        StartCoroutine(showFrameOne());

    }
}
