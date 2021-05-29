using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SlidingNumber : MonoBehaviour
{
    public Text numberText;
    public float animationTime = 1.5f;
    public float startNumber;

    private float desiredNumber, initialNumber, currentNumber;

    public void SetNumber(float value)
    {
        initialNumber = currentNumber;
        desiredNumber = value;
    }

    public void AddToNumber(float value)
    {
        initialNumber = currentNumber;
        desiredNumber += value;
    }

    public void Update()
    {
        if (currentNumber != desiredNumber)
        {
            if (initialNumber < desiredNumber)
            {
                currentNumber += (animationTime * Time.deltaTime) * ( desiredNumber - initialNumber);
                if (currentNumber >= desiredNumber)
                    currentNumber = desiredNumber;                
            }
            else
            {
                currentNumber -= (animationTime * Time.deltaTime) * (initialNumber - desiredNumber);
                if (currentNumber <= desiredNumber)
                    currentNumber = desiredNumber;
            }
        }

        numberText.text = currentNumber.ToString("0");
    }
}
