using System.Linq;
using UnityEngine;

public class CarolerController : MonoBehaviour
{
    private static int TotalCarolerCount;
    public static int ActiveCarolerCount { get; private set; } = 0;

    private void Start()
    {
        Caroler[] allCarolers = FindObjectsOfType<Caroler>();

        TotalCarolerCount = allCarolers.Length;
    }
    // Update is called once per frame
    void Update()
    {
        ActiveCarolerCount = GetActiveCarolerCount();
    }

    private int GetActiveCarolerCount()
    {
        Caroler[] carolers = FindObjectsOfType<Caroler>();

        return carolers.Where(c => c.isActive).Count();
    }

    public static bool AreAllCarolersCollected()
    {
        return TotalCarolerCount == ActiveCarolerCount;
    }
}
