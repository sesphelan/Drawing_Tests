using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FRL.IO;

public class Drawing : MonoBehaviour
{
    public GameObject brushStroke;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Paper") {
            //GameObject obj = collision.gameObject;
            GameObject obj = Instantiate(brushStroke);
            obj.transform.position = collision.contacts[0].point;

            Renderer rend = obj.GetComponent<Renderer>();
            rend.material.shader = Shader.Find("_Color"); // get color of brush stroke

            Renderer rend2 = obj.GetComponent<Renderer>(); // set color as color of chalk
            rend.material.SetColor("_Color", rend2.material.GetColor("_Color"));
        }
        
    }


}
