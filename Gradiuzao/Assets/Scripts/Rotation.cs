using UnityEngine;
using System.Collections;

public class Rotation : MonoBehaviour {

    public float velRot;
    public float velRotx;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(0, velRot * Time.deltaTime, 0);
        transform.Rotate(0, 0, velRotx * Time.deltaTime);
	}
}
