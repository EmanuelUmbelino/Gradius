using UnityEngine;
using System.Collections;

public class LookAt : MonoBehaviour {
    public Transform target;
    public GameObject missel;
    public Light light;
    GameObject shoot;
	Vector3 posicao_p1;
    GameObject rotarer;
    int counter = 0;
   
	// Use this for initialization
	void Start () {
        rotarer = GameObject.Find("PlayerRotation");
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(target);
        missel.transform.LookAt(target);
        if (counter >= 0)
        {
            light.range += 0.015f;
            counter++;
        }
        if (counter == 90)
        {
            shoot = null;
            posicao_p1 = target.position;
        }
        if (counter > 100)
        {
            shoot = (GameObject)Instantiate(missel, missel.transform.position, missel.transform.rotation);
            shoot.transform.parent = rotarer.transform;
            counter = 0;
            light.range = 0.6f;
            MoveTowardsTarget();
           
        }
	
	}
    private void MoveTowardsTarget()
    {
        float speed = 500;
        Vector3 targetPosition = posicao_p1;
        Vector3 currentPosition = shoot.transform.position; 
        Vector3 directionOfTravel = targetPosition - currentPosition;
        directionOfTravel.Normalize();
        shoot.rigidbody.velocity = new Vector3(
            (directionOfTravel.x * speed * Time.deltaTime),
            (directionOfTravel.y * speed * Time.deltaTime),
            (directionOfTravel.z * speed * Time.deltaTime));
    }
}
