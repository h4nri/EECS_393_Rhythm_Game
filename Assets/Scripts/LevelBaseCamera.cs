using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBaseCamera : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
            print(ray);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100))
            {
                SphereCollider coll = hit.collider as SphereCollider;
                if (coll != null) 
                {
                    Destroy(coll.gameObject);
                }
            }


        }
    }
}
