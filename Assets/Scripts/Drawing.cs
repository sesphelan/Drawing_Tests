using System.Collections;
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
        if(collision.gameObject.tag == "Controller" && collision.gameObject.transform.childCount > 2) {
            //GameObject obj = collision.gameObject;
            GameObject obj = Instantiate(brushStroke);
            obj.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            obj.transform.position = collision.contacts[0].point - new Vector3(0f, 0.26f, 0f);

            Renderer rend = obj.GetComponent<Renderer>();
            rend.material.shader = Shader.Find("_Color"); // get color of brush stroke

            Renderer rend2 = collision.gameObject.transform.GetChild(2).GetComponent<Renderer>(); // set color as color of chalk
            rend.material.SetColor("_Color", rend2.material.GetColor("_Color"));
        }
        
    }

    public void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Controller" && collision.gameObject.transform.childCount > 2) {
            //GameObject obj = collision.gameObject;
            GameObject obj = Instantiate(brushStroke);
            obj.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            obj.transform.position = collision.contacts[0].point - new Vector3(0f, 0.26f, 0f);

            Renderer rend = obj.GetComponent<Renderer>();
            rend.material.shader = Shader.Find("_Color"); // get color of brush stroke

            Renderer rend2 = collision.gameObject.transform.GetChild(2).GetComponent<Renderer>(); // set color as color of chalk
            rend.material.SetColor("_Color", rend2.material.GetColor("_Color"));
        }
    }

    public void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Controller" && collision.gameObject.transform.childCount == 2) {
            GameObject[] allObjects = GameObject.FindGameObjectsWithTag("brushStroke");
            for (int i = 0; i < allObjects.Length; i++)
                Destroy(allObjects[i]);
            GameObject obj = Instantiate(modelObject);

            Renderer rend = obj.GetComponent<Renderer>();
            rend.material.shader = Shader.Find("_Color"); // get color of brush stroke

            Renderer rend2 = collision.gameObject.transform.GetChild(2).GetComponent<Renderer>(); // set color as color of chalk
            rend.material.SetColor("_Color", rend2.material.GetColor("_Color"));

        }
    }
}
