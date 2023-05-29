using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class texto3 : TextoScript {

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
                    ani.SetBool("Nervios",true);
                    break;

                case 2:
                    ani.SetBool("Hablar", true);
                    break;

                case 4:
                    ani.SetBool("Saludo",true);
                    break;
            }
        }
    }

}
