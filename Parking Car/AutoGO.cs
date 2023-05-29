using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AutoGO : MonoBehaviour {

    [SerializeField]
    GameObject UI;
    [SerializeField]
    Text Texto;
    LevelData LD = new LevelData();


    void OnEnable()
    {
        if (LD.setAutoLevel == 0)
        {
            Texto.text = "Estacioná el auto en la zona \n marcada, evitando chocar \n con los obstáculos";
        } else {
            Texto.text = "Nivel" + " " + (1 + LD.setAutoLevel).ToString();
        }
        UI.SetActive(true);
    }

    void OnDisable()
    {
        UI.SetActive(false);
    }
}
