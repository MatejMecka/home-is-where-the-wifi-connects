using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour
{

    // Transform of the GameObject you want to shake
    private Transform transform;

    // Desired duration of the shake effect
    public float shakeDuration = 0f;

    // A measure of magnitude for the shake. Tweak based on your preference
    private float shakeMagnitude = 0.5f;

    // A measure of how quickly the shake effect should evaporate
    private float dampingSpeed = 2.0f;

    // The initial position of the GameObject
    Vector3 initialPosition;

    void Awake()
    {
        if (transform == null)
        {
            transform = GetComponent(typeof(Transform)) as Transform;
        }
    }


    void OnEnable()
    {
        initialPosition = transform.localPosition;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            shakeDuration = 0.15f;

        }
        if (shakeDuration > 0)
        {
            transform.localPosition = initialPosition + Random.insideUnitSphere * shakeMagnitude;

            shakeDuration -= Time.deltaTime * dampingSpeed;
        }
        else
        {
            shakeDuration = 0f;
            transform.localPosition = initialPosition;
        }
    }
   
}