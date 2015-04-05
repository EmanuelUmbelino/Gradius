using UnityEngine;
using System.Collections;

public class EnemyBalanceBehaviour : MonoBehaviour {

    float speed = 1f;
    float speedy = 0.05f;
    float counter = 0;
    int direction = Random.Range(0, 2);
	// Use this for initialization
	void Start () {
        if (direction.Equals(0)) direction = -1;
	}
	void OnTriggerEnter(Collider col)
	{
        if (col.gameObject.tag != "Boss")
        {
            Destroy(gameObject);
            col.gameObject.renderer.enabled = false;
            col.gameObject.collider.enabled = false;
            if (col.gameObject.tag == "Missel")
                PlayerBehaviour.score += 50;
            if (col.gameObject.tag == "Missel2")
                PlayerBehaviour.score2 += 50;
        }
    }
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag != "Enemy" && col.gameObject.tag != "Missel")
            Destroy(gameObject);
    }
	// Update is called once per frame
	void Update () {
        transform.Rotate(0, 0, 2);
        if (counter < 5 && counter >= 0)
        {
            transform.Translate(0, direction * speedy, 0);
            counter += 0.2f;
        }
        if (counter < 0)
        {
            transform.Translate(0, direction * -speedy, 0);
            counter += 0.2f;
        }
        if (counter >= 5) counter = -5;
	}
}
