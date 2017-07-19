using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Echo : MonoBehaviour {
	public float lifeTime;
	float speed = 1f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		lifeTime -= Time.deltaTime;
		transform.localScale = transform.localScale + speed * Time.deltaTime;
		if (lifeTime < 0)
			Destroy (this.gameObject);
	}
}
