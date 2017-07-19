using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour {
	public GameObject[] particles;
	public GameObject[] item;
	public GameObject goalPrefabs;
	public int density = 10;
	public GameObject left,right,top,bottom;
	// Use this for initialization
	void Start () {
		initializeMap ();
	}

	void initializeMap(){
		for (float y = bottom.transform.position.y; y < top.transform.position.y; y += 1000/density) {
			for (int i = 0; i < density; i++) {
				float x = Random.Range (left.transform.position.x, right.transform.position.x);
				Vector2 position = new Vector2 (x, y+Random.Range(-5f,5f));

				if (Vector2.Distance (Vector2.zero, position) < 5)
					continue;

				if (Random.Range (0f, 100f) < 10f) {
					GameObject particle = Instantiate (item [Random.Range (0, item.Length)]);
					particle.transform.position = position;
				} else {
					GameObject particle = Instantiate (particles [Random.Range (0, 6)]);
					particle.transform.position = position;
				}
			}
		}
		Vector2 pos = new Vector2 (Random.Range(left.transform.position.x,right.transform.position.x), Random.Range(bottom.transform.position.y,top.transform.position.y));
		int difficult = PlayerPrefs.GetInt ("difficult");
		while(20*difficult<Vector2.Distance(Vector2.zero,pos)){
			pos = new Vector2 (Random.Range(left.transform.position.x,right.transform.position.x), Random.Range(bottom.transform.position.y,top.transform.position.y));
		}
		GameObject goal = Instantiate (goalPrefabs);
		goal.transform.position = pos;

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
