using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class AnimalGui : MonoBehaviour
{
    [SerializeField] GameObject animalGameObject;
    [SerializeField] GameObject animalGuiObject;
    private Text xCoord;
    private Text zCoord;
    private Text title;
    private Text health;
    private Text hunger;
    private Text speed;


    void Start()
    {
        animalGuiObject.GetComponentInChildren<Canvas>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            GameObject currentObject = hit.collider.gameObject;
            
           
            if(currentObject.Equals(animalGameObject))
            {
                displayGui();

            }
            else { 
                hideGui();
            }
          
        }
    }

    private void hideGui()
    {
        animalGuiObject.GetComponentInChildren<Canvas>().enabled = false;

    }

    private void displayGui()
    {
        Canvas canvas = animalGuiObject.GetComponentInChildren<Canvas>();
        canvas.enabled = true;
        updateText(canvas);
    }

    private void updateText(Canvas canvas)
    {
        Transform animalTransform = animalGameObject.transform;
        
        int x = (int) animalTransform.position.x;
        int z = (int) animalTransform.position.z;

        Transform canvasTransform = canvas.transform;
        getTextComponents(canvasTransform);
        xCoord.text = "x: " + x.ToString();
        zCoord.text = "z: " + z.ToString();


    }

    private void getTextComponents(Transform canvasTransform)
    {
        xCoord = canvasTransform.Find("Panel/x").GetComponent<Text>();
        zCoord = canvasTransform.Find("Panel/z").GetComponent<Text>();
        title = canvasTransform.Find("Panel/title").GetComponent<Text>();
        health = canvasTransform.Find("Panel/health").GetComponent<Text>();
        hunger = canvasTransform.Find("Panel/hunger").GetComponent<Text>();
        speed = canvasTransform.Find("Panel/speed").GetComponent<Text>();
    }

    public void updateTitle()
    {

    }

    public void updateHealth()
    {

    }

    public void updateHunger()
    {

    }

    public void updateSpeed(float newSpeed)
    {
        speed.text = "Speed: " + newSpeed;
    }
}
