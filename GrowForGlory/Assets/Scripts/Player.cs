using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int days;
    public Text dayCount;
    public Deck deck;
    public GameObject playerArea;
    private static int cardsInHand = 0;
    private int rand;



    public void IncreaseDays()
    {
        days++;
        dayCount.text = "Current Day: " + days + "/7";
    }

    // Start is called before the first frame update
    void Start()
    {
        dayCount = GameObject.Find("Day_Count").GetComponent<Text>();
        days = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void OnClick()
    {

        if (days < 7)
        {
            IncreaseDays();
            while (cardsInHand < 5)
            {
                rand = Random.Range(1, 5); // Random number 1-4

                // All card types are currently equally likely to be drawn -> change weights?
                switch (rand)
                {
                    // Cases contain repeated code that can be cleaned up
                    case 1:
                        deck.card = Instantiate(deck.card1, new Vector2(0, 0), Quaternion.identity); //Instantiate creates the game object in the scene
                        deck.card.transform.SetParent(playerArea.transform, false);
                        cardsInHand++;
                        break;

                    case 2:
                        deck.card = Instantiate(deck.card2, new Vector2(0, 0), Quaternion.identity);
                        deck.card.transform.SetParent(playerArea.transform, false);
                        cardsInHand++;
                        break;

                    case 3:
                        deck.card = Instantiate(deck.card3, new Vector2(0, 0), Quaternion.identity);
                        deck.card.transform.SetParent(playerArea.transform, false);
                        cardsInHand++;
                        break;

                    case 4:
                        deck.card = Instantiate(deck.card4, new Vector2(0, 0), Quaternion.identity);
                        deck.card.transform.SetParent(playerArea.transform, false);
                        cardsInHand++;
                        break;
                }
            }
        }
    }
}
