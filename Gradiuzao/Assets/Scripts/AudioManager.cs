using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour 
{

    public Animator Fade;

	void Start () 
    {
	    
	}

    IEnumerator CallInitication()
    {
        yield return new WaitForSeconds(2);
        Application.LoadLevel("InGame");
    }

	void Update () 
    {
        if (Fade.GetInteger("AnimationStatus") == 1) { this.audio.volume -= 0.01f; StartCoroutine(CallInitication()); }

	}
}
