using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Draw_button : MonoBehaviour
{
    public GameObject Card1; // Basic_Add
    public GameObject Card2; // Basic_Mult
    public GameObject Card3; // Basic_Pest
    public GameObject Card4; // Basic_Weather
    public GameObject PlayerArea;
    public GameObject card;
    public Text dayCount;
    public int days;

    private static int CardsInHand = 0;
    private int Rand;

    public void OnClick() 
    {
       
        if (days < 7)
        {
            IncreaseDays();
            while (CardsInHand < 5)
            {
                Rand = Random.Range(1, 5); // Random number 1-4

                // All card types are currently equally likely to be drawn -> change weights?
                switch (Rand)
                {
                    // Cases contain repeated code that can be cleaned up
                    case 1:
                        card = Instantiate(Card1, new Vector2(0, 0), Quaternion.identity); //Instantiate creates the game object in the scene
                        card.transform.SetParent(PlayerArea.transform, false);
                        CardsInHand++;
                        break;

                    case 2:
                        card = Instantiate(Card2, new Vector2(0, 0), Quaternion.identity);
                        card.transform.SetParent(PlayerArea.transform, false);
                        CardsInHand++;
                        break;

                    case 3:
                        card = Instantiate(Card3, new Vector2(0, 0), Quaternion.identity);
                        card.transform.SetParent(PlayerArea.transform, false);
                        CardsInHand++;
                        break;

                    case 4:
                        card = Instantiate(Card4, new Vector2(0, 0), Quaternion.identity);
                        card.transform.SetParent(PlayerArea.transform, false);
                        CardsInHand++;
                        break;
                }
            }
        }
    }

    void Start()
    {
        dayCount = GameObject.Find("Day_Count").GetComponent<Text>();
        days = 0;
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Called from DragDrop.cs
    public void RemoveCardInHand() {
        CardsInHand -= 1;
    }
    public void IncreaseDays()
    {
        days++;
        dayCount.text = "Current Day: " + days + "/7";
    }
}
