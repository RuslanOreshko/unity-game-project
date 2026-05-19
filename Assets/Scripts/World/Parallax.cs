using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private float parallaxEffect = 0.5f;
    [SerializeField] private float parallaxEffectY = 0.8f; 

    private float lastCamX;
    private float lastCamY;

    private void Start()
    {
        lastCamX = cameraTransform.position.x;
        lastCamY = cameraTransform.position.y;
    }

    private void LateUpdate()
    {
        float deltaX = cameraTransform.position.x - lastCamX;
        transform.position += new Vector3(deltaX * parallaxEffect, 0f, 0f);
        lastCamX = cameraTransform.position.x;

        float deltaY = cameraTransform.position.y - lastCamY;
        transform.position += new Vector3(0f, deltaY * parallaxEffectY, 0f);
        lastCamY = cameraTransform.position.y;
    }
}