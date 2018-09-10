using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour {

	public GameObject link;
	Rigidbody2D rigidBody;
	public int visibleDistance;
	public float speed;

	void Awake() {
		rigidBody = GetComponent<Rigidbody2D>();
	}

	void Start () {
		GetComponent<Renderer>().enabled = false;
		rigidBody.velocity = new Vector2 (0, -speed);
	}

	void Update () {
		if (transform.position.y <= visibleDistance) {
			GetComponent<Renderer> ().enabled = true;
		}
	}
}
