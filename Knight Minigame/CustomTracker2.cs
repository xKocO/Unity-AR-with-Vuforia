using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomTracker2 :  DefaultTrackableEventHandler {

    [SerializeField]
    bool monstruo;
    [SerializeField]
    GameObject objeto,canvas,desactivar;
    GameData GD = new GameData();
    [SerializeField]
    GameObject TurnOffButton;

    protected override void Start () {
        base.Start();
	}

    protected override void OnTrackingFound()
    {
        desactivar.SetActive(false);
        TurnOffButton.SetActive(true);
        if (!monstruo)
        {
            objeto.SetActive(true);
            canvas.SetActive(true);
            GD.Jugando = true;
            GD.puntaje = 0;
        }
        else if (monstruo && GD.Jugando == true) {
            objeto.SetActive(true);
            canvas.SetActive(true);
        }
    }

    protected override void OnTrackingLost()
    {
        desactivar.SetActive(true);
        if (!monstruo) {
            GD.Jugando = false;
        }
        objeto.SetActive(false);
        canvas.SetActive(false);
        TurnOffButton.SetActive(false);
    }

    public void TurnOff()
    {
        if (objeto.gameObject.activeSelf == true)
        {
            this.gameObject.SetActive(false);           
        }
    }
}
