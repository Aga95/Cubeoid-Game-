using UnityEngine;
using UnityEngine.UI;

//Henrik, Script that handles what happens with the UI when you mute the sound tought the toggle button
public class MuteSound : MonoBehaviour {

    public Slider musicSlider;
    private float tmpVolume;

    //This is done on Awake so that if you change Volume it will "stay" that way.
    private void Awake()
    {
        //set the current volume and times it by 10 so it can be applied to the slider.
        float V = AudioListener.volume * 10;
        //if the volume is 0 then the button should say that the sound is off
        if (V == 0)
        {
            GameObject.Find("MusicToggle").GetComponentInChildren<Text>().text = "Sound Off";
            
        }
        //Define the slider to be equals to the value of the current volume.
            musicSlider.value = V;

    }
    //if you toggle the button it changes text and then if you activate it again it turn the volume on to max.
    public void ChangeBtnText()
    {
        //what is currently written on the button
        string btnText = GameObject.Find("MusicToggle").GetComponentInChildren<Text>().text;
        //if the button says Sound off turn the sound on 
        if (btnText == "Sound Off")
        {
            GameObject.Find("MusicToggle").GetComponentInChildren<Text>().text = "Sound On";
            AudioListener.volume = tmpVolume;
            musicSlider.value = tmpVolume * 10;
        }
        //if the button says sound on turn the sound off
        else
        {
            tmpVolume = AudioListener.volume;
            GameObject.Find("MusicToggle").GetComponentInChildren<Text>().text = "Sound Off";
            AudioListener.volume = 0.0f;
            musicSlider.value = 0;
        }
    }
}
