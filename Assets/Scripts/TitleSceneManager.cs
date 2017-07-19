using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleSceneManager : MonoBehaviour {
	public GameObject difficultMenu;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void displayDifficultMenu(){
		difficultMenu.SetActive (true);
	}

	public void closeMenu(){
		difficultMenu.SetActive (false);
	}

	public void startGame(int level){
		SceneManager.LoadScene ("InGameScene");
	}
}
