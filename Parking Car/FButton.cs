using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FButton : MonoBehaviour {
    public static float Forward = 0f;
    public static bool pressF;
    
    public void OnPointerDown()
    {
        FButton.Forward = 1f;
        pressF = true;
    }
    public void OnPointerUp()
    {
        FButton.Forward = 0f;
        pressF = false;
    }
}
