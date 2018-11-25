using System;
using UnityEngine;

public class Link : MonoBehaviour {

	[SerializeField] private GameObject firstNote;
    [SerializeField] private GameObject secondNote;

    private void Start()
    {
        transform.localScale = new Vector3(transform.localScale.x, Math.Abs(firstNote.transform.position.x) - Math.Abs(secondNote.transform.position.x), transform.localScale.z);
        transform.position = new Vector3((firstNote.transform.position.x + secondNote.transform.position.x) / 2, 
            firstNote.transform.position.y, firstNote.transform.position.z);
    }
}
