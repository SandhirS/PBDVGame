using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class WinningScreen : MonoBehaviour
{
    public Rigidbody[] cars; // Array to hold the Rigidbody components of the cars
    public Text[] rankingTexts; // Array to hold the Text components for the rankings

    void Update()
    {
        // Sort the cars based on their distance traveled along the z-axis
        var sortedCars = cars.OrderByDescending(car => car.position.z).ToArray();

        // Update the ranking texts
        for (int i = 0; i < sortedCars.Length; i++)
        {
            rankingTexts[i].text = $"{i + 1}th Place: {sortedCars[i].name}";
        }
    }
}
