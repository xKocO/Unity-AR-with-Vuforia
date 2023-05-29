using System.Collections;
using System.Collections.Generic;
using UnityEngine; 

public class Buggy : MonoBehaviour
{
    public Transform gravityTarget;

    public float power;
    public float torque;

    public GameObject auto;
    public GameObject respawnauto;
    public bool autoOrient = false;
    public float autoOrientSpeed = 1f;

    private float horInput=0f;
    private float verInput=0f;
    private float steerAngle;

    private float currentSpeed = 0;
    private float pitch = 0;
    public float topSpeed = 100;
    private bool soundChoquePlaying = false;
    public AudioSource choque;

    private float tim=0.5f;

     public Wheel[] wheels;

    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        transform.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
    }

    void Update() 
    {
        ProcessInput();
        Vector3 diff = transform.position - gravityTarget.position;
        if(autoOrient) { AutoOrient(-diff); }

        currentSpeed = transform.GetComponent<Rigidbody>().velocity.magnitude * 3.6f;
        pitch = (currentSpeed / topSpeed) / 1.5f;
        transform.GetComponent<AudioSource>().pitch = pitch;
    }

    void FixedUpdate()
    {
        ProcessForces();
       
    }

    void ProcessInput()
    {
       // verInput = Input.GetAxis("Vertical");
       // horInput = Input.GetAxis("Horizontal");
        if (FButton.Forward == 1f)
        {
            verInput = 1f;
        }
        if (FButton.Forward == 0f && BButton.Back == 0f)
        {
            verInput = 0f;
        }
        if (BButton.Back == 1f)
        {
            verInput = -1f;
        }
        if (LButton.Left == 1f)
        {
            horInput =horInput-0.05f;
            Debug.Log(horInput);
            if (horInput<=-1)
            {
                horInput = -1;
            }
        }
        
        if (RButton.Right == 1f)
        {
            horInput = horInput + 0.05f;
           
            if (horInput >= 1f)
            {
                horInput = 1f;
            }
        }

    }

    void ProcessForces()
    {
        

        foreach(Wheel w in wheels)
        {
            w.Steer(horInput);
            w.Accelerate(verInput * power);
            w.UpdatePosition();
        }
    }

    //void ProcessGravity()
    //{
    //    Vector3 diff = transform.position - gravityTarget.position;
    //    rb.AddForce(-diff.normalized * gravity * (rb.mass));
    //}
    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.tag == "colisionAuto")
        {
            if (soundChoquePlaying == false)
            {
                soundChoquePlaying = true;
                choque.Play();
                Invoke("RespawnAuto", 1.05f);
               // horInput = 0f;
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

    void OnEnable()
    {
        Invoke("SonidoStart", 0.5f);
    }

    private void SonidoStart()
    {
        transform.GetComponent<AudioSource>().volume = 0.7f;
    }

    void AutoOrient(Vector3 down)
    {
        Quaternion orientationDirection = Quaternion.FromToRotation(-transform.up, down) * transform.rotation;
        transform.rotation = Quaternion.Slerp(transform.rotation, orientationDirection, autoOrientSpeed * Time.deltaTime);
    }
}