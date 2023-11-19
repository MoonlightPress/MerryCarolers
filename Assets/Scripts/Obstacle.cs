using TMPro;
using UnityEngine;

/// <summary>
/// Each obstacle should have two colliders. 
/// One is smaller and NOT marked `isTrigger`, allowing it to provide the expected physics.
/// One is larger and marked `isTrigger`. It runs the script that disables the obstacle
/// if the player has enough carolers following them.
/// </summary>
public class Obstacle : MonoBehaviour
{
    public int carolersRequired;

    void Start()
    {
        TextMeshProUGUI requirement = gameObject.GetComponentInChildren<TextMeshProUGUI>();
        if (!requirement)
        {
            Debug.Log($"Problem with requirement of ${carolersRequired}");
            return;
        }

        requirement.SetText($"{carolersRequired}");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (CarolerController.ActiveCarolerCount < carolersRequired)
        {
            return;
        }

        if (collision.transform.gameObject.name == "Player")
        {
            this.gameObject.SetActive(false);
        }
    }
}
