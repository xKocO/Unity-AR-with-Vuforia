using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class KevinFix : MonoBehaviour {

    [SerializeField]
    private bool TestMode;
    [SerializeField]
    private Text textoUI;

    public void ButtonPress() {
        textoUI.text = "Cargando...";
        if (!TestMode) {
            Invoke("SceneLoad", 1f);
        }
    }

    private void SceneLoad() {
        SceneManager.LoadScene(1);
    }
}
