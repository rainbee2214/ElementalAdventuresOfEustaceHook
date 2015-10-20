using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class UIController : MonoBehaviour
{
    public Text healthText;
    public Image heart;
    public Image xp;

    List<Image> hearts;
    float screenWidth;
    float screenHeight;
    public float offset = 1f;

    public Sprite[] heartSprites;

    void Start ()
    {
        CreateHearts();
    }
    void Update()
    {
        if (screenWidth != Screen.width || screenHeight != Screen.height) PositionUI();

        WriteToText();
    }

    void WriteToText()
    {
        healthText.text = "Level: " + GameController.controller.GetLevel();
    }

    void PositionUI()
    {
        screenWidth = Screen.width;
        screenHeight = Screen.height;
        //healthText.rectTransform.position = new Vector3(screenWidth / 2f, screenHeight - screenHeight / 10f, 0);
        xp.rectTransform.position = new Vector3(screenWidth - (screenWidth / 10f), screenHeight - screenHeight / 10f, 0);
        Vector3 position = new Vector3(screenWidth / 12f, screenHeight - screenHeight / 12f, 0);
        for (int i = 0; i < 10; i++)
        {
            hearts[i].rectTransform.position = position;
            position.x += offset;
        }
    }

    void TurnHeartOff(int index)
    {
        if (index >= 0)
            hearts[index].sprite = heartSprites[0];
    }
    void TurnHeartOn(int index)
    {
        hearts[index].sprite = heartSprites[1];
    }

    public void UpdateHearts()
    {
        int health = GameController.controller.playerStats.Health - 1;
        for (int i = 0; i < health; i++)
        {
            TurnHeartOn(i);
        }
        for (int i = health; i < 10; i++)
        {
            TurnHeartOff(i);
        }
        
    }
    void CreateHearts()
    {
        hearts = new List<Image>();
        for (int i = 0; i < 10; i++)
        {
            hearts.Add(Instantiate(heart) as Image);
            hearts[i].transform.SetParent(transform);
            if (i >= GameController.controller.startHealth-1) TurnHeartOff(i);
        }
    }
}
