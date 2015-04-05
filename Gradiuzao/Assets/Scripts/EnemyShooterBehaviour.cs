using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyShooterBehaviour : MonoBehaviour {

    float speed = 5f;
    public GameObject missel;
    GameObject rotarer ;
    int counter;
    GameObject shoot;

	// Use this for initialization
	void Start () {
        rotarer = GameObject.Find("ShootRotation");

	}
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag != "Boss")
        {
            Destroy(gameObject);
            col.gameObject.renderer.enabled = false; 
            if (col.gameObject.tag == "Missel")
                PlayerBehaviour.score += 90;
            if (col.gameObject.tag == "Missel2")
                PlayerBehaviour.score2 += 90;
        }
    }
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag != "Enemy" && col.gameObject.tag != "Missel")
        {
            Destroy(missel);
            Destroy(gameObject);
        }
    }
	// Update is called once per frame
    void Update()
    {
        if (counter < 15) counter++;
        else
        {
            shoot = (GameObject)Instantiate(missel, missel.transform.position, missel.transform.rotation);
            shoot.transform.position = new Vector3(missel.transform.position.x, missel.transform.position.y, missel.transform.position.z);
            shoot.rigidbody.velocity = new Vector3(0, 0, 0);
            shoot.transform.parent = rotarer.transform;
            counter = 0;
        }
    }

}
