using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScriptAsync : MonoBehaviour {


    public GameObject[] botonesmenu;
    public GameObject loading,atras;
    public GameObject Obj;
    public Slider Carga;
    public GameObject continuar;
    AsyncOperation asyncs;
    bool primeraCarga = true;

    public void ClickBoton ()
    {
        foreach (GameObject boton in botonesmenu) {
            boton.SetActive(false);
        }
        loading.SetActive(true);
        atras.SetActive(true);
        StartCoroutine(LoadYourAsyncScene());  
    }

    public void volver() {
        StopAllCoroutines();
        loading.SetActive(false);
        continuar.SetActive(false);
        atras.SetActive(false);
        foreach (GameObject boton in botonesmenu)
        {
            boton.SetActive(true);
        }
    }

    IEnumerator LoadYourAsyncScene()
    {
        if (primeraCarga) {
            asyncs = SceneManager.LoadSceneAsync(1);
            asyncs.allowSceneActivation = false;
            primeraCarga = false;
        }
        while (asyncs.isDone==false)
        {
            Carga.value = asyncs.progress;
            if (asyncs.progress>=0.9f)
            {           
                Carga.value = 1f;
                continuar.SetActive(true);
            }
            yield return null;
        }
    }

    public void Continuar()
    {
        primeraCarga = true;
        asyncs.allowSceneActivation = true;
    }

    public void Facebook()
    {
        Application.OpenURL("https://www.facebook.com/DefensoriaCba/");
    }

    public void Twitter()
    {
        Application.OpenURL("https://twitter.com/defensoriacba?lang=es");
    }

    public void Instagram()
    {
        Application.OpenURL("https://www.instagram.com/defensoriacba/?hl=es-la");
    }


}

