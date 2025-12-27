
using System;
using UnityEngine;
public class Animal : MonoBehaviour
{
    private int id;
    private String species;
    private int animalSpeed;
    private int animalSize;
    private int hunger;
    private int energy;
    private int fieldOfView;
    private int health;
    private int x;
    private int y;
    private int direction;

    public int Id
    {
        get { return id; }
        set { id = value; }
    }

    public String Species
    {
        get { return species; }
        set { species = value; }
    }

    public int AnimalSpeed
    {
        get { return animalSpeed; }
        set { animalSpeed = value; }
    }

    public int AnimalSize
    {
        get { return animalSize; }
        set { animalSize = value; }
    }

    public int Hunger
    {
        get { return hunger; }
        set { hunger = value; }
    }

    public int Energy
    {
        get { return energy; }
        set { energy = value; }
    }

    public int FieldOfView
    {
        get { return fieldOfView; }
        set { fieldOfView = value; }
    }

    public int Health
    {
        get { return health; }
        set { health = value; }
    }

    public int X
    {
        get { return x; }
        set { x = value; }
    }

    public int Y
    {
        get { return y; }
        set { y = value; }
    }

    public int Direction
    {
        get { return direction; }
        set { direction = value; }
    }
}