using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class UIController : MonoBehaviour
{
    public Text healthText;
    public Image heart;
    List<Image> hearts;
    float screenWidth;
    float screenHeight;
    public float offset = 1f;

    public Sprite[] heartSprites;
    public int testHeart;
    public bool turnHeartOn, turnHeartOff;

    void Awake ()
    {
        CreateHearts();
        //heartSprites = new Sprite[2];
        //heartSprites[0] = Resources.Load("Sprites/Heart/Empty", typeof(Sprite)) as Sprite;
        //heartSprites[1] = Resources.Load("Sprites/Heart/Full", typeof(Sprite)) as Sprite;
    }
    void Update()
    {
        if (screenWidth != Screen.width || screenHeight != Screen.height) PositionUI();
        if (turnHeartOn) TurnHeartOn(testHeart);
        else if (turnHeartOff) TurnHeartOff(testHeart);
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
        //heart.rectTransform.position = new Vector3(screenWidth / 10f, screenHeight - screenHeight / 10f, 0);
        Vector3 position = new Vector3(screenWidth / 12f, screenHeight - screenHeight / 12f, 0);
        for (int i = 0; i < 10; i++)
        {
            hearts[i].rectTransform.position = position;
            position.x += offset;
        }
    }

    void TurnHeartOff(int index)
    {
        hearts[index].sprite = heartSprites[0];
    }
    void TurnHeartOn(int index)
    {
        hearts[index].sprite = heartSprites[1];
    }

    void CreateHearts()
    {
        hearts = new List<Image>();
        for (int i = 0; i < 10; i++)
        {
            hearts.Add(Instantiate(heart) as Image);
            hearts[i].transform.SetParent(transform);
        }
    }
}
