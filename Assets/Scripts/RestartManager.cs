using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class SceneRestartManager : MonoBehaviour
{
    public float restartCooldown = 3f; // Cooldown time before restarting the scene
    public List<GameObject> restartObjects; // List of objects whose deactivation triggers scene restart

    private bool isRestarting = false; // Flag to prevent multiple restarts
    private float restartTimer = 0f; // Timer for cooldown

    void Update()
    {
        // Check if scene restart is triggered
        if (!isRestarting && ShouldRestartScene())
        {
            StartRestartCooldown();
        }

        // Update restart cooldown timer
        if (isRestarting)
        {
            restartTimer -= Time.deltaTime;
            if (restartTimer <= 0f)
            {
                RestartScene();
            }
        }
    }

    bool ShouldRestartScene()
    {
        foreach (GameObject obj in restartObjects)
        {
            if (!obj.activeSelf)
            {
                return true;
            }
        }
        return false;
    }

    void StartRestartCooldown()
    {
        isRestarting = true;
        restartTimer = restartCooldown;
    }

    void RestartScene()
    {
        // Restart the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        isRestarting = false;
    }
}
