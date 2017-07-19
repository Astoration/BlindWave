using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleSceneManager : MonoBehaviour {
	public GameObject difficultMenu, howto1, howto2;
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
		howto1.SetActive (false);
		howto2.SetActive (false);
	}

	public void startGame(int level){
		SceneManager.LoadScene ("InGameScene");
	}

	public void displayHowTo(){
		howto1.SetActive (true);
	}

	public void OnNext(){
		howto1.SetActive (false);
		howto2.SetActive (true);
	}
	public void OnFinish(){
		howto2.SetActive (false);
		difficultMenu.SetActive (true);
	}
}
