using UnityEngine;
using System.Collections;

public class DeathStar : MonoBehaviour {

    public GameObject rotatior;
    public static bool boss;
    
	// Use this for initialization
	void Start () {
        boss = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (rotatior.transform.eulerAngles.y <= 339.4f && rotatior.transform.eulerAngles.y > 50)
        {
            transform.Rotate(0, -0.2f * Time.deltaTime, 0);
            boss = true;
        }
	}
}
