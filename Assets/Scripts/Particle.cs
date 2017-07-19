using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle : MonoBehaviour {
	public Material defaultMaterial;
	public Material lightingMaterial;
	private SpriteRenderer spriteRenderer;
	float time = 0;
	float speed = 1;
	float lifeTime = 0;
	// Use this for initialization
	void Start () {
		spriteRenderer = GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (lifeTime <= 0) {
			spriteRenderer.material = lightingMaterial;
			Color color = spriteRenderer.color;
			color.a = 1;
			spriteRenderer.color = color;
		} else {
			time += speed * Time.deltaTime;
			speed += Time.deltaTime;
			Color color = spriteRenderer.color;
			color.a = ((float)Mathf.Sin (time)) * 0.5f + 0.5f;
			spriteRenderer.color = color;
			lifeTime -= Time.deltaTime;
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		Debug.Log (other.gameObject.tag);
		if (other.gameObject.tag == "echo") {
			spriteRenderer.material = defaultMaterial;
			time = 0;
			speed = 1;
			lifeTime = 3f;
		}
	}
}
