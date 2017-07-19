using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IngameManager : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void backToMenu(){
		SceneManager.LoadScene ("TitleScene");
	}
	public void replay(){
		SceneManager.LoadScene ("InGameScene");
	}
}
