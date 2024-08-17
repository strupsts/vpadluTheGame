using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class sliderElement
{
    public Sprite sliderImage;
    public float sliderTiming = 1.0f;

    public sliderElement(Sprite image, float timing)
    {
        sliderImage = image;
        sliderTiming = timing;
    }
}