using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speedo : MonoBehaviour
{
    public Rigidbody target;

    public float maxSpeed = 240f; // The maximum speed of the target ** IN KM/H **

    public float minSpeedArrowAngle;
    public float maxSpeedArrowAngle;

    [Header("UI")]

    public RectTransform arrow; // The arrow in the speedometer

    private float speed = 0.0f;
    private void Update()
    {

        speed = target.velocity.magnitude * 3.6f;


        if (arrow != null)
            arrow.localEulerAngles =
                new Vector3(0, 0, Mathf.Lerp(minSpeedArrowAngle, maxSpeedArrowAngle, speed / maxSpeed));
    }
}