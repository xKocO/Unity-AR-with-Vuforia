using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LabLvlTransfer : MonoBehaviour {

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
    public GameObject NPC;
    [SerializeField]
    GameObject pelota;
    [SerializeField]
    Text Texto;
    [SerializeField]
    private Vector3 posicionOriginal;
    [SerializeField]
    CustomTrackerP scriptTrigger;


    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag=="pelota")
        {
            Texto.text = "Buenísima!!";
            Invoke("nextLevel", 2.5f);
            print("HEY HEY");
        }

    }

    void OnDisable() {
        pelota.transform.localPosition = posicionOriginal;
    }


    private void nextLevel() {
        if (lvl10.gameObject.activeSelf == true)
        {
            lvl10.gameObject.SetActive(false);
            lvl1.gameObject.SetActive(true);
            Texto.text = "Felicitaciones, Ganaste!! \n Repeti los niveles o segui explorando!".ToString();
        }
        else
        {
            if (lvl9.gameObject.activeSelf == true)
            {
                lvl9.gameObject.SetActive(false);
                lvl10.gameObject.SetActive(true);
                Texto.text = "Nivel 10".ToString();

            }
            if (lvl8.gameObject.activeSelf == true)
            {
                lvl8.gameObject.SetActive(false);
                lvl9.gameObject.SetActive(true);
                Texto.text = "Nivel 9 ".ToString();
            }
            if (lvl7.gameObject.activeSelf == true)
            {
                lvl7.gameObject.SetActive(false);
                lvl8.gameObject.SetActive(true);
                Texto.text = "Nivel 8".ToString();
            }
            if (lvl6.gameObject.activeSelf == true)
            {
                lvl6.gameObject.SetActive(false);
                lvl7.gameObject.SetActive(true);
                Texto.text = "Nivel 7".ToString();
            }
            if (lvl5.gameObject.activeSelf == true)
            {
                lvl5.gameObject.SetActive(false);
                lvl6.gameObject.SetActive(true);
                Texto.text = "Nivel 6".ToString();
            }
            if (lvl4.gameObject.activeSelf == true)
            {
                lvl4.gameObject.SetActive(false); //NIVEL DEL NPC
                NPC.gameObject.SetActive(true);
                Texto.text = "Presiona en el personaje \n para interactuar".ToString();
            }
            if (lvl3.gameObject.activeSelf == true)
            {
                lvl3.gameObject.SetActive(false);
                lvl4.gameObject.SetActive(true);
                Texto.text = "Nivel 4".ToString();
            }
            if (lvl2.gameObject.activeSelf == true)
            {
                lvl2.gameObject.SetActive(false);
                lvl3.gameObject.SetActive(true);
                Texto.text = "Nivel 3".ToString();
            }
            if (lvl1.gameObject.activeSelf == true)
            {
                Texto.text = "Nivel 2".ToString();
                lvl1.gameObject.SetActive(false);
                lvl2.gameObject.SetActive(true);
            }

        }
        scriptTrigger.setGO();
    }
   
       
}
