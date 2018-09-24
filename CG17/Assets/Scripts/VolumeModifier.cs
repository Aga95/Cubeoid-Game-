using UnityEngine;
using UnityEngine.UI;

//Henrik
public class VolumeModifier : MonoBehaviour {

    public void setVolumeLevel(float Volume)
    {
        //does much of the samme as the Mute Sound script but the is for every change to the slider.
        float V = Volume / 10;
        AudioListener.volume = V;

        if (V == 0)
        {
            GameObject.Find("MusicToggle").GetComponentInChildren<Text>().text = "Sound Off";
        }
        else
        {
            GameObject.Find("MusicToggle").GetComponentInChildren<Text>().text = "Sound On";
        }
    }
}
