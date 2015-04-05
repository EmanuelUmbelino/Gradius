using UnityEngine;
using System.Collections;

public class Destroyer : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag != "Missel")
            Destroy(col.gameObject);
    }
	// Update is called once per frame
	void Update () {
	
	}
}
