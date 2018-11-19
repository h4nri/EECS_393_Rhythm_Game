using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Link : MonoBehaviour {

	[SerializeField] private GameObject firstNote;
    [SerializeField] private GameObject secondNote;
    [SerializeField] private float speed;
    [SerializeField] private int visibleDistance;

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
