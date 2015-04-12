using UnityEngine;
using System.Collections;

public class EnemyBalanceBehaviour : MonoBehaviour {

    Vector3 speed;
    float speedy = 0.05f;
    int direction = Random.Range(0, 2);
    public GameObject[] pieces;
	// Use this for initialization
	void Start () {
        if (direction.Equals(0)) direction = -1;
       // pieces = GameObject.FindGameObjectsWithTag("Piece");
        
	}
	void OnTriggerEnter(Collider col)
	{
        if (col.gameObject.tag != "Boss" && col.gameObject.tag != "Enemy" && col.gameObject.tag != "MisselEnemy")
        {
            //gameObject.collider.enabled = false;
          
            if (col.gameObject.tag.Equals("Missel") || col.gameObject.tag.Equals("Missel2"))
            {
                StartCoroutine(CallInitication());
                gameObject.collider.enabled = false;
                for (int i = 0; i < pieces.Length; i++)
                {
                    pieces[i].gameObject.rigidbody.velocity = new Vector3(Random.Range(-9, 9), Random.Range(-9, 9), Random.Range(-9, 9));
                }
            }
            col.gameObject.renderer.enabled = false;
            col.gameObject.collider.enabled = false;
            if (col.gameObject.tag == "Missel")
                ScoreManager.score += 50;
            if (col.gameObject.tag == "Missel2")
                ScoreManager.score2 += 50;
        }
    }
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag.Equals("Finish"))
        {
            Destroy(gameObject);
        }
        if (col.gameObject.tag.Equals("Player"))
        {
            for (int i = 0; i < pieces.Length; i++)
            {
                pieces[i].gameObject.rigidbody.velocity = new Vector3(Random.Range(-9, 9), Random.Range(-9, 9), Random.Range(-9, 9));
            }
        }
       
    }
	// Update is called once per frame
	void Update () {
        if(gameObject.collider.enabled.Equals(true))
            transform.Rotate(0, 0, 2);
	}
    IEnumerator CallInitication()
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
       
    }
}
