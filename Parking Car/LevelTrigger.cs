using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelTrigger : MonoBehaviour {

    public GameObject lvl1;
    public GameObject lvl2;
    public GameObject lvl3;
    public GameObject lvl4;
    public GameObject lvl5;
    public GameObject lvl6;
    public GameObject lvl7;
    public GameObject lvl8;
    public GameObject lvl9;
    public GameObject lvl10;
    private bool procesandoColision = false;
    public GameObject choqueReprod;
    [SerializeField]
    Text Texto;
    [SerializeField]
    CustomTRackerA scriptTrigger;

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "autoEstacionamiento" && procesandoColision == false)
        {
            choqueReprod.gameObject.SetActive(false);
            procesandoColision = true;
            Texto.text = "Muy bien!!";
            if (lvl10.gameObject.activeSelf==true)
            {
                Texto.text = "Felicitaciones, Ganaste!! \n Repeti los niveles o seguí explorando!".ToString();
                Invoke("NextLevel", 5f);
            }
            else
            Invoke("NextLevel", 1f);
        }

    }

    private void NextLevel()
    {
        if (lvl10.gameObject.activeSelf == true)
        {
             lvl10.gameObject.SetActive(false);
             lvl1.gameObject.SetActive(true);
            Texto.text = "Nivel 1".ToString();
            procesandoColision = false;
            choqueReprod.gameObject.SetActive(true);
        }
        else
        {
            if (lvl9.gameObject.activeSelf == true)
            {
                lvl9.gameObject.SetActive(false);
                lvl10.gameObject.SetActive(true);
                Texto.text = "Nivel 10".ToString();
                procesandoColision = false;
                choqueReprod.gameObject.SetActive(true);
            }
            if (lvl8.gameObject.activeSelf == true)
            {
                lvl8.gameObject.SetActive(false);
                lvl9.gameObject.SetActive(true);
                Texto.text = "Nivel 9 ".ToString();
                procesandoColision = false;
                choqueReprod.gameObject.SetActive(true);
            }
            if (lvl7.gameObject.activeSelf == true)
            {
                lvl7.gameObject.SetActive(false);
                lvl8.gameObject.SetActive(true);
                Texto.text = "Nivel 8".ToString();
                procesandoColision = false;
                choqueReprod.gameObject.SetActive(true);
            }
            if (lvl6.gameObject.activeSelf == true)
            {
                lvl6.gameObject.SetActive(false);
                lvl7.gameObject.SetActive(true);
                Texto.text = "Nivel 7".ToString();
                procesandoColision = false;
                choqueReprod.gameObject.SetActive(true);
            }
            if (lvl5.gameObject.activeSelf == true)
            {
                lvl5.gameObject.SetActive(false);
                lvl6.gameObject.SetActive(true);
                Texto.text = "Nivel 6".ToString();
                procesandoColision = false;
                choqueReprod.gameObject.SetActive(true);
            }
            if (lvl4.gameObject.activeSelf == true)
            {
                lvl4.gameObject.SetActive(false); //NIVEL DEL NPC
                // NPC.gameObject.SetActive(true);
                lvl5.gameObject.SetActive(true);
                Texto.text = "Nivel 5".ToString();
                // Texto.text = "Presiona en el personaje \n para interactuar".ToString();
                procesandoColision = false;
                choqueReprod.gameObject.SetActive(true);
            }
            if (lvl3.gameObject.activeSelf == true)
            {
                lvl3.gameObject.SetActive(false);
                lvl4.gameObject.SetActive(true);
                Texto.text = "Nivel 4".ToString();
                procesandoColision = false;
                choqueReprod.gameObject.SetActive(true);
            }
            if (lvl2.gameObject.activeSelf == true)
            {
                lvl2.gameObject.SetActive(false);
                lvl3.gameObject.SetActive(true);
                Texto.text = "Nivel 3".ToString();
                procesandoColision = false;
                choqueReprod.gameObject.SetActive(true);
            }
            if (lvl1.gameObject.activeSelf == true)
            {
                Texto.text = "Nivel 2".ToString();
                lvl1.gameObject.SetActive(false);
                lvl2.gameObject.SetActive(true);
                procesandoColision = false;
                choqueReprod.gameObject.SetActive(true);
            }
        }
        scriptTrigger.setGO();
    }
}
