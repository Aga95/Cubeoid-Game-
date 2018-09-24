using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunRotation : MonoBehaviour {
    [Tooltip("Number of minutes realtime that are reflected by 1 second ingametime")]
    public float mPS = 600.0f;
    private Quaternion defaultRotation;
	// Use this for initialization
	void Start () {
        defaultRotation = transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
        float movementThisFrame = Time.deltaTime / 360 * mPS;
        transform.RotateAround(transform.position, Vector3.down, movementThisFrame);
            
	}
}
