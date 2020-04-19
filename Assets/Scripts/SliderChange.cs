using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderChange : MonoBehaviour
{
    public void sliderChange(float newValue)
    {
        PlayerSettings.mouseSensitivity = newValue;
    }
}
