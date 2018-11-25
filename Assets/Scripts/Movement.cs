using UnityEngine;

public class Movement : MonoBehaviour {

    private float speed;
    private float visibleDistance;

    private void Start()
    {
        GameManager gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        speed = gameManager.speed;
        visibleDistance = gameManager.visibleDistance;
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
