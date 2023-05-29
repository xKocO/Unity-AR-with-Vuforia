using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButterflyScript : MonoBehaviour {

    Animator Ani;
    [SerializeField]
    bool mouseMode;
    [SerializeField]
    GameObject npc;

	// Use this for initialization
	void Start () {
        Ani = GetComponent<Animator>();
	}

    // Update is called once per frame
    void Update() {

        for (int i = 0; i < Input.touchCount; ++i)
        {
            if (Input.GetTouch(i).phase == TouchPhase.Began)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(i).position);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {

                    if (hit.collider.tag == "Butterfly")
                    {
                        Ani.SetTrigger("Hey");
                    }

                }
            }
        }

        ////MOUSE TESTING

        if(mouseMode){
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {

                    if (hit.collider.tag == "Butterfly")
                    {
                        Ani.SetTrigger("Hey");
                    }
                }
            }
        }
    }

    void OnEnable() {
        npc.SetActive(true);
    }

    void OnDisable() {
        this.gameObject.transform.position = Vector3.zero;
        this.gameObject.transform.rotation = Quaternion.Euler(-90, 0, 180);
        npc.SetActive(false);
    }
}
