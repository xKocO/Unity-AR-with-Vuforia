using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleGO : MonoBehaviour {

    [SerializeField]
    GameObject  UI;
    [SerializeField]
    Text Texto;
    LevelData levelData = new LevelData();

    void OnEnable()
    {
        if (levelData.setPuzzleLevel == 0) {
            Texto.text = "Arrastrá la pelotita \n para encontrar la salida";
        }
        else if (levelData.setPuzzleLevel == 4) {
            Texto.text = "Presiona en el personaje /n para interactuar";
        }
        else {
            Texto.text = "Nivel" + " " + (1 + levelData.setPuzzleLevel).ToString();
        }
        UI.SetActive(true);
    }

    void OnDisable() {
        UI.SetActive(false);
    }
}
