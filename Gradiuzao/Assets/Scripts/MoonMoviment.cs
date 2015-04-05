using UnityEngine;
using System.Collections;

public class MoonMoviment : MonoBehaviour {

	void Start ()
    {
	
	}
	
    void rotate()
    {
        this.transform.Rotate(0, 2.5f * Time.deltaTime,0);
    }

	void Update ()
    {
        rotate();
	}
}
