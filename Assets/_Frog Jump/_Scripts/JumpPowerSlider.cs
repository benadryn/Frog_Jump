using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class JumpPowerSlider : MonoBehaviour
{
    [SerializeField] private float maxPower = 15.0f;
    [SerializeField] private float minPower = 5.0f;
    [SerializeField] private float currentPower;
    [SerializeField] private Slider jumpSlider;
    [SerializeField] private Image sliderFill;
    [SerializeField] private float jumpSliderMultiplier = 1.2f;

    private void Start()
    {
        currentPower = minPower;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && GameManager.Instance.isGrounded && !GameManager.Instance.didFinish)
        {
            if (currentPower <= maxPower)
            {
                currentPower += Time.deltaTime * jumpSliderMultiplier;
                sliderFill.color = Color.Lerp(Color.green, Color.red, currentPower / maxPower);
            }
            jumpSlider.value = currentPower;
        }
        else
        {
            currentPower = minPower;
            jumpSlider.value = currentPower;
        }
    }
}
