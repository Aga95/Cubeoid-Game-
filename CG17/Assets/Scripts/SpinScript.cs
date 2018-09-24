using UnityEngine;
//Henrik, Rotates a Sphere, used on the planets in the menu.
public class SpinScript : MonoBehaviour {
    //Public float so it can be manipulated from unity
    public float Speed = 10f;
    //rotate on every frame and scale with Time.deltaTime for smoothness.
	void Update() {
        transform.Rotate(Vector3.up, Speed * Time.deltaTime);
	}
}
