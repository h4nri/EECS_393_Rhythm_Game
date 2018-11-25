using UnityEngine;

public class HoldLine : MonoBehaviour {

    [HideInInspector] public float endpoint;
    public float length;
    [SerializeField] private GameObject note;

    private void Awake()
    {
        endpoint = 0.0f;
    }

    private void Start()
    {
        transform.localScale = new Vector3(transform.localScale.x, length, transform.localScale.z);
        transform.position = new Vector3(note.transform.position.x, note.transform.position.y + (length / 2), note.transform.position.z);
    }

    private void Update()
    {
        endpoint = transform.position.y - length / 2;
    }
}
