using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FRL.IO;

public class PickUppable : MonoBehaviour, IPointerTriggerPressDownHandler, IPointerTriggerPressUpHandler
{

    Collision coll;
    bool grip = false;
    public FRL.XRController XRController;
    public GameObject bedroom;
    public GameObject modelObject;

    private Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        if(grip == true) {
            FixedJoint fx = XRController.GetComponent<FixedJoint>();
            gameObject.transform.position = fx.transform.position;
            gameObject.transform.rotation = fx.transform.rotation;
        }
        
    }

    public void OnPointerTriggerPressDown(XREventData eventData)
    {
        //This will only be called when the object is being pointed at by a controller.
        //print("trigger");
        if(coll != null) {
            //print("TRIGGER");
            if(grip == false) {
                grip = true;
                print("GRIP");
                pickUp();
            }
        }
    }

    public void OnPointerTriggerPressUp(XREventData eventData)
    {
        if(grip == true) {
            grip = false;
            coll = null;
            release();
            if (GameObject.FindGameObjectsWithTag("brushStroke").Length > 0) {

                GameObject chalk = GameObject.FindGameObjectWithTag("Drawer");
                Renderer rend2 = chalk.GetComponent<Renderer>();

                GameObject[] allObjects = GameObject.FindGameObjectsWithTag("brushStroke");
                for (int i = 0; i < allObjects.Length; i++)
                    Destroy(allObjects[i]);
                GameObject obj = Instantiate(modelObject);

                Renderer rend = obj.GetComponent<Renderer>();
                rend.material.SetColor("_Color", rend2.material.GetColor("_Color"));
            }
        }
    }
    
    public void pickUp()
    {

        /*
        gameObject.transform.SetParent(XRController.transform);
        XRController.transform.GetChild(0).GetComponent<Collider>().enabled = false;
        */
        FixedJoint fx = XRController.gameObject.AddComponent<FixedJoint>();
        //fx.breakForce = Mathf.Infinity;
        //fx.breakTorque = Mathf.Infinity;
        fx.breakForce = 20000;
        fx.breakTorque = 20000;
        fx.connectedBody = rb;
    }

    public void release()
    {
        /*
        gameObject.transform.SetParent(bedroom.transform);
        XRController.transform.GetChild(0).GetComponent<Collider>().enabled = true;
        */
        if (XRController.gameObject.GetComponent<FixedJoint>()) {
            FixedJoint fx = XRController.gameObject.GetComponent<FixedJoint>();
            fx.connectedBody = null;
            Destroy(fx);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Controller") {
            coll = collision;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Controller") {
            coll = null;
        }
    }

}
