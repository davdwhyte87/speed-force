using UnityEngine;
using System.Collections;

public class link : MonoBehaviour {

	public void facebook(){
		Application.OpenURL ("https://www.facebook.com");
	}
	public void twitter(){
		Application.OpenURL ("https://twitter.com");
	}
	public void instagram(){
		Application.OpenURL ("https://www.instagram.com");
	}

  public void youtube(){
		Application.OpenURL ("https://www.youtube.com");
}
}
