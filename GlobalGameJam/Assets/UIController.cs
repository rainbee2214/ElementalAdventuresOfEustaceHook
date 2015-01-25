using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Text healthText;

    float screenWidth;
    float screenHeight;

    void Awake()
    {
        healthText = GetComponent<Text>();
    }

    void Update()
    {
        if (screenWidth != Screen.width || screenHeight != Screen.height) PositionUI();
        WriteToText();
    }

    void WriteToText()
    {
        healthText.text = "Health: " + GameController.controller.GetHealth();
    }

    void PositionUI()
    {
        screenWidth = Screen.width;
        screenHeight = Screen.height;
        healthText.rectTransform.position = new Vector3(screenWidth / 2f, screenHeight - screenHeight / 10f, 0);
    }
}
