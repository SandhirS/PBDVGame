using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class LosingScreen : MonoBehaviour
{
    public Rigidbody[] cars; // Array to hold the Rigidbody components of the cars
    public Text[] rankingTexts; // Array to hold the Text components for the rankings

    void Update()
    {
        // Ensure there are cars to rank and ranking texts available
        if (cars.Length == 0 || rankingTexts.Length == 0) return;

        // Sort the cars based on their distance traveled along the z-axis
        var sortedCars = cars.OrderByDescending(car => car.position.z).ToArray();

        // Reverse the rankingTexts array to ensure the 1st place is at the top
        var reversedRankingTexts = rankingTexts.Reverse().ToArray();

        // Update the ranking texts, but only up to the minimum of cars or rankingTexts length
        int count = Mathf.Min(sortedCars.Length, rankingTexts.Length);

        for (int i = 0; i < count; i++)
        {
            reversedRankingTexts[i].text = $"{i + 1}{GetOrdinal(i + 1)} Place: {sortedCars[i].name}";
        }

        // Clear any remaining ranking texts if there are more texts than cars
        for (int i = count; i < rankingTexts.Length; i++)
        {
            reversedRankingTexts[i].text = "";
        }
    }

    // Helper function to get ordinal suffix
    string GetOrdinal(int number)
    {
        if (number <= 0) return string.Empty;
        switch (number % 100)
        {
            case 11:
            case 12:
            case 13:
                return "th";
        }
        switch (number % 10)
        {
            case 1:
                return "st";
            case 2:
                return "nd";
            case 3:
                return "rd";
            default:
                return "th";
        }
    }
}