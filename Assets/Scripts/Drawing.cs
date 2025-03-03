﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FRL.IO;

public class Drawing : MonoBehaviour
{
    public GameObject brushStroke;
    public GameObject modelObject;
    // Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

	}

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Canvas" && gameObject.GetComponent<FixedJoint>()) {
            draw(collision);
        }
        
    }

    private void draw(Collision collision)
    {
            
        GameObject obj = Instantiate(brushStroke);
        obj.transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);
        obj.transform.position = collision.contacts[0].point + new Vector3(0f, 0.067f, 0);

        gameObject.transform.position = obj.transform.position;

        Renderer rend = obj.GetComponent<Renderer>();
        //rend.material.shader = Shader.Find("_Color"); // get color of brush stroke

        Renderer rend2 = GameObject.FindGameObjectWithTag("Drawer").GetComponent<Renderer>(); // set color as color of chalk
        rend.material.SetColor("_Color", rend2.material.GetColor("_Color"));

    }

    public void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Canvas" && gameObject.GetComponent<FixedJoint>()) {
            draw(collision);
        }
    }
}
