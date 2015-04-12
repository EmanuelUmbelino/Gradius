using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyShooterBehaviour : MonoBehaviour {

    float speed = 5f;
    public GameObject missel;
    public GameObject fire; 
    GameObject rotarer;
    Vector3 random;
    GameObject shoot;
    

	// Use this for initialization
	void Start () {
        rotarer = GameObject.Find("ShootRotation");
        gameObject.collider.enabled = true;
        StartCoroutine(CallInitication());
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
        if (col.gameObject.tag != "Boss" && col.gameObject.tag != "Enemy" && col.gameObject.tag != "MisselEnemy")
        {
            Destroy(missel);
            Destroy(gameObject);
        }
    }
	// Update is called once per frame
    void Update()
    {
        if (fire.activeSelf.Equals(true))
        {
            transform.Rotate(random);
            StartCoroutine(ToDye());
        }
    }
    IEnumerator CallInitication()
    {
        yield return new WaitForSeconds(0.5f); 
        shoot = (GameObject)Instantiate(missel, missel.transform.position, missel.transform.rotation);
        shoot.transform.position = new Vector3(missel.transform.position.x, missel.transform.position.y, missel.transform.position.z);
        shoot.rigidbody.velocity = new Vector3(0, 0, 0);
        shoot.transform.parent = rotarer.transform; 
        if (fire.activeSelf.Equals(false))
            StartCoroutine(CallInitication());
    }
    IEnumerator ToDye()
    {
        yield return new WaitForSeconds(5);
        Destroy(missel);
        Destroy(gameObject);
    }

}
