using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	public float speed = 5f;
	private Vector2 targetPoint;
	// Use this for initialization
	void Start () {
		targetPoint = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		moveControl ();
	}

	void moveControl(){
		Vector2 prePosition = transform.position, postPosition;
		#if UNITY_EDITOR
		if(Input.GetMouseButtonDown(0)){
			targetPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		}
		#else
		if(0<Input.touchCount){
			Touch touch = Input.touches[0];
			targetPoint = Camera.main.ScreenToWorldPoint(touch.position);
		}
		#endif
		#if UNITY_EDITOR
		var x = Input.GetAxis("Horizontal");
		var y = Input.GetAxis("Vertical");
		var axis = new Vector2(x,y);
		transform.Translate(axis * speed * Time.deltaTime);
		if(axis.magnitude != 0)
			targetPoint = transform.position;
		#endif
		#if UNITY_EDITOR
		if(axis.magnitude == 0)
		#endif
		transform.position = Vector2.MoveTowards (transform.position, targetPoint,speed*Time.deltaTime);
		postPosition = transform.position;
		Vector2 distanceToScreen = Camera.main.WorldToViewportPoint (transform.position);
		if (distanceToScreen.x < 0.1 || 0.9 < distanceToScreen.x
		   || distanceToScreen.y < 0.1 || 0.9 < distanceToScreen.y) {
			Vector2 movement = postPosition - prePosition;
			Camera.main.transform.Translate (movement);
		}
	}
}
