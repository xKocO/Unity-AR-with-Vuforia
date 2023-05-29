using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LButton : MonoBehaviour {

    public static float Left = 0f;
    public static bool pressL;

    public void OnPointerDown()
    {
       LButton.Left = 1f;
        pressL = true;
    }
    public void OnPointerUp()
    {
       LButton.Left = 0f;
        pressL = false;
    }
}
