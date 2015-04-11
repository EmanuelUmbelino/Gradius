using UnityEngine;
using System.Collections;

public class Choose_YouLose : MonoBehaviour {

	public static string Options;
	public GameObject Select_YouLose;
	bool rodando;

	void Start ()
	{
        ScoreManager.Dyes = 0;
		Options = "Try Again";
		rodando = false;
	}
	
	private void Select()
	{
		if (!rodando)
		{
			if (Input.GetAxis("Player_V") > 0) 
			{ 
				Options = "Try Again"; 
			}
			if (Input.GetAxis("Player_V") < 0) 
			{ 
				Options = "Quit"; 
			}
		}
		
		if (Options.Equals("Try Again")) 
		{ 
			Select_YouLose.transform.position = new Vector3(-0.39f, 0.78f, -9.01f); 
		}
		if (Options.Equals("Quit")) 
		{ 
			Select_YouLose.transform.position = new Vector3(-0.39f, 0.58f, -9.01f); 
		}
	}
	
	IEnumerator CallInitication()
	{
		yield return new WaitForSeconds(1);
		if (Input.GetAxis("Player_Fire") > 0 && Options.Equals("Try Again")) 
		{ 
			Application.LoadLevel ("InGame");
			rodando = true; 
		}
		if (Input.GetAxis("Player_Fire") > 0 && Options.Equals("Quit")) 
		{ 
			Application.LoadLevel ("Menu");
			rodando = true; 
		}
	}
	
	void Update () 
	{
		Select();
		StartCoroutine(CallInitication());
	}
}
