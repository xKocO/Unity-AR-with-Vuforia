using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchScript : MonoBehaviour {

    public Rigidbody pelota;
    public float velocidad;
    public Text ui;
    private int contador = 0;
    public GameObject ball,Tip;
    [SerializeField]
    bool mouseMode;

    void Update()
    {

        for (int i = 0; i < Input.touchCount; ++i)
        {
            if (Input.GetTouch(i).phase == TouchPhase.Began)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(i).position);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit)) {

                    if (hit.collider.tag == "pelota") {

                        if(Tip.activeSelf == true)
                             Tip.SetActive(false);

                        if (pelota.velocity.y <= 0)
                        {
                            pelota.velocity = Vector3.zero;
                        }
                        pelota.AddForce(Vector3.up * velocidad, ForceMode.Impulse);
                        contador++;
                        ui.text = contador.ToString();
                    }

                }   
            }
        }

        ////MOUSE TESTING
        if (mouseMode) {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {

                    if (hit.collider.tag == "pelota")
                    {
                        if (Tip.activeSelf == true)
                            Tip.SetActive(false);

                        if (pelota.velocity.y <= 0)
                        {
                            pelota.velocity = Vector3.zero;
                        }
                        pelota.AddForce(Vector3.up * velocidad, ForceMode.Impulse);
                        contador++;
                        ui.text = contador.ToString();
                    }

                }
            }
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag=="piso")
        {
            contador = 0;
        }
        
    }

    void OnEnable() {
        Tip.SetActive(true);
    }

    void OnDisable() {
        pelota.velocity = Vector3.zero;
        ball.transform.localPosition = new Vector3(0.033f, 0.6f, 0);
    }

}
