using UnityEngine;

public class HeadBob : MonoBehaviour
{
    [SerializeField, Range(0f, 30f)] private float bobFrequency = 4.0f;
    [SerializeField, Range(0f, 0.1f)] private float bobAmplitude = 0.1f;
    public Rigidbody playerRigidbody;
    private Vector3 startPos;
    private float timer = 0.0f;

    void Start()
    {
        startPos = transform.localPosition;
    }

    void Update()
    {
        Vector3 velocity = playerRigidbody.velocity;
        float speed = new Vector3(velocity.x, 0, velocity.z).magnitude;

        if (speed > 0.1f)
        {
            timer += Time.deltaTime * bobFrequency * speed;
            float bobOffset = Mathf.Sin(timer) * bobAmplitude;
            transform.localPosition = startPos + new Vector3(0, bobOffset, 0);
        }
        else
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, startPos, Time.deltaTime * 5);
            timer = 0;
        }
    }
}
