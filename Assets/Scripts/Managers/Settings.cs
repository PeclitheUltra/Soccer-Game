using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{
    private void Awake()
    {
        Application.targetFrameRate = 60;
        Screen.fullScreen = false;
    }
}
