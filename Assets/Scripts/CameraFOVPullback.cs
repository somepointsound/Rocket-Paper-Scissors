using UnityEngine;

public class ZoomCamera : MonoBehaviour
{
    public Camera cam; // Reference to the camera component
    public float minFOV = 10f; // Minimum field of view
    public float zoomSpeed = 1f; // Speed of zooming

    void Update()
    {
        // Decrease the FOV over time
        float newFOV = cam.fieldOfView - zoomSpeed * Time.deltaTime;

        // Clamp the FOV to the minimum value
        newFOV = Mathf.Max(newFOV, minFOV);

        // Set the camera's field of view to the new value
        cam.fieldOfView = newFOV;
    }
}
