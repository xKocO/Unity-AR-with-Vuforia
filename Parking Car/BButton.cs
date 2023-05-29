using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BButton : MonoBehaviour {
    public static float Back = 0f;
    public static bool pressB;
    public void OnPointerDown()
    {
        BButton.Back = 1f;
        pressB = true;
    }
    public void OnPointerUp()
    {
        BButton.Back = 0f;
        pressB = false;
    }
}
