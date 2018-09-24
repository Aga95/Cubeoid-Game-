using UnityEngine;
using UnityEngine.SceneManagement;
//Henrik, Generic change scenen script.
public class MenuScript : MonoBehaviour {
    //method to change scene takes sceneName as a String.
    public MenuScript menuScript;
    public void ChangeScene(string sceneName)
    {
       SceneManager.LoadScene(sceneName);
    }
    //method for quiting the application.
    public void Exit()
    {
        print("Kill me naw plz");
        Application.Quit();
    }
}
