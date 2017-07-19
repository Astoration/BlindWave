using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Echo : MonoBehaviour {
	public float lifeTime;
	float speed = 4f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		lifeTime -= Time.deltaTime;
		float scaleOut = speed * Time.deltaTime;
		transform.localScale = transform.localScale + new Vector3(scaleOut,scaleOut);
		if (lifeTime < 0)
			Destroy (this.gameObject);
	}
}
