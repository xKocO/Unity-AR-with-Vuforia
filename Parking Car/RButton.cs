using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RButton : MonoBehaviour {

    public static float Right = 0f;
    public static bool pressR;
    public void OnPointerDown()
    {
        RButton.Right = 1f;
        pressR = true;
    }
    public void OnPointerUp()
    {
        RButton.Right = 0f;
        pressR = false;
    }
}
