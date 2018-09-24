using UnityEngine;

public class HideEscMenuScript : MonoBehaviour {

    public bool isVisible;
    public GameObject panel;

    // Use this for initialization
    void Awake()
    {
        isVisible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
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
            print("Stopping Time!");
            Time.timeScale = 1;
        }
        else
        {
            panel.SetActive(true);
            print("Starting Time!");
            Time.timeScale = 0;
        }

    }
}
