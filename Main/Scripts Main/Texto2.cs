using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Texto2 : TextoScript {

    [SerializeField]
    GameObject pibe, btnContinuar, nextLevel;
    [SerializeField]
    Text TipUi;

    protected new void OnEnable() {
        Tip.SetActive(true);
        Invoke("empezar", 0.2f);
    }

    public override void pasarTexto()
    {
        if (Tip.activeSelf)
        {
            Tip.SetActive(false);
        }

        if (Paso && x <= array)
        {
            x++;
            StopAllCoroutines();
            StartCoroutine(AnimateText(_dialogo.oracion[x]));
            Paso = false;
            //Invoke("ActivarPaso", 1);

            switch (x)
            {
                case 1:
                    ani.SetTrigger("Hablar");
                    break;

                case 3:
                    ani.SetTrigger("Bailar");
                    btnContinuar.SetActive(true);
                    break;
            }
        }
    }

    public override void ElegirNumero(int numero)
    {
        StopAllCoroutines();
        Paso = false;

        if (numero == 1)
        {
            pibe.SetActive(false);
            Tip.SetActive(true);
            TipUi.text = "Nivel 5";
            nextLevel.SetActive(true);
        }
    }


}
