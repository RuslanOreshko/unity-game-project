using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private float parallaxEffect = 0.5f;

    private float lastCamX;

    private void Start()
    {
        lastCamX = cameraTransform.position.x;
    }

    private void LateUpdate()
    {
        float deltaX = cameraTransform.position.x - lastCamX;
        transform.position += new Vector3(deltaX * parallaxEffect, 0f, 0f);
        lastCamX = cameraTransform.position.x;
    }
}