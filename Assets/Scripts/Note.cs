using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour {

	public GameObject link;
	Rigidbody2D rigidBody;
    public float speed;
    public int visibleDistance;
    public string direction;

    void Awake()
    {
		rigidBody = GetComponent<Rigidbody2D>();
	}

	void Start()
    {
		GetComponent<SpriteRenderer>().enabled = false;
		rigidBody.velocity = new Vector2(0.0f, -speed);
	}

	void Update()
    {
		if (transform.position.y <= visibleDistance)
        {
			GetComponent<SpriteRenderer>().enabled = true;
		}
	}
}
