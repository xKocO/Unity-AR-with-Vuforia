using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Vida : MonoBehaviour {

    [SerializeField]
    protected float vida = 10;
    [SerializeField]
    protected Animator ani;
    [SerializeField]
    protected Image lifebarContent;

    virtual public void RecibirDaño(float cantidad)
    {
        vida -= cantidad;
        if (vida <= 0)
        {
            vida = 0;
            ani.SetTrigger("Death");
            Invoke("resetTriggers", 0.3f);
        }
    }

    private void resetTriggers()
    {
        ani.ResetTrigger("Death");
    }

    protected virtual void OnEnable() {
        lifebarContent.fillAmount = 1;
    }
}
