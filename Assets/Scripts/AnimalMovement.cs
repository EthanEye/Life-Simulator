using System;
using System.Collections;
using UnityEngine;

public class AnimalMovement : MonoBehaviour
{
    [SerializeField] GameObject animalGameObject;
    [SerializeField] AnimalGui animalGuiScript;
    [SerializeField] private float speed;
    [SerializeField] private float range;
    private Boolean pauseMovement;
    

    void Start()
    { 
            pauseMovement = true;
            StartCoroutine(InitializeUI());
        
    }

    IEnumerator InitializeUI()
    {
        yield return new WaitForSeconds(4f);
        animalGuiScript.updateSpeed(speed);
        pauseMovement = false;
    }

       
        void Update()
    {
        if (!pauseMovement)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        
    }
}
