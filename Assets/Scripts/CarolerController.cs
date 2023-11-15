using UnityEngine;
using System.Linq;

public class CarolerController : MonoBehaviour
{
    public static int CarolerCount { get; private set; } = 0;

    // Update is called once per frame
    void Update()
    {
        CarolerCount = GetActiveCarolerCount();
    }

    private int GetActiveCarolerCount()
    {
        Caroler[] carolers = FindObjectsOfType<Caroler>();

        return carolers.Where(c => c.isActive).Count();
    }
}
