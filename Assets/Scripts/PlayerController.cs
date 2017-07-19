﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	public float speed = 5f;
	private Vector2 targetPoint;
	public GameObject echo;
	private AudioClip mic;
	private const int buffer = 128;
	private string deviceName;
	private bool echoEnable = true;
	// Use this for initialization
	void Start () {
		targetPoint = transform.position;
		deviceName = Microphone.devices [0];
		mic = Microphone.Start(deviceName, true, 999, 44100);
	}

	void OnEnable()
	{
		mic = Microphone.Start(deviceName, true, 999, 44100);
	}

	void OnDisable()
	{
		Microphone.End (deviceName);
	}

	public void OnDestroy(){
		Microphone.End (deviceName);
	}
	
	// Update is called once per frame
	void Update () {
		moveControl ();
		echoControl ();
	}

	void echoControl(){
		float[] channelData = new float[buffer];
		int position = Microphone.GetPosition (deviceName) - (buffer + 1);
		if (position < 0)
			return;
		mic.GetData (channelData, position);
		float levelMax = 0;
		for (int i = 0; i < buffer; i++) {
			float wavePeak = channelData[i] * channelData[i];
			if (levelMax < wavePeak) {
				levelMax = wavePeak;
			}
		}
		#if UNITY_EDITOR
		if(Input.GetKeyDown(KeyCode.Space)){
			GameObject echoObject = Instantiate(echo,this.transform.position,Quaternion.identity);
			echoObject.GetComponent<Echo>().lifeTime = 2f;
		}
		#endif
		if (0.1 < levelMax && echoEnable) {
			GameObject echoObject = Instantiate(echo,this.transform.position,Quaternion.identity);
			echoObject.GetComponent<Echo>().lifeTime = levelMax*10;
			StartCoroutine (cooltime (levelMax * 10));
		}

	}

	IEnumerator cooltime(float time){
		echoEnable = false;
		yield return new WaitForSeconds (time);
		echoEnable = true;
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Particle") {
			coll.gameObject.GetComponent<SpriteRenderer> ().color = Color.red;
			Time.timeScale = 0;
		}
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
		if (distanceToScreen.x < 0.2 || 0.8 < distanceToScreen.x
		   || distanceToScreen.y < 0.2 || 0.8 < distanceToScreen.y) {
			Vector2 movement = postPosition - prePosition;
			Camera.main.transform.Translate (movement);
		}
	}
}
