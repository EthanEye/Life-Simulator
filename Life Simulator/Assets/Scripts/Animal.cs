using System;
using UnityEngine;

public class Animal : MonoBehaviour
{
    [SerializeField] private Manager manager;
    private int animalId;
    private float animalSpeed;
    private float animalSize;
    private float hunger;
    private float fieldOfView;
    private int animalType;
    private String animalName;

    private void Start()
    {
        
    }

}
