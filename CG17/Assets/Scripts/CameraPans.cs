using UnityEngine;
//Henrik, this script handles the pans troughout the menus.
public class CameraPans : MonoBehaviour {

    //the main camera so we can manipulate it.
    public Camera mCamera;
    //The menu change script so we can start the game.
    public MenuScript menuScript;
    //The planet so we can zoom into it.
    public Transform earth;
    //Canvases for rotation Y's.
    public Canvas mainCanvasPos;
    public Canvas settingsCanvasPos;
    //bools to toggle the rotation in the update method.
    private bool panToSettings = false;
    private bool panToMain = false;
    private bool panToGame = false;
    private bool panToExitGame = false;
    //speed variable
    private float speed;

    //Method for paning the camera over to the settings canvas
    public void PanToSettings()
    {
        //activate panToSettings and set the speed to 0
        print("All aboard the train to the Settings screen");
        panToSettings = true;
        speed = 0.0f;
    }
    //method for paning the camera over to the main canvas.
     public void PanToMain()
    {
        //activate PanToMain and set the speed to 0
        print("All aboard the train to the Main screen");
        panToMain = true;
        speed = 0.0f;
    }
    //Method for paning the camera toward the earth and start the game.
    public void PlayGamePanToWorld()
    {
        //activate PlayGamePanToWorld and set the speed to 0
        print("All aboard the train to the GAME");
        panToGame = true;
        speed = 0.0f;
    }
    public void PanToExit()
    {
        //activate PanToExit and set the speed to 0
        panToExitGame = true;
        print("All aboard the train we are leaving :(");
        speed = 0.0f;
    }
    public void Awake()
    {
        Time.timeScale = 1;
    }
    void Update()
    {
        //This is what we do when we want to change to the settings menu.
        if (panToSettings) {
            //define float to the Y values of both the canvas and the camera
            float canvasRotY = settingsCanvasPos.transform.rotation.y;
            float cameraRotY = mCamera.transform.rotation.y;
            //increase the speed everytime for accelerated experiance
            speed += 4.0f;
            //rotate the camera untill its pointed at the settingscanvas
            if (canvasRotY <= cameraRotY)
            {
                mCamera.transform.Rotate(0.0f, - speed * Time.deltaTime, 0.0f);
            }
            //if it point to the canvas or slightly more then stop moveing the camera.
            if (canvasRotY >= cameraRotY)
            {
                print("Now arriving at Settings Menu");
                panToSettings = false;
            }

        }
        //this is what we do when we want to change to the main menu.
        if (panToMain)
        {
            //define float to the Y values of both the canvas and the camera
            float canvasRotY = mainCanvasPos.transform.rotation.y;
            float cameraRotY = mCamera.transform.rotation.y;
            //increase the speed everytime for accelerated experiance
            speed += 4.0f;
            //rotate the camera untill its pointed at the main canvas
            if (canvasRotY > cameraRotY)
            {
                mCamera.transform.Rotate(0.0f, speed * Time.deltaTime, 0.0f);
            }
            //if it point to the canvas or slightly more then stop moveing the camera.
            if (canvasRotY < cameraRotY)
            {
                print("Now arriving at Main menu");
                panToMain = false;
            }
        }
        //This is what we do when we want to play the game.
        if (panToGame)
        {
            //Define floats to track the position of the earth in the frame and zoom inn on it
            float earthPosX = earth.position.x;
            float cameraPosX = mCamera.transform.position.x;
            float cameraZoomedFOV = 10.0f;
            float cameraCurrentFOV = mCamera.fieldOfView;
            //change speed for smooth zoom
            speed += 2.0f;
            //move the camera on the x axsiss untill it lines up with the camera.
            if (earthPosX < cameraPosX)
            {
                mCamera.transform.Translate(- speed * Time.deltaTime, 0.0f,0.0f);
            }
            //zoom until wanted zoom amount
            if (cameraZoomedFOV < cameraCurrentFOV)
            {
                mCamera.fieldOfView -= (speed * Time.deltaTime) / 4.5f;
;            }
            //if zoom and on same x axsis stop moveing the camera and start the game
            if (earthPosX >= cameraPosX && cameraCurrentFOV <= cameraZoomedFOV)
            {
                print("Now entering the GAME WORLD!");
                panToGame = false;
                //For development we return to the main menu this will be changed in final version.
                menuScript.ChangeScene("MainHUD");
            }
        }
        //this is what we do when we want to exit the game.
        if (panToExitGame)
        {
            //define floats for the wanted position and current position
            float cameraWantedPosY = -1200.0f;
            float cameraPosY = mCamera.transform.position.y;
            //inscrese speed for smooth animation
            speed += 25.0f;
            //if the camera is not at the wanted position move it
            if (cameraWantedPosY < cameraPosY)
            {
                mCamera.transform.Translate(0.0f, - speed * Time.deltaTime, 0.0f);
            }
            //when it is at or belove the wanted position exit the games
            if (cameraWantedPosY >= cameraPosY)
            {
                print("Now exiting the game");
                panToExitGame = false;
                //Same as PlayGame since we cant exit the application when debuging just return to main menu.
                menuScript.ChangeScene("MainMenu");
                Application.Quit();
            }
        }
    }
}
