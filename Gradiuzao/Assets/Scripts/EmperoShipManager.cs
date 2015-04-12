using UnityEngine;
using System.Collections;

public class EmperoShipManager : MonoBehaviour {
    public LensFlare lf1;
    public LensFlare lf2;
    public LensFlare lf3;
    bool ativo;
    public static bool run;
	//public static bool start = false;
	void Start ()
    {
        ativo = true;
        run = false;
        StartCoroutine(CallInitication());
	}
	
	void Update ()
    {
        
        this.transform.Translate(0,0,15 * Time.deltaTime);
        if (ativo)
        {
            lf1.brightness -= 0.0002f;
            lf2.brightness -= 0.0002f;
            lf3.brightness -= 0.0002f;
        }
        else
        {
            lf1.brightness += 0.02f;
            lf2.brightness += 0.02f;
            lf3.brightness += 0.02f;
        }
        if (!ativo && run)
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
    IEnumerator CallInitication()
    {
        yield return new WaitForSeconds(20);
        ativo = false; 
        yield return new WaitForSeconds(1.5f);
        run = true;
        
    }
}
