using UnityEngine;
using System.Collections;

public class PlayerBehaviour : MonoBehaviour {

    float speed = 7;
    float speed2 = 7;
    public GameObject Player2;
    public GameObject missel;
    public GameObject missel2;
    public GameObject nave;
    public GameObject nave2;
	public static bool atirou;
    public static bool atirou2;
    public bool  player1 = true;
	GameObject tiro;
    GameObject tiro2;
    public GUIStyle style;


	void Start () {
        atirou = false;
        atirou2 = false;
	
	}
	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.tag == "Enemy" || col.gameObject.tag == "MisselEnemy")
		{
			ScoreManager.Dyes += 1;
			Destroy(gameObject);
		}
	}
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "MisselEnemy")
        {
            ScoreManager.Dyes += 1;
            Destroy(gameObject);
        }
    }
	// Update is called once per frame
	void Update () 
	{
		if (player1) {
			if (Input.GetAxis ("Player_H") < 0)
				transform.Translate (0, Input.GetAxis ("Player_H") * speed * -1 * Time.deltaTime, 0);
			if (Input.GetAxis ("Player_H") > 0)
				transform.Translate (0, Input.GetAxis ("Player_H") * speed * -1 * Time.deltaTime, 0);
			if (Input.GetAxis ("Player_V") < 0) {
				transform.Translate (0, 0, Input.GetAxis ("Player_V") * speed * Time.deltaTime);
				nave.transform.Rotate (0, 0, 2f);
				if (nave.transform.rotation.eulerAngles.z > 45 && nave.transform.rotation.eulerAngles.z < 100)
					nave.transform.rotation = Quaternion.Euler (nave.transform.rotation.eulerAngles.x, nave.transform.rotation.eulerAngles.y, 45);
			}
			if (Input.GetAxis ("Player_V") > 0) {
				transform.Translate (0, 0, Input.GetAxis ("Player_V") * speed * Time.deltaTime);
				nave.transform.Rotate (0, 0, -2f);
				if (nave.transform.rotation.eulerAngles.z < 320 && nave.transform.rotation.eulerAngles.z > 300)
					nave.transform.rotation = Quaternion.Euler (nave.transform.rotation.eulerAngles.x, nave.transform.rotation.eulerAngles.y, 320);
			}
			if (Input.GetAxis ("Player_V") == 0) {
				if (nave.transform.rotation.eulerAngles.z > 180)
					nave.transform.Rotate (0, 0, 1.5f);
				else if (nave.transform.rotation.eulerAngles.z > 0)
					nave.transform.Rotate (0, 0, -1.5f);
			}
			if (Input.GetAxis ("Player_Fire") != 0 && !atirou) {
				tiro = (GameObject)Instantiate (missel, missel.transform.position, missel.transform.rotation);
				atirou = true;

			}
			if (atirou && tiro.transform.position.x > transform.position.x + 18) {
				Destroy (tiro.gameObject);
				atirou = false;
			}
			if (atirou) {
				tiro.rigidbody.velocity = new Vector3 (speed * Time.deltaTime + 40, tiro.rigidbody.velocity.y, tiro.rigidbody.velocity.z); 
			}
		} 
        else {
			if (Input.GetAxis ("Player2_H") < 0)
				transform.Translate (0, Input.GetAxis ("Player2_H") * speed2 * -1 * Time.deltaTime, 0);
			if (Input.GetAxis ("Player2_H") > 0)
				transform.Translate (0, Input.GetAxis ("Player2_H") * speed2 * -1 * Time.deltaTime, 0);
			if (Input.GetAxis ("Player2_V") < 0) {
				transform.Translate (0, 0, Input.GetAxis ("Player2_V") * speed2 * Time.deltaTime);
				nave2.transform.Rotate (0, 0, 2f);
				if (nave2.transform.rotation.eulerAngles.z > 45 && nave2.transform.rotation.eulerAngles.z < 100)
					nave2.transform.rotation = Quaternion.Euler (nave2.transform.rotation.eulerAngles.x, nave2.transform.rotation.eulerAngles.y, 45);
			}
			if (Input.GetAxis ("Player2_V") > 0) {
				transform.Translate (0, 0, Input.GetAxis ("Player2_V") * speed2 * Time.deltaTime);
				nave2.transform.Rotate (0, 0, -2f);
				if (nave2.transform.rotation.eulerAngles.z < 320 && nave2.transform.rotation.eulerAngles.z > 300)
					nave2.transform.rotation = Quaternion.Euler (nave2.transform.rotation.eulerAngles.x, nave2.transform.rotation.eulerAngles.y, 320);
			}
			if (Input.GetAxis ("Player2_V") == 0) {
				if (nave2.transform.rotation.eulerAngles.z > 180)
					nave2.transform.Rotate (0, 0, 1.5f);
				else if (nave2.transform.rotation.eulerAngles.z > 0)
					nave2.transform.Rotate (0, 0, -1.5f);
			}
			if (Input.GetAxis ("Player2_Fire") != 0 && !atirou2) {
				tiro2 = (GameObject)Instantiate (missel2, missel2.transform.position, missel2.transform.rotation);
				atirou2 = true;

			}
			if (atirou2 && tiro2.transform.position.x > transform.position.x + 18) {
				Destroy (tiro2.gameObject);
				atirou2 = false;
			}
			if (atirou2)
				tiro2.rigidbody.velocity = new Vector3 (speed2 * Time.deltaTime + 40, tiro2.rigidbody.velocity.y, tiro2.rigidbody.velocity.z);
		}
		if (!ScoreManager.ativado)
		{
			if (Input.GetAxis ("Player2_Go") != 0 && !Player2.gameObject.activeSelf || MenuSelectBehaviour.Options == "Player2" && !Player2.gameObject.activeSelf) 
			{
				Player2.gameObject.SetActive (true);
                ScoreManager.ativado = true;
			}
		}
	}
}