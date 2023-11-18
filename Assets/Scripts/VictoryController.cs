using UnityEngine;

public class VictoryController : MonoBehaviour
{
    public static bool IsPlayerVictorious = false;

    // Update is called once per frame
    void Update()
    {
        if (IsPlayerVictorious)
        {
            return;
        }

        if (CheckPlayerVictorious())
        {
            IsPlayerVictorious = true;
            Debug.Log("Player wins!");
        }
    }

    private bool CheckPlayerVictorious()
    {
        return MerrimentController.IsMerrimentMaxedOut() && CarolerController.AreAllCarolersCollected();
    }
}
