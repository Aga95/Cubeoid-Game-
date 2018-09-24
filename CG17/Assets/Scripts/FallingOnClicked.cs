using UnityEngine;
//Henrik, easteregg when planets are clicked they fall.
public class FallingOnClicked : MonoBehaviour {
    //two bools to stop and start the planets from falling.
    public bool Falling;
    private bool Clicked;
    //define them at the start.
    void Start()
    {
        Falling = false;
        Clicked = true;
    }
    //make em fall if that is requested.
    void Update()
    {
        if (Falling) {
            float rAcc = Random.Range(1.0f,3.0f);
            transform.Translate(0.0f, -100.0f * rAcc * Time.deltaTime ,0.0f);
        }
        if (transform.position.y <= -500.0f)
        {
            Destroy(this.gameObject);
        }
    }
    //When object is clicked is activates the falling.
    void OnMouseDown()
    {
        if (Clicked)
        {
            print("Activating Falling");
            Falling = true;
            Clicked = false;
        }
        else if (!Clicked)
        {
            print("Deactivated Falling");
            Falling = false;
            Clicked = true;
        }
    }

}
