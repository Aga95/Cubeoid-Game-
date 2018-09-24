using UnityEngine;

//Henrik; Music player that maintains the only music player troughout the game.
public class AudioController : MonoBehaviour
{
    //Initialize a static instance
    private static AudioController instance = null;
    //define the static instance
    public static AudioController Instance { get{ return instance; }}

    //using awake istead of start due to execution order
    void Awake()
    {
        print("Playing music");
        //if it is not null  and not this instance destroy that shit
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        //otherwise define instance to be this
        else
        {
            instance = this;
        }
        //if it survived the if statements dont destroy
        DontDestroyOnLoad(this.gameObject);
    }
    //checks that if we exit the app we dont play music.
    void Update()
    {
        if (  UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "ExitPan")
        {
            Destroy(this.gameObject);
        }
    }
}
