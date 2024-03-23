using UnityEngine;

public class RocketController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 100f;
    public float maxSpeed = 10f;
    public float tiltAngle = 45f;

    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.mass = 1f; // Set mass to 1 to avoid unwanted drag
        rb.drag = 0f; // Set drag to 0 to minimize air resistance
    }

    void Update()
    {
        // Get the user's input for movement
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Calculate the rotation and tilt based on input
        float rotation = moveHorizontal * rotationSpeed * Time.deltaTime;
        float tilt = -moveVertical * tiltAngle;

        // Rotate the rocket
        transform.Rotate(Vector3.up * rotation);

        // Tilt the rocket
        transform.rotation = Quaternion.Euler(tilt, transform.rotation.eulerAngles.y, 0f);

        // Calculate forward vector based on current rotation
        Vector3 forwardDirection = transform.forward;

        // Calculate the velocity change based on the input and acceleration
        Vector3 velocityChange = forwardDirection * maxSpeed * moveSpeed * Time.deltaTime;

        // Apply the velocity change to the rigidbody
        rb.velocity += velocityChange;

        // Clamp the velocity to ensure it doesn't exceed the maximum speed
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
    }
}
