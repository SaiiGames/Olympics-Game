using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour
{
    public static GameObject AimGameobj;

    private void Awake()
    {
        AimGameobj = gameObject;
    }
}
