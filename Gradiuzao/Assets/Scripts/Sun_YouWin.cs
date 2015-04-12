using UnityEngine;
using System.Collections;

public class Sun_YouWin : MonoBehaviour {

	public LensFlare solzao;
	void Start () 
	{
	}
	

	void Update () 
	{
		solzao.brightness -= 0.1f;
		if (solzao.brightness <= 1.3f) 
		{
			solzao.brightness = 1.3f;
		}
	}
}
