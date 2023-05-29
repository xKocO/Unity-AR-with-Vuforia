using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarControl : MonoBehaviour {

    public float speed;
    public float turnSpeed;
    public float gravityMultiplier;
    public bool Reversa=false;
    private Rigidbody rb;
    public float topSpeed = 100;
    private float currentSpeed = 0;
    private float pitch = 0;
    public AudioSource choque;
    public GameObject auto;
    public GameObject respawnauto;
    private bool soundChoquePlaying=false;


    void Start () {
        rb = GetComponent<Rigidbody>();
        transform.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
	} 
    void FixedUpdate () {
        Move();
        Turn();
        Fall();
    
        currentSpeed = transform.GetComponent<Rigidbody>().velocity.magnitude * 3.6f;
        pitch = (currentSpeed / topSpeed) / 1.5f;

        transform.GetComponent<AudioSource>().pitch = pitch;
}
    private void Move()
    {
        if (FButton.Forward==1||Input.GetKey(KeyCode.W))
        {
            rb.AddRelativeForce(new Vector3(Vector3.forward.x, 0, Vector3.forward.z) * speed * 10);
            Reversa = false;
        }
        if (BButton.Back==1 || Input.GetKey(KeyCode.S))
        {
            rb.AddRelativeForce(-(new Vector3(Vector3.forward.x, 0, Vector3.forward.z) * speed * 10));
            Reversa = true;
        }
        Vector3 localvelocity = transform.InverseTransformDirection(rb.velocity);
        localvelocity.x = 0;
        rb.velocity = transform.TransformDirection(localvelocity);
    }
    private void Turn()
    {
        if ((RButton.Right == 1 || Input.GetKey(KeyCode.D)) && Reversa==false)
        {
            rb.AddRelativeTorque(Vector3.up * turnSpeed * 10);
        }
        if ((RButton.Right == 1 || Input.GetKey(KeyCode.D)) && Reversa == true)
        {
            rb.AddRelativeTorque(Vector3.down * turnSpeed * 10);
        }

        if ((LButton.Left == 1 || Input.GetKey(KeyCode.A)) && Reversa==false)
        {
            rb.AddRelativeTorque(Vector3.down * turnSpeed * 10);
        }
        if ((LButton.Left == 1 || Input.GetKey(KeyCode.A)) && Reversa == true)
        {
            rb.AddRelativeTorque(Vector3.up * turnSpeed * 10);
        }

    }
    private void OnCollisionEnter(Collision other)        
    {
        if (other.collider.tag=="colisionAuto")
        {
            if (soundChoquePlaying == false)
            {
                soundChoquePlaying = true;
                choque.Play();
                Invoke("RespawnAuto", 1.05f);
            } 
        }
    }
    private void RespawnAuto()
    {
        soundChoquePlaying = false;
        transform.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        auto.transform.position = respawnauto.transform.position;
        auto.transform.rotation = respawnauto.transform.rotation;
        choque.enabled = true;
    }

    void OnDisable()
    {
        RespawnAuto();
    }

    void OnEnable() {
        Invoke("SonidoStart", 0.5f);
    }

    private void SonidoStart() {
        transform.GetComponent<AudioSource>().volume = 0.7f;
    }

    private void Fall()
    {
        rb.AddForce(Vector3.down * gravityMultiplier * 10);
    }
}
