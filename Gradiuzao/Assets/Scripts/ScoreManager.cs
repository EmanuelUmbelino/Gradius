using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour {

    public static float score = 0;
    public static float score2 = 0;
    public GameObject Texto;
    public GameObject Texto2;
    public static bool ativado;
    public static int Dyes = 0;
	// Use this for initialization
    void Start()
    {
        ativado = false;
        score = 0;
        score2 = 0;
	}
	
	// Update is called once per frame
	void Update () {
        Texto.GetComponent<Text>().text = "SCORE " + ScoreManager.score.ToString();
        if (ativado)
        {
            Texto2.GetComponent<Text>().text = ScoreManager.score2.ToString() + " SCORE";
            if (Dyes.Equals(2))
                Application.LoadLevel("GameOver");
        }
        else if (Dyes.Equals(1))
            Application.LoadLevel("GameOver");
	}
}
