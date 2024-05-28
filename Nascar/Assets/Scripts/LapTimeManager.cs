using UnityEngine;
using TMPro; // Import TextMeshPro namespace
using UnityEngine.UI;

public class LapTimeManager : MonoBehaviour
{
    public static int MinuteCount;
    public static int SecondCount;
    public static float MilliCount;
    public static string MilliDisplay;

    public GameObject MinuteBox;
    public GameObject SecondBox;
    public GameObject MilliBox;

    void Start()
    {
        // Log the assignment of the GameObjects
        Debug.Log("MinuteBox assigned: " + (MinuteBox != null));
        Debug.Log("SecondBox assigned: " + (SecondBox != null));
        Debug.Log("MilliBox assigned: " + (MilliBox != null));

        // Check if the Text components are assigned correctly
        if (MinuteBox != null && MinuteBox.GetComponent<TextMeshProUGUI>() == null)
        {
            Debug.LogError("MinuteBox does not have a TextMeshProUGUI component.");
        }
        if (SecondBox != null && SecondBox.GetComponent<TextMeshProUGUI>() == null)
        {
            Debug.LogError("SecondBox does not have a TextMeshProUGUI component.");
        }
        if (MilliBox != null && MilliBox.GetComponent<TextMeshProUGUI>() == null)
        {
            Debug.LogError("MilliBox does not have a TextMeshProUGUI component.");
        }
    }

    void Update()
    {
        MilliCount += Time.deltaTime * 10;
        MilliDisplay = MilliCount.ToString("F0");

        // Update MilliBox text if available
        if (MilliBox != null)
        {
            TextMeshProUGUI milliText = MilliBox.GetComponent<TextMeshProUGUI>();
            if (milliText != null)
            {
                milliText.text = MilliDisplay;
            }
            else
            {
                Debug.LogError("MilliBox does not have a TextMeshProUGUI component.");
            }
        }

        if (MilliCount >= 10)
        {
            MilliCount = 0;
            SecondCount += 1;
        }

        // Update SecondBox text based on SecondCount value
        if (SecondBox != null)
        {
            TextMeshProUGUI secondText = SecondBox.GetComponent<TextMeshProUGUI>();
            if (secondText != null)
            {
                if (SecondCount <= 9)
                {
                    secondText.text = "0" + SecondCount + ".";
                }
                else
                {
                    secondText.text = SecondCount + ".";
                }
            }
            else
            {
                Debug.LogError("SecondBox does not have a TextMeshProUGUI component.");
            }
        }

        if (SecondCount >= 60)
        {
            SecondCount = 0;
            MinuteCount += 1;
        }

        // Update MinuteBox text based on MinuteCount value
        if (MinuteBox != null)
        {
            TextMeshProUGUI minuteText = MinuteBox.GetComponent<TextMeshProUGUI>();
            if (minuteText != null)
            {
                if (MinuteCount <= 9)
                {
                    minuteText.text = "0" + MinuteCount + ":";
                }
                else
                {
                    minuteText.text = MinuteCount + ":";
                }
            }
            else
            {
                Debug.LogError("MinuteBox does not have a TextMeshProUGUI component.");
            }
        }
    }
}
