﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeControllerScript : MonoBehaviour {

    public void StartTime()
    {
        Time.timeScale = 1;
    }
    public void StopTime()
    {
        Time.timeScale = 0;
    }
}
