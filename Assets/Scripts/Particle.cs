using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Particle : MonoBehaviour {
	public Material defaultMaterial;
	public Material lightingMaterial;
	private SpriteRenderer spriteRenderer;
	private Rigidbody2D rigid;
	private Camera camera;
	float time = 0;
	float speed = 1;
	float lifeTime = 0;
	// Use this for initialization
	void Start () {
		camera = Camera.main;
		rigid = GetComponent<Rigidbody2D> ();
		spriteRenderer = GetComponent<SpriteRenderer> ();
	}

	bool getSeen(){
		bool hasSeen = Vector3.Distance (this.transform.position, camera.transform.position) < 30;
		return hasSeen;
	}

	void Update () {
		if (getSeen()) {
			rigid.simulated = true;
		} else {
			rigid.simulated = false;
			return;
		}
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
		if (other.gameObject.tag == "echo") {
			spriteRenderer.material = defaultMaterial;
			time = 0;
			speed = 1;
			lifeTime = 3f;
		}
	}
}
