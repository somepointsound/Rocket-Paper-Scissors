using UnityEngine;

public class RockPaperScissorsController : MonoBehaviour
{
    public GameObject[] player1RockAssets;
    public GameObject[] player1PaperAssets;
    public GameObject[] player1ScissorsAssets;

    public GameObject[] player2RockAssets;
    public GameObject[] player2PaperAssets;
    public GameObject[] player2ScissorsAssets;

    void Update()
    {
        // Check for player 1 inputs
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ActivateAsset(player1RockAssets);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ActivateAsset(player1PaperAssets);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ActivateAsset(player1ScissorsAssets);
        }

        // Check for player 2 inputs
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            ActivateAsset(player2RockAssets);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            ActivateAsset(player2PaperAssets);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            ActivateAsset(player2ScissorsAssets);
        }
    }

    void ActivateAsset(GameObject[] assets)
    {
        // Activate the appropriate asset for the player
        foreach (var asset in assets)
        {
            if (!asset.activeSelf)
            {
                asset.SetActive(true);
                break;
            }
        }
    }
}
