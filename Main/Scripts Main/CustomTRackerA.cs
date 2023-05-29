using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomTRackerA : DefaultTrackableEventHandler
{
    [SerializeField]
    GameObject go , control;
    [SerializeField]
    GameObject screenText;
    [SerializeField]
    GameObject TurnOffButton;
    [SerializeField]
    List<GameObject> niveles;
    LevelData levelData = new LevelData();

    protected override void Start()
    {
        base.Start();
    }

    protected override void OnTrackingFound()
    {
        base.OnTrackingFound();
        go = niveles[levelData.setAutoLevel];
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
        levelData.setAutoLevel = 0;
        foreach (GameObject nivel in niveles)
        {
            if (nivel.activeSelf == true)
            {
                go = niveles[levelData.setAutoLevel];
                break;
            }
            else
            {
                levelData.setAutoLevel++;
            }
        }
    }

    public void TurnOff()
    {
        go.GetComponentInChildren<AudioSource>().volume = 0;
        Invoke("heyhey", 0.2f);
    }

    public void heyhey() {
        if (go.gameObject.activeSelf == true)
        {
            this.gameObject.SetActive(false);
        }
    }
}
