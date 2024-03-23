using UnityEngine;

public class RPSAssetCollisionManager : MonoBehaviour
{
    public GameObject[] player1RockAssets;
    public GameObject[] player1PaperAssets;
    public GameObject[] player1ScissorsAssets;

    public GameObject[] player2RockAssets;
    public GameObject[] player2PaperAssets;
    public GameObject[] player2ScissorsAssets;

    public GameObject replacementGameObject; // Game object to activate on disable

    void OnCollisionEnter(Collision collision)
    {
        GameObject player1Object = collision.gameObject;
        GameObject player2Object = gameObject;

        // Check if both players choose the same game object
        if (ArrayContainsObject(player1RockAssets, player1Object) && ArrayContainsObject(player2RockAssets, player2Object))
        {
            DeactivateAsset(player1Object);
            DeactivateAsset(player2Object);
        }
        else if (ArrayContainsObject(player1PaperAssets, player1Object) && ArrayContainsObject(player2PaperAssets, player2Object))
        {
            DeactivateAsset(player1Object);
            DeactivateAsset(player2Object);
        }
        else if (ArrayContainsObject(player1ScissorsAssets, player1Object) && ArrayContainsObject(player2ScissorsAssets, player2Object))
        {
            DeactivateAsset(player1Object);
            DeactivateAsset(player2Object);
        }
        // Otherwise, perform the usual logic
        else if (ArrayContainsObject(player1RockAssets, player1Object))
        {
            if (ArrayContainsObject(player2ScissorsAssets, player2Object))
            {
                DeactivateAsset(player2Object);
            }
        }
        else if (ArrayContainsObject(player1PaperAssets, player1Object))
        {
            if (ArrayContainsObject(player2RockAssets, player2Object))
            {
                DeactivateAsset(player2Object);
            }
        }
        else if (ArrayContainsObject(player1ScissorsAssets, player1Object))
        {
            if (ArrayContainsObject(player2PaperAssets, player2Object))
            {
                DeactivateAsset(player2Object);
            }
        }
        // Reverse logic for player 2's assets deactivating player 1's assets
        else if (ArrayContainsObject(player2RockAssets, player2Object))
        {
            if (ArrayContainsObject(player1ScissorsAssets, player1Object))
            {
                DeactivateAsset(player1Object);
            }
        }
        else if (ArrayContainsObject(player2PaperAssets, player2Object))
        {
            if (ArrayContainsObject(player1RockAssets, player1Object))
            {
                DeactivateAsset(player1Object);
            }
        }
        else if (ArrayContainsObject(player2ScissorsAssets, player2Object))
        {
            if (ArrayContainsObject(player1PaperAssets, player1Object))
            {
                DeactivateAsset(player1Object);
            }
        }
    }

    bool ArrayContainsObject(GameObject[] array, GameObject obj)
    {
        foreach (var item in array)
        {
            if (item == obj)
            {
                return true;
            }
        }
        return false;
    }

    void DeactivateAsset(GameObject obj)
    {
        // Deactivate the provided game object
        if (obj.activeSelf)
        {
            obj.SetActive(false);
        }
    }

    void OnDisable()
    {
        // Activate the replacement game object when this object is disabled
        if (replacementGameObject != null)
        {
            replacementGameObject.SetActive(true);
        }
    }
}