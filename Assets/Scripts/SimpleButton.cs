using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SimpleButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Color newColor;
    public Text buttonText;
    private Color originalColor;

    void Start()
    {
        originalColor = buttonText.color;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        buttonText.color = newColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        buttonText.color = originalColor;
    }
}

