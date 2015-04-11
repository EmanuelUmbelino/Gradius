using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyShooterBehaviour : MonoBehaviour {

    float speed = 5f;
    public GameObject missel;
    public GameObject fire; 
    GameObject rotarer;
    Vector3 random;
    int counter;
    GameObject shoot;
    int counter2 = 0;
    

	// Use this for initialization
	void Start () {
        rotarer = GameObject.Find("ShootRotation");
        gameObject.collider.enabled = true;

	}
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag != "Boss" && col.gameObject.tag != "Enemy")
        {
            random = new Vector3(Random.Range(-3, 3), Random.Range(-3, 3), Random.Range(-3, 3));
            fire.SetActive(true);
            gameObject.collider.enabled = false;
            col.gameObject.renderer.enabled = false; 
            if (col.gameObject.tag == "Missel")
                ScoreManager.score += 90;
            if (col.gameObject.tag == "Missel2")
                ScoreManager.score2 += 90;
        }
    }
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag != "Enemy" && col.gameObject.tag != "MisselEnemy")
        {
            Destroy(missel);
            Destroy(gameObject);
        }
    }
	// Update is called once per frame
    void Update()
    {
        if (fire.activeSelf.Equals(false))
        {
            if (counter < 15) counter++;
            else
            {
                shoot = (GameObject)Instantiate(missel, missel.transform.position, missel.transform.rotation);
                shoot.transform.position = new Vector3(missel.transform.position.x, missel.transform.position.y, missel.transform.position.z);
                shoot.rigidbody.velocity = new Vector3(0, 0, 0);
                shoot.transform.parent = rotarer.transform;
                counter = 0;
                print(counter);
            }
        }
        else
        {
            transform.Rotate(random);
            if (counter2 < 150) counter2++;
            else Destroy(gameObject);
        }
    }

}
