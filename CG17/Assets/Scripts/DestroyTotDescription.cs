using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTotDescription : MonoBehaviour {
    
    public GameObject panel;

    // Use this for initialization
    void Awake()
    {
        Time.timeScale = 0;
    }
    public void Confirm()
    {
        Time.timeScale = 1;
        Destroy(panel);
    }

}
