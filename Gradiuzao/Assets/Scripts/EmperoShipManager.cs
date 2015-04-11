using UnityEngine;
using System.Collections;

public class EmperoShipManager : MonoBehaviour {
    public LensFlare lf1;
    public LensFlare lf2;
    public LensFlare lf3;
    int counter = 0;
	//public static bool start = false;
	void Start () 
    {
	}
	
	void Update () 
    {
        this.transform.Translate(0,0,15 * Time.deltaTime);
        if (lf1.brightness >= 0.35f && counter == 0)
        {
            lf1.brightness -= 0.0002f;
            lf2.brightness -= 0.0002f;
            lf3.brightness -= 0.0002f;

        }
        else if (lf1.brightness < 2.7f && counter < 90)
        {
            lf1.brightness += 0.02f;
            lf2.brightness += 0.02f;
            lf3.brightness += 0.02f;
            counter++;

        }
        if (counter > 80)
        {
            rigidbody.velocity = new Vector3(0, 0, rigidbody.velocity.z + 5000 * Time.deltaTime);
            lf1.brightness -= 0.2f;
            lf2.brightness -= 0.2f;
            lf3.brightness -= 0.2f;
			//start = true;
        }
        if (lf1.brightness <= 0.001f && transform.position.z  > 50000)
            Destroy(gameObject);
	}
}
