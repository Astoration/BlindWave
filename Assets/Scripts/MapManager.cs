using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour {
	public GameObject[] particles;
	public int density = 100;
	public GameObject left,right,top,bottom;
	// Use this for initialization
	void Start () {
		initializeMap ();
	}

	void initializeMap(){
		for (float y = top.transform.position.y; y < bottom.transform.position; y += 1) {
			for (int i = 0; i < density; i++) {
				float x = Random.Range (left.transform.position.x, right.transform.position.x);
				GameObject particle = Instantiate (particles [Random.Range (0, 2)]);
				particle.transform.position = Vector2 (x, y);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
