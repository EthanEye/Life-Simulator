using UnityEngine;

public class Settings : MonoBehaviour
{
    private int mapSize;
    private int maxAnimals;
    private int foodRate;
    private int hunger;
    private int preditors;

    public int MapSize
    {
        get { return mapSize; }
        set { mapSize = value; }
    }

    public int MaxAnimals
    {
        get { return maxAnimals; }
        set { maxAnimals = value; }
    }

    public int FoodRate
    {
        get { return foodRate; }
        set { foodRate = value; }
    }

    public int Hunger
    {
        get { return hunger; }
        set { hunger = value; }
    }

    public int Preditors
    {
        get { return preditors; }
        set { preditors = value; }
    }

    public void PrintSettings()
    {
        Debug.Log("=== Settings ===");
        Debug.Log("Map Size: " + MapSize);
        Debug.Log("Max Animals: " + MaxAnimals);
        Debug.Log("Food Rate: " + FoodRate);
        Debug.Log("Hunger: " + Hunger);
        Debug.Log("Preditors: " + Preditors);
    }

}