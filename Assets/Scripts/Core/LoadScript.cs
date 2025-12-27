using System;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using static UnityEditorInternal.ReorderableList;

public class LoadScript : MonoBehaviour
{
    [SerializeField] GameObject defaultMap;
    [SerializeField] GameObject mediumMap;
    [SerializeField] GameObject largeMap;
    [SerializeField] GameObject dummyMap;
    [SerializeField] Transform mainCam;


    private Settings settings;
    private Manager manager;
    private GameObject map;
    private Animal animal;
    private int preditors;
    private int herbivores;

    



    void Start()
    {
       manager = GetComponent<Manager>(); 
       settings = GetComponent<Settings>();
       CheckForNullComponents();
       
    }

    private void CheckForNullComponents()
    {
        if (settings == null)
        {
            throw new Exception("Settings component not found!");
        }

        if (manager == null)
        {
            throw new Exception("Manager component not found!"); ;
        }
    }

    public void LoadMap()
    {
        int mapSize = settings.MapSize;
        dummyMap.SetActive(false);
        if (mapSize == 0)
        {
            map = Instantiate(defaultMap);
            Vector3 pos = mainCam.transform.position;
            pos.y = 42;
            mainCam.transform.position = pos;
        }
        if(mapSize == 1)
        {
          map = Instantiate(mediumMap);
            Vector3 pos = mainCam.transform.position;
            pos.y = 52;
            mainCam.transform.position = pos;
        }
        if (mapSize >= 2)
        {
         map = Instantiate(largeMap);
            Vector3 pos = mainCam.transform.position;
            pos.y = 65;
            mainCam.transform.position = pos;
        }
        map.SetActive(true);

        settings.PrintSettings();
    }

    public void InitializeAnimals()
    { 
        double startAnimals = Settings.MaxAnimals / 10;
        double pPercent = Math.Ceiling(Settings.Preditors / 8.0);
        double hPercent = 100 - pPercent;
        
        preditors = (int) Math.Ceiling(startAnimals * (pPercent / 100));
        herbivores = (int) Math.Ceiling(startAnimals * (hPercent / 100));

        Debug.Log("Total : " + startAnimals);
        Debug.Log("P : " + preditors);
        Debug.Log("H : " + herbivores);
     
        SpawnEntities();

    }

    public void SpawnEntities()
    {

        

        RandomizePreditors();

        
     
        
    }

    private void RandomizePreditors()
    {
           for(int i = 1; i <= preditors; i++)
        {
            
        }
        RandomizeHerbivores();
    }

    private void RandomizeHerbivores()
    {
         for(int i = 1; i <= herbivores; i++)
        {
            
        }
        
    }

    public void StartManager()
    {
        manager.Settings = settings;
    }

    public Settings Settings
    {
        get { return settings; }
        set { settings = value; }
        
    }

}
