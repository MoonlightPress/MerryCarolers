using TMPro;
using UnityEngine;

public class VictoryController : MonoBehaviour
{
    public static bool IsPlayerVictorious = false;

    // Update is called once per frame
    void Update()
    {
        if (IsPlayerVictorious)
        {
            DisplayVictoryText();
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

    private void DisplayVictoryText()
    {
        Debug.Log("Winner winner chicken dinner");

        TextMeshProUGUI victory = GameObject.Find("VictoryUI").GetComponent<TextMeshProUGUI>();
        if (!victory)
        {
            Debug.Log("Problem with victory text");
            return;
        }

        string message = @"You win!

Happy Holidays!";

        victory.SetText(message);
    }
}
