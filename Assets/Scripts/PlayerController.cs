using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	public float speed = 5f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		moveControl ();
	}

	void moveControl(){
		#if UNITY_EDITOR
		var x = Input.GetAxis("Horizontal");
		var y = Input.GetAxis("Vertical");
		var axis = new Vector3(x,y);
		transform.Translate(axis * speed * Time.deltaTime);
		#endif
	}
}
