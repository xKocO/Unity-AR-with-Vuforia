using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerScript : Vida {
    
    public enum Modo {
        Normal,
        Block,
        Dead,
    }
    public Modo modo;

    Vector3 posicion;
    GameData GD = new GameData();
    [SerializeField]
    Text combatLog ,puntajeUI, puntajeAltoUI;
    [SerializeField]
    AudioSource Music;
    [SerializeField]
    GameObject caster, zombie, monster, UI_TIP, btnMonstruo, btnZombie, btnMago, btnRespawn, casterUI, zombieUI, monsterUI;
    [SerializeField]
    private int Daño;


	// Use this for initialization
	void Start () {
        modo = Modo.Normal;
        puntajeAltoUI.text = "Puntaje Alto: " + PlayerPrefs.GetInt("HighScore", 0);
    }

    //void Update() {
    //    Debug.DrawRay(posicion, transform.forward * 2, Color.blue);
    //    if (Input.GetKeyDown(KeyCode.Space)) {
    //        Debug.Log("Puntaje: " + GD.puntaje);
    //    }
    //}

    public override void RecibirDaño(float cantidad)
    {
        base.RecibirDaño(cantidad);
        lifebarContent.fillAmount = ((vida * 100f) / GD.vidaP) / 100f;
        if (vida <= 0)
        {
            modo = Modo.Dead;
            btnRespawn.SetActive(true);
        }
    }

    public void Ataque() {
        posicion = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
        RaycastHit hit;

        if (Physics.Raycast(posicion, transform.forward, out hit, 2))
        {
            EnemigoScript ES = hit.collider.GetComponent<EnemigoScript>();
            if (ES.modo == EnemigoScript.Modo.Normal) {
                ES.RecibirDaño(Daño);
                StartCoroutine("combatLogEvent", "Hit!");
            }
            if (ES.modo == EnemigoScript.Modo.reflect)
            {
                StartCoroutine("combatLogEvent", "Reflected!");
                RecibirDaño(3);
            }
            if (ES.modo == EnemigoScript.Modo.Block) {
                StartCoroutine("combatLogEvent", "Blocked!");
            }
        }
        else { StartCoroutine("combatLogEvent", "miss"); }
    }

    public void Block() {
        posicion = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
        RaycastHit hit;

        if (Physics.Raycast(posicion, transform.forward, out hit, 2))
        {
            modo = Modo.Block;
        }
        else { modo = Modo.Normal; }
    }

    public void Normal() {
        modo = Modo.Normal;
    }

    public void Dead() {
        modo = Modo.Dead;
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        Music.Play();
        UI_TIP.SetActive(true);
        btnMago.SetActive(true);
        btnMonstruo.SetActive(true);
        btnZombie.SetActive(true);

    }

    void OnDisable()
    {
        btnRespawn.SetActive(false);
        Music.Stop();
        modo = Modo.Normal;
        vida = GD.vidaP;
        GD.puntaje = 0;
        caster.SetActive(false);
        zombie.SetActive(false);
        monster.SetActive(false);
        casterUI.SetActive(false);
        zombieUI.SetActive(false);
        monsterUI.SetActive(false);
        puntajeUIvoid();
    }

    public void InputAtaque()
    {
        if (modo != Modo.Dead) {
            ani.SetTrigger("Atack");
            Invoke("resetAtack", 0.3f);
        }
    }

    void resetAtack() {
        ani.ResetTrigger("Atack");
    }

    public void StartBlock() {
        if(modo != Modo.Dead)
        ani.SetBool("Block",true);
    }

    public void StopBlock()
    {
        ani.SetBool("Block", false);
    }

    public void puntajeUIvoid()
    {
        puntajeUI.text = "Puntaje: " + GD.puntaje;
        if (GD.puntaje > PlayerPrefs.GetInt("HighScore")){
            PlayerPrefs.SetInt("HighScore", GD.puntaje);
        }
        puntajeAltoUI.text = "Puntaje Alto: " + PlayerPrefs.GetInt("HighScore");
    }

    public void Respawnear() {
        this.gameObject.SetActive(false);
        this.gameObject.SetActive(true);
    }

    #region se activa la UI

    public void activateUI(float tiempo) {
        StartCoroutine(RealizarActivacionUI(tiempo));
    }

    IEnumerator RealizarActivacionUI(float tiempoDeEspera) {
        yield return new WaitForSeconds(tiempoDeEspera);
        btnMago.SetActive(true);
        btnMonstruo.SetActive(true);
        btnZombie.SetActive(true);
    }

    #endregion

    #region se desactiva la UI
    public void DeactivateUI()
    {
        UI_TIP.SetActive(false);
        btnMago.SetActive(false);
        btnMonstruo.SetActive(false);
        btnZombie.SetActive(false);
    }
    #endregion

    IEnumerator combatLogEvent(string evento) {
        switch (evento)
        {
            case "miss":
                combatLog.color = Color.red;
                combatLog.text = "Miss!";
                yield return new WaitForSeconds(0.5f);
                combatLog.text = "";
                break;

            case "Hit!":
                combatLog.color = Color.blue;
                combatLog.text = "Hit!";
                yield return new WaitForSeconds(0.5f);
                combatLog.text = "";
                break;

            case "Blocked!":
                combatLog.color = Color.red;
                combatLog.text = "Blocked!";
                yield return new WaitForSeconds(0.5f);
                combatLog.text = "";
                break;

            case "Reflected!":
                combatLog.color = Color.yellow;
                combatLog.text = "Reflected!";
                yield return new WaitForSeconds(0.5f);
                combatLog.text = "";
                break;
        }
    }
}
