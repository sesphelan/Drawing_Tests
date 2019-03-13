using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FRL.IO;

public class PickUppable : MonoBehaviour, IPointerTriggerPressDownHandler
{

    Collision coll;
    bool grip = false;
    public FRL.XRController XRController; 

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
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
            else {
                grip = false;
                release();
            }
        }
        
    }
    
    public void pickUp()
    {
        gameObject.transform.SetParent(XRController.transform);
        gameObject.GetComponent<Rigidbody>().isKinematic = true;
    }

    public void release()
    {
        gameObject.transform.SetParent(null);
        gameObject.GetComponent<Rigidbody>().isKinematic = false;
        //gameObject.GetComponent<Rigidbody>().useGravity = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Controller") {
            //print("COLLISION");
            coll = collision;
        }
        else {
            gameObject.GetComponent<Rigidbody>().isKinematic = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Controller") {
            //print("COLLISION EXIT");
            coll = null;
        }
    }

}
