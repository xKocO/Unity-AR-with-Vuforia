using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomTrackerP : DefaultTrackableEventHandler
{
    [SerializeField]
    GameObject go, control;
    [SerializeField]
    GameObject screenText;
    [SerializeField]
    GameObject TurnOffButton;
    [SerializeField]
    List<GameObject> niveles;
    LevelData LevelData = new LevelData();

    protected override void Start()
    {
        base.Start();
    }

    protected override void OnTrackingFound()
    {
        base.OnTrackingFound();
        go = niveles[LevelData.setPuzzleLevel];
        go.SetActive(true);
        control.SetActive(true);
        screenText.SetActive(false);
        TurnOffButton.SetActive(true);
    }

    protected override void OnTrackingLost()
    {
        base.OnTrackingLost();
        go.SetActive(false);
        control.SetActive(false);
        screenText.SetActive(true);
        TurnOffButton.SetActive(false);
    }

    public void setGO()
    {
        LevelData.setPuzzleLevel = 0;
        foreach (GameObject nivel in niveles)
        {
            if (nivel.activeSelf == true)
            {
                go = niveles[LevelData.setPuzzleLevel];
                break;
            }
            else {
                LevelData.setPuzzleLevel++;
            }
        }
    }

    public void TurnOff()
    {
        if (go.gameObject.activeSelf == true)
        {
            this.gameObject.SetActive(false);
        }
    }
}


