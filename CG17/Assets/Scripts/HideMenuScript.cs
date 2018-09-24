using UnityEngine;
using UnityEngine.Experimental.UIElements;
using UnityEngine.UI;

public class HideMenuScript : MonoBehaviour {

    public bool isVisible;
    public GameObject panel;

	// Use this for initialization
	void Awake () {
        isVisible = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (isVisible == true)
            {
                ToggleVisibility(isVisible);
                isVisible = false;
            }
            else
                {
                ToggleVisibility(isVisible);
                isVisible = true;
                }
            }
        }

    void ToggleVisibility(bool state)
    {
        if (state)
        {
            panel.SetActive(false);
        }
        else
        {
            panel.SetActive(true);
        }

    }

	}
