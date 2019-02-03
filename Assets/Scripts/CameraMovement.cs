using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target;
    public GameObject player;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    public float shakeDuration = 0f;

    // A measure of magnitude for the shake. Tweak based on your preference
    private float shakeMagnitude = 0.5f;

    // A measure of how quickly the shake effect should evaporate
    private float dampingSpeed = 2.0f;

    private void FixedUpdate()
    {
        
    }

    private void Update()
    {
        if (player.transform.position.x >= -273.3131 && player.transform.position.x <= 530)
        {
            Vector3 desiredPosition = new Vector3(target.position.x, transform.position.y) + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }
        else if (player.transform.position.x > 530)
        {
            Vector3 desiredPosition = new Vector3(target.position.x, target.position.y) + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }
    }
}

