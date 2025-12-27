using System;
using System.Threading.Tasks;
using Unity.Loading;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
    [SerializeField] private Button startButton;
    [SerializeField] private Canvas startCanvas;
    [SerializeField] private Canvas loadCanvas;
    [SerializeField] private LoadScript loadScript;

    [SerializeField] private Color defaultColor;
    [SerializeField] private Color mediumColor;
    [SerializeField] private Color largeColor;

    private String loadingText;
    private Settings settings;
    private Slider mapSizeSlider;
    private Slider maxAnimalsSlider;
    private Slider foodRateSlider;
    private Slider hungerSlider;
    private Slider preditorSlider;

    public enum LoadingState
    {
        Initializing,
        Loading,
        Ready,
        Error
    }

    private Text loadText;
    void Start()
    {
        loadingText = ("Loading sim...");
        startCanvas.enabled = true;
        loadCanvas.enabled = false;
        loadText = loadCanvas.transform.Find("LoadText").GetComponent<Text>();
        startButton.onClick.AddListener(OnButtonClickedAsync);
        initializeSliders();
        
    }

    private void initializeSliders()
{
    mapSizeSlider = startCanvas.transform.Find("Panel/Components/MapSize").GetComponent<Slider>();
    mapSizeSlider.onValueChanged.AddListener(OnMapSizeChanged);

    maxAnimalsSlider = startCanvas.transform.Find("Panel/Components/MaxAnimals").GetComponent<Slider>();
    maxAnimalsSlider.onValueChanged.AddListener(OnMaxAnimalsChanged);

    foodRateSlider = startCanvas.transform.Find("Panel/Components/FoodSpawn").GetComponent<Slider>();
    foodRateSlider.onValueChanged.AddListener(OnFoodRateChanged);

    hungerSlider = startCanvas.transform.Find("Panel/Components/Hunger").GetComponent<Slider>();
    hungerSlider.onValueChanged.AddListener(OnHungerChanged);

    preditorSlider = startCanvas.transform.Find("Panel/Components/Preditors").GetComponent<Slider>();
    preditorSlider.onValueChanged.AddListener(OnPreditorChanged);
}

    private void OnPreditorChanged(float arg0)
    {
        Text predText = preditorSlider.transform.Find("Subtext").GetComponent<Text>();
        if (arg0 >= 0 && arg0 <= 100)
        {
            predText.text = "100";
            predText.color = defaultColor;
        }
        else if (arg0 > 100 && arg0 <= 150)
        {
            predText.text = arg0.ToString();
            predText.color = mediumColor;
        }
        else if (arg0 > 150)
        {
            predText.text = arg0.ToString();
            predText.color = largeColor;

        }
    }

    private void OnHungerChanged(float arg0)
    {
        Text hungerText = hungerSlider.transform.Find("Subtext").GetComponent<Text>();
        if (arg0 >= 0 && arg0 <= 100)
        {
            hungerText.text = "100";
            hungerText.color = defaultColor;
        }
        else if (arg0 > 100 && arg0 <= 150)
        {
            hungerText.text = arg0.ToString();
            hungerText.color = mediumColor;
        }
        else if (arg0 > 150)
        {
            hungerText.text = arg0.ToString();
            hungerText.color = largeColor;

        }

    }

    private void OnFoodRateChanged(float arg0)
    {
        Text foodRateText = foodRateSlider.transform.Find("Subtext").GetComponent<Text>();

        if (arg0 >= 0 && arg0 <= 100)
        {
            foodRateText.text = "100";
            foodRateText.color = defaultColor;
        }
        else if (arg0 > 100 && arg0 <= 150)
        {
            foodRateText.text = arg0.ToString();
            foodRateText.color = mediumColor;
        }
        else if (arg0 > 150)
        {
            foodRateText.text = arg0.ToString();
            foodRateText.color = largeColor;

        }

    }

    private void OnMaxAnimalsChanged(float arg0)
    {
        Text maxAnimalsText = maxAnimalsSlider.transform.Find("Subtext").GetComponent<Text>();
        if (arg0 >= 0 && arg0 <= 200)
        {
            maxAnimalsText.text = "200";
            maxAnimalsText.color = defaultColor;
        }
        else if (arg0 > 200 && arg0 <= 400)
        {
            maxAnimalsText.text = arg0.ToString();
            maxAnimalsText.color = mediumColor;
        }
        else if(arg0 > 400)
        {
            maxAnimalsText.text = arg0.ToString();
            maxAnimalsText.color = largeColor;
          
        }
    }

    private void OnMapSizeChanged(float arg0)
    {
        
        Text mapSizeText = mapSizeSlider.transform.Find("Subtext").GetComponent<Text>();
        if (arg0 == 0)
        {
            mapSizeText.text = "Default";
            mapSizeText.color = defaultColor;
            
        }
        else if(arg0 == 1)
        {
            mapSizeText.text = "Medium";
            mapSizeText.color = mediumColor;
           
        }
        else
        {
            mapSizeText.text = "Large";
            mapSizeText.color = largeColor; ;
      
        }
        
    }

    private async void OnButtonClickedAsync()
    {
        startCanvas.enabled = false;
        loadCanvas.enabled = true;
        CreateSettings();
        await WaitForComponentLoading();

    }

    private void CreateSettings()
    {
        if(settings == null)
        {
            settings = gameObject.GetComponentInChildren<Settings>();
        }
        
        settings.MapSize = (int) mapSizeSlider.value;
        settings.MaxAnimals = (int) maxAnimalsSlider.value;
        settings.FoodRate = (int) foodRateSlider.value;
        settings.Hunger = (int) hungerSlider.value;
        settings.Preditors = (int) preditorSlider.value;


    }

    public async Task WaitForComponentLoading()
    {
        LoadingState status = await GetLoadingStatusAsync();
        loadCanvas.enabled = false;
        Debug.Log("Loadscript complete");
    }

    public async Task<LoadingState> GetLoadingStatusAsync(){

            loadingText = "Configuring settings...";
            loadText.text = loadingText;
            await Task.Delay(300);
            loadScript.Settings = settings;
                
            loadingText = "Loading map...";
            loadText.text = loadingText;
            await Task.Delay(500);
            loadScript.LoadMap();

            loadingText = "Spawning Animals...";
            loadText.text = loadingText;
            loadScript.InitializeAnimals();
            await Task.Delay(1000);

            loadingText = "Starting Manager...";
            loadText.text = loadingText;
            loadScript.StartManager();
            await Task.Delay(100);
            


        return LoadingState.Ready;
    }
    



  
    
}
