using UnityEngine;
using System.Collections;

public class DeathStarLifeBehaviour : MonoBehaviour {

    int Life = 15;
    public LensFlare sol;

	// Use this for initialization
	void Start () {
	
	}
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag != "Boss" && col.gameObject.tag != "Enemy" && col.gameObject.tag != "MisselEnemy")
        {
            Life -= 1;
            col.gameObject.renderer.enabled = false;
            if (col.gameObject.tag == "Missel")
                ScoreManager.score += 130;
            if (col.gameObject.tag == "Missel2")
                ScoreManager.score2 += 130;
        }
    }
	// Update is called once per frame
	void Update () {
        if (Life <= 0)
            sol.brightness += 0.5f;
        if (sol.brightness > 30)
            Application.LoadLevel("YouWin");
	}
}
