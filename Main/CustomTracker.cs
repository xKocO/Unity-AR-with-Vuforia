using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomTracker : DefaultTrackableEventHandler {

    [SerializeField]
    GameObject go;
    [SerializeField]
    GameObject screenText;
    [SerializeField]
    GameObject TurnOffButton;

	protected override void Start () {
        base.Start();
	}

    protected override void OnTrackingFound()
    {
        base.OnTrackingFound();
        go.SetActive(true);
        screenText.SetActive(false);
        TurnOffButton.SetActive(true);
    }

    protected override void OnTrackingLost()
    {
        base.OnTrackingLost();
        go.SetActive(false);
        screenText.SetActive(true);
        TurnOffButton.SetActive(false);
    }

    public void TurnOff(){
        if (go.gameObject.activeSelf == true) {
                this.gameObject.SetActive(false);
        }
    }
}
