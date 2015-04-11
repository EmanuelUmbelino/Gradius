using UnityEngine;
using System.Collections;

public class ShootDestroyer : MonoBehaviour {

    int counter;
	// Use this for initialization
	void Start () {
	
	}
	// Update is called once per frame
	void Update () {
        if(gameObject.name.Equals("Capsule(Clone)"))
	        counter ++;
        if (counter > 50)
            Destroy(gameObject);
	}
}
