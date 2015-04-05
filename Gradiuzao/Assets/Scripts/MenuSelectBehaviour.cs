using UnityEngine;
using System.Collections;

public class MenuSelectBehaviour : MonoBehaviour {

    public static string Options;
    public Animator anim;
    bool rodando;

	void Start ()
    {
        Options = "Player1";
        rodando = false;
	}
	
    private void Select()
    {
        if (!rodando)
        {
            if (Input.GetAxis("Player_V") > 0) { Options = "Player1"; }
            if (Input.GetAxis("Player_V") < 0) { Options = "Player2"; }
        }

        if (Options.Equals("Player1")) { transform.position = new Vector3(-2.34f, -0.66f, -1.0f); }
        if (Options.Equals("Player2")) { transform.position = new Vector3(-2.34f, -1.46f, -1.0f); }
    }

    IEnumerator CallInitication()
    {
        yield return new WaitForSeconds(4);
        if (Input.GetAxis("Player_Fire") > 0 && Options.Equals("Player1")) { anim.SetInteger("AnimationStatus", 1); rodando = true; }
        if (Input.GetAxis("Player_Fire") > 0 && Options.Equals("Player2")) { anim.SetInteger("AnimationStatus", 1); rodando = true; }
    }

	void Update () 
    {
        Select();
        StartCoroutine(CallInitication());
	}
}
