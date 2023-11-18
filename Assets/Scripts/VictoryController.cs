using UnityEngine;

public class VictoryController : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (IsPlayerVictorious())
        {
            Debug.Log("Player wins!");
        }
    }

    private bool IsPlayerVictorious()
    {
        return MerrimentController.IsMerrimentMaxedOut() && CarolerController.AreAllCarolersCollected();
    }
}
