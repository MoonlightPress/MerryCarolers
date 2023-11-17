using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MerrimentController : MonoBehaviour
{

    private static readonly float MinMerriment = 0;
    public static readonly float MaxMerriment = 1000;

    public static float CurrentMerriment { get; private set; }

    // Merriment is always increasing by multiples of this amount per second.
    public static float baseRate = 1f;
    // The current true rate at which merriment is increasing per second.
    private static float Rate = baseRate;

    private void Start()
    {
        CurrentMerriment = MinMerriment;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(
            $"Current merriment: {CurrentMerriment}" +
            $", " +
            $"rate: {Rate}"
        );

        UpdateRate();

        CurrentMerriment = Mathf.MoveTowards(CurrentMerriment, MaxMerriment, Rate * Time.deltaTime);
    }

    // Immediately increase Merriment by a given amount up to the max. E.g., for candies.
    public static void IncreaseMerriment(float amount)
    {
        float TargetMerriment = CurrentMerriment + amount;
        CurrentMerriment = Mathf.Clamp(TargetMerriment,
                                       MinMerriment,
                                       MaxMerriment);
    }

    private void UpdateRate()
    {
        Rate = baseRate + CarolerController.CarolerCount * baseRate;
    }
}
