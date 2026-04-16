using UnityEngine;

public class BackgroundLoop : MonoBehaviour
{
    private float width;
    private Transform cam;

    private void Start()
    {
        cam = Camera.main.transform;
        width = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    private void Update()
    {
        float distance = cam.position.x - transform.position.x;

        if (distance >= width)
        {
            transform.position += new Vector3(width * 2, 0, 0);
        }

        else if (distance <= -width)
        {
            transform.position -= new Vector3(width * 2, 0, 0);
        }
    }
}