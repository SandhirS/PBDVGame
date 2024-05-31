using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class RankingScreen : MonoBehaviour
{
    public Rigidbody[] cars; 
    public Text[] rankingTexts; 

    void Update()
    {
        
        if (cars.Length == 0 || rankingTexts.Length == 0) return;

        
        var sortedCars = cars.OrderByDescending(car => car.position.z).ToArray();

        
        var reversedRankingTexts = rankingTexts.Reverse().ToArray();

        
        int count = Mathf.Min(sortedCars.Length, rankingTexts.Length);

        for (int i = 0; i < count; i++)
        {
            reversedRankingTexts[i].text = $"{i + 1}{GetOrdinal(i + 1)} Place: {sortedCars[i].name}";
        }

        
        for (int i = count; i < rankingTexts.Length; i++)
        {
            reversedRankingTexts[i].text = "";
        }
    }

    
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
