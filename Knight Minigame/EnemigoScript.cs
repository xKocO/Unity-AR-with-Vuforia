using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;


public class EnemigoScript : Vida {

    [SerializeField]
    private GameObject player;
    [SerializeField]
    private float rayDistance;
    [SerializeField]
    private float daño;
    [SerializeField]
    UnityEvent UiPuntaje, UiActivate, UiDeactivate;
    [SerializeField]
    GameObject Caster, zombie, monstruo, canvas;
    Vector3 position;
    GameData GD = new GameData();

    public enum Tipo
    {
        Zombie,
        Monstruo,
        Caster,
    }
    public Tipo tipo;

    public enum Modo
    {
        Normal,
        Block,
        reflect,
        Dead,
    }
    public Modo modo;

    // Update is called once per frame
    void Update () {
        //transform.LookAt(player.transform.position);
        //Debug.DrawRay(position, transform.forward * rayDistance, Color.red);
	}

    public override void RecibirDaño(float cantidad)
    {
        base.RecibirDaño(cantidad);
        switch (tipo)
        {
            case Tipo.Monstruo:
                lifebarContent.fillAmount = ((vida * 100f) / GD.vidaM) / 100f;
                break;

            case Tipo.Caster:
                lifebarContent.fillAmount = ((vida * 100f) / GD.vidaC) / 100f;
                break;

            case Tipo.Zombie:
                lifebarContent.fillAmount = ((vida * 100f) / GD.vidaZ) / 100f;
                break;
        }
        if (vida <= 0) {
            modo = Modo.Dead;
            switch (tipo)
            {
                case Tipo.Monstruo:
                    GD.puntaje += 2;
                    break;

                case Tipo.Caster:
                    GD.puntaje += 3;
                    break;

                case Tipo.Zombie:
                    GD.puntaje++;
                    break;
            }
            UiPuntaje.Invoke();
            UiActivate.Invoke();
        }
    }

    public void Ataque() {
        position = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
        RaycastHit hit;

        if (Physics.Raycast(position, transform.forward, out hit, rayDistance)) {
            PlayerScript PS = hit.collider.GetComponent<PlayerScript>();

            if (PS.modo == PlayerScript.Modo.Normal) {
                PS.RecibirDaño(daño);
            }
        }
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        canvas.SetActive(true);
        UiDeactivate.Invoke();
        StartCoroutine("Pelea");
    }

    void OnDisable() {
        modo = Modo.Normal;
        switch (tipo){
            case Tipo.Monstruo:
                vida = GD.vidaM;
                break;

            case Tipo.Caster:
                vida = GD.vidaC;
                break;

            case Tipo.Zombie:
                vida = GD.vidaZ;
                break;
        }
        StopCoroutine("Pelea");
    }

    IEnumerator Pelea() {
        PlayerScript PS = player.GetComponent<PlayerScript>();
        while (modo != Modo.Dead && PS.modo != PlayerScript.Modo.Dead) {
            int tiempo = Random.Range(2, 5);
            int accion;
            switch (tipo)
            {
                case Tipo.Monstruo:
                    accion = Random.Range(1, 3);
                    yield return new WaitForSeconds(tiempo);
                    if (accion == 1) {
                        InputAtaque();
                    }
                    if (accion == 2)
                    {
                        InputBlock();
                    }
                    break;

                case Tipo.Caster:
                    accion = Random.Range(1, 3);
                    yield return new WaitForSeconds(tiempo);
                    if (accion == 1)
                    {
                        InputAtaque();
                    }
                    if (accion == 2)
                    {
                        InputReflect();
                    }
                    break;

                case Tipo.Zombie:
                    yield return new WaitForSeconds(tiempo);
                    InputAtaque();
                    break;
            }
        }
    }

    void InputAtaque() {
        ani.SetTrigger("Atack");
    }

    void InputBlock()
    {
        ani.SetTrigger("Block");
    }

    void InputReflect() {
        ani.SetTrigger("Reflect");
    }

    public void modoNormal() {
        modo = Modo.Normal;
    }

    public void modoBlock()
    {
        modo = Modo.Block;
    }

    public void modoReflect()
    {
        modo = Modo.reflect;
    }

    public void spawner() {
        this.gameObject.SetActive(false);
        switch (tipo)
        {
            case Tipo.Zombie:
                Caster.SetActive(false);
                monstruo.SetActive(false);
                zombie.SetActive(true);
                break;

            case Tipo.Caster:
                monstruo.SetActive(false);
                zombie.SetActive(false);
                Caster.SetActive(true);
                break;

            case Tipo.Monstruo:
                zombie.SetActive(false);
                Caster.SetActive(false);
                monstruo.SetActive(true);
                break;
        }
    }
}
