using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextoScript : MonoBehaviour {

    [SerializeField]
    protected GameObject texto;
    [SerializeField]
    protected GameObject Tip;
    [SerializeField]
    protected AudioSource Beep;
    protected int x = 0;
    [SerializeField]
    protected int array;
    protected Animator ani;
    protected bool Paso = false, eleccion = false;
    [SerializeField]
    protected DialogueClass _dialogo;
    [SerializeField]
    protected GameObject[] Botones;
    [SerializeField]
    protected bool mouseMode;

    protected void Update()
    {

        for (int i = 0; i < Input.touchCount; ++i)
        {
            if (Input.GetTouch(i).phase == TouchPhase.Began)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(i).position);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
         
                    if (hit.collider.tag == "Player") {
                        ani = hit.collider.GetComponent<Animator>();
                        pasarTexto();
                    }
                }
            }
        }

        if (mouseMode) {
            //PARA PROBAR CON EL MOUSE
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.tag == "Player")
                    {
                        ani = hit.collider.GetComponent<Animator>();
                        pasarTexto();
                    }
                    //Debug.Log("AQUI!");
                }
            }
        }

        ////PARA PROBAR LA UBICAION DEL TEXTO
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    StopAllCoroutines();
        //    StartCoroutine(AnimateText(_dialogo.oracion[x]));
        //}
    }

    public virtual void pasarTexto() {
        
        if (Tip.activeSelf) {
            Tip.SetActive(false);
        }

        if (Paso && x <= array && eleccion == false) {
            x++;
            StopAllCoroutines();
            StartCoroutine(AnimateText(_dialogo.oracion[x]));
            Paso = false;
            //Invoke("ActivarPaso", 1);

            switch (x) {
                case 1:
                    ani.SetTrigger("Hablar");
                    break;

                case 2:
                    foreach (GameObject boton in Botones) {
                        boton.SetActive(true);
                    }
                    eleccion = true;
                    break;

                case 3:
                    ani.SetTrigger("Cheer");
                    break;
            }
        }
    }

    // void ActivarPaso() {
    //    Paso = true;
    //}

     protected void OnDisable() {
        foreach (GameObject boton in Botones) {
            boton.SetActive(false);
        }
        Tip.SetActive(false);
        texto.GetComponent<Text>().text = "";
        CancelInvoke();
        StopAllCoroutines();
        x = 0;
        eleccion = false;
        Paso = false;
    }

    protected void OnEnable() {
        Tip.SetActive(true);
        Invoke("empezar", 0.2f);
    }

    void empezar() {
        StartCoroutine(AnimateText(_dialogo.oracion[x]));
    }

    protected IEnumerator AnimateText(string oracion) {
        Text TM;
        TM = texto.GetComponent<Text>();
        TM.text = "";
        foreach (char letra in oracion) {
            TM.text += letra;
            Beep.Play();
            yield return new WaitForSeconds(0.05f);  
        }
        Paso = true;
    }

    public virtual void ElegirNumero(int numero) {

        StopAllCoroutines();
        Paso = false;

        if (numero == 1) {
            StartCoroutine(AnimateText("Cuidado! Si no conocés a la persona, no hables de cosas personales"));
        }

        if (numero == 2)
        {
            StartCoroutine(AnimateText("El perfil puede llegar a ser falso asi que no te confies!"));
        }

        if (numero == 3)
        {
            StartCoroutine(AnimateText("De esa manera, podes asegurarte de que te esta hablando una persona de confianza!"));
        }

        foreach (GameObject boton in Botones)
        {
            boton.SetActive(false);
        }

        eleccion = false;

    }
}
