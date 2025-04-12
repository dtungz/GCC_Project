using UnityEngine;
using UnityEngine.UI;

public class ToggleButton : MonoBehaviour
{
    public Button button;  
    public Color colorOn = Color.white;
    public Color colorOff = Color.gray;

    public bool isOn = true;
    private Image buttonImage;

    void Start()
    {
        buttonImage = button.GetComponent<Image>();
        UpdateColor();
    }

    public void ToggleColor()
    {
        isOn = !isOn;
        UpdateColor();
    }

    public void UpdateColor()
    {
        buttonImage.color = isOn ? colorOn : colorOff;
    }
}