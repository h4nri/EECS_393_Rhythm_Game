using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour {

    [SerializeField] private float speed;
    public GameObject link;
    public int visibleDistance;
    public string direction;

	private void Start()
    {
		GetComponent<SpriteRenderer>().enabled = false;
	}

	private void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y - (speed * Time.deltaTime), transform.position.z);

        if (transform.position.y <= visibleDistance)
        {
            GetComponent<SpriteRenderer>().enabled = true;
        }
    }
}
