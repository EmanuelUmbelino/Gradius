using UnityEngine;
using System.Collections;

public class LookAt : MonoBehaviour {
    public Transform target; 
    public Transform target2;
    public GameObject missel;
    public Light light;
    GameObject shoot;
	Vector3 posicao_p1;
    GameObject rotarer;
   
	// Use this for initialization
	void Start () {
        rotarer = GameObject.Find("OORotation");
        StartCoroutine(CallInitication());
	}
	
	// Update is called once per frame
    void Update()
    {
        missel.transform.LookAt(target);
        if (DeathStar.boss)
            light.range += 0.015f;
        if (target.Equals(null))
            transform.LookAt(target2);
        else
            transform.LookAt(target);
        if (DeathStar.boss && target.Equals(null))
            light.range = 0;
	}
    IEnumerator CallInitication()
    {
        yield return new WaitForSeconds(2);
        shoot = null;
        if (target != null)
            posicao_p1 = target.position;
        yield return new WaitForSeconds(1);
        if (target != null && DeathStar.boss)
        {
            shoot = (GameObject)Instantiate(missel, missel.transform.position, missel.transform.rotation);
            shoot.transform.LookAt(target);
            shoot.transform.parent = rotarer.transform;
            light.range = 0.6f;
            MoveTowardsTarget();
        }
        StartCoroutine(CallInitication());
    }
    private void MoveTowardsTarget()
    {
        float speed = 30;
        Vector3 targetPosition = posicao_p1;
        Vector3 currentPosition = shoot.transform.position; 
        Vector3 directionOfTravel = targetPosition - currentPosition;
        directionOfTravel.Normalize();
        shoot.rigidbody.velocity = new Vector3(
            (directionOfTravel.x * speed),
            (directionOfTravel.y * speed),
            (directionOfTravel.z * speed));
    }
}
