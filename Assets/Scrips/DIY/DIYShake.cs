using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DIYShake : MonoBehaviour
{
    float accelerometerUpdateInterval = 1.0f / 60.0f;
    float lowPassKernelWidthInSeconds = 1.0f;
    float shakeDetectionThreshold = 2.0f;
    public float lowPassFilterFactor;
    public Vector3 lowPassValue;
    public GameObject menuIsShakeDIY;
    void Start()
    {
        lowPassFilterFactor = accelerometerUpdateInterval / lowPassKernelWidthInSeconds;
        shakeDetectionThreshold *= shakeDetectionThreshold;
        lowPassValue = Input.acceleration;
    }

    void Update()
    {
        if (DIYController.instance.countPressButtonFurits > 14)
        {
            menuIsShakeDIY.SetActive(true);
            Vector3 acceleration = Input.acceleration;
            lowPassValue = Vector3.Lerp(lowPassValue, acceleration, lowPassFilterFactor);
            Vector3 deltaAcceleration = acceleration - lowPassValue;
            if (deltaAcceleration.sqrMagnitude >= shakeDetectionThreshold)
            {
                menuIsShakeDIY.SetActive(false);
            }
        }
    }
}




