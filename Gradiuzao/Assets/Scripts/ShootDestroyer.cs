using UnityEngine;
using System.Collections;

public class ShootDestroyer : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine(CallInitication());
	}
	// Update is called once per frame
	void Update () {
        
	}
    IEnumerator CallInitication()
    {
        yield return new WaitForSeconds(7);
        if(gameObject.name.Equals("Capsule(Clone)"))
            Destroy(gameObject);
    }
}
