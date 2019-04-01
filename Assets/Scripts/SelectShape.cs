using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FRL.IO;
using UnityEngine.UI;

public class SelectShape : MonoBehaviour, IPointerTriggerPressDownHandler {
    // Start is called before the first frame update
    public GameObject sphere;
    public GameObject cube;

    private bool objectSelected = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private GameObject setModel(GameObject chalk, GameObject shape)
    {
        chalk.GetComponent<CreateObject>().modelObject = shape;
        objectSelected = true;
        return chalk;
    } 

    private GameObject changeParams(GameObject obj, string tag, string color, string name)
    {
        obj.GetComponentInChildren<Text>().text = color;
        obj.tag = tag;
        obj.name = name;
        return obj;
    }

    private Renderer chooseColor(Renderer rend, string color)
    {
        Color col;
        if(color == "pink") {
            col = Color.magenta;
            rend.material.SetColor("_Color", col);
        }
        else {
            col = Color.blue;
            rend.material.SetColor("_Color", col);
        }
        return rend;
    }

    public void OnPointerTriggerPressDown(XREventData eventData)
    {
        GameObject chalk = GameObject.FindGameObjectWithTag("Drawer");
        if (!objectSelected) { // CHOOSE TYPE OF SHAPE TO DRAW FIRST
            if (gameObject.tag == "chooseSphere") {
                print("Chosen Sphere");
                chalk = setModel(chalk, sphere);
            }
            if (gameObject.tag == "chooseCube") {
                print("Chosen Cube");
                chalk = setModel(chalk, cube);
            }
            GameObject obj1 = GameObject.FindGameObjectWithTag("chooseSphere");
            GameObject obj2 = GameObject.FindGameObjectWithTag("chooseCube");
            obj1 = changeParams(obj1, "chooseBlue", "Blue", "chooseBlue");
            obj2 = changeParams(obj2, "choosePink", "Pink", "choosePink");
        }
        else { // THEN CHOOSE COLOR OF SHAPE
            Renderer chalkRender = chalk.AddComponent<MeshRenderer>();
            if (gameObject.tag == "choosePink") {
                print("Chosen pink");
                chalkRender = chooseColor(chalkRender, "pink");
            }
            else if (gameObject.tag == "chooseBlue") {
                print("Chosen blue");
                chalkRender = chooseColor(chalkRender, "blue");
            }

            GameObject obj1 = GameObject.FindGameObjectWithTag("chooseBlue");
            GameObject obj2 = GameObject.FindGameObjectWithTag("choosePink");
            obj1.SetActive(false);
            obj2.SetActive(false);
        }
    }
}
