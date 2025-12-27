using System;
using UnityEngine;

public class Manager : MonoBehaviour
{
    private Animal[] animals;
    private Settings settings;
    
    void Start()
    {
        settings = GetComponent<Settings>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
  
    public int AddAnimal(Animal animal)
    {

        return 0;
    }

    public void RemoveAnimal()
    {

       
    }

    public Settings Settings
    {
        
        get { return settings; }
        set { settings = value;
        Debug.Log("Manager: Settings set"); }
    }




}
