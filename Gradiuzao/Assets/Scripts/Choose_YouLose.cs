using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Choose_YouLose : MonoBehaviour {

	public static string Options;
	public GameObject Select_YouLose;
	public GameObject tryAgain;
	public GameObject quit;
	public GameObject scorePlayer1;
	public GameObject scorePlayer2;
	public GameObject textoScore2;
	bool rodando;

	void Start ()
	{
		ScoreManager.Dyes = 0;
		if (ScoreManager.ativado == false) 
		{
			textoScore2.GetComponent<Text> ().text = "";
			scorePlayer2.GetComponent<Text> ().text = "";
		} 
		else 
		{
			textoScore2.GetComponent<Text> ().text = "SCORE   PLAYER  2   :";
			string scoreplayer2 = ScoreManager.score2.ToString ();
			scorePlayer2.GetComponent<Text> ().text = scoreplayer2;
		}
		string scoreplayer1 = ScoreManager.score.ToString();
		scorePlayer1.GetComponent<Text>().text = scoreplayer1;
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
			Select_YouLose.transform.position = new Vector3(-0.25f, 0.78f, -9.01f);
			//Select_YouLose.transform.localScale = new Vector3(tryAgain.transform.localScale.x,tryAgain.transform.localScale.y,tryAgain.transform.localScale.z);
		}
		if (Options.Equals("Quit")) 
		{ 
			Select_YouLose.transform.position = new Vector3(-0.09f, 0.58f, -9.01f); 
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
