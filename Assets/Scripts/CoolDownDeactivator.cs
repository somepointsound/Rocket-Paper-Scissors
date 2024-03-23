using UnityEngine;

public class GameObjectDeactivator : MonoBehaviour
{
    public GameObject objectToDeactivate; // Reference to the GameObject to deactivate

    void Start()
    {
        // Check if the reference to the GameObject is set
        if (objectToDeactivate == null)
        {
            Debug.LogError("Please assign a GameObject to deactivate in the Inspector!");
            enabled = false; // Disable the script to prevent further errors
            return;
        }

        // Start the countdown to deactivate the GameObject
        Invoke("DeactivateObject", 5f); // Deactivate after 5 seconds
    }

    // Method to deactivate the specified GameObject
    void DeactivateObject()
    {
        // Check if the GameObject is active before deactivating it
        if (objectToDeactivate.activeSelf)
        {
            objectToDeactivate.SetActive(false);
        }
    }
}
