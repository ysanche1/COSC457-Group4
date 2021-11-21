using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Draw_Button : MonoBehaviour
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
                Rand = Random.Range(1, 101); // Random number 1-100

                /*  
                 *  Basic_Pest -> 1-10 = 10%
                 *  Basic_Mult -> 11-30 = 20%
                 *  Basic_Weather -> 31-50 = 20%
                 *  Basic_Add -> 51+ = 50%
                 */
                if (Rand <= 10)
                {
                    // Instantiate Basic_Pest card inside PlayerArea
                    card = Instantiate(Card3, new Vector2(0, 0), Quaternion.identity); 
                    card.transform.SetParent(PlayerArea.transform, false);
                    CardsInHand++;
                }
                else if (Rand >= 11 && Rand <= 30)
                {
                    // Instantiate Basic_Mult card inside PlayerArea
                    card = Instantiate(Card2, new Vector2(0, 0), Quaternion.identity); 
                    card.transform.SetParent(PlayerArea.transform, false);
                    CardsInHand++;
                }
                else if (Rand >= 31 && Rand <= 50)
                {
                    // Instantiate Basic_Pest card inside PlayerArea
                    card = Instantiate(Card4, new Vector2(0, 0), Quaternion.identity); 
                    card.transform.SetParent(PlayerArea.transform, false);
                    CardsInHand++;
                }
                else
                {
                    // Instantiate Basic_Add card inside PlayerArea
                    card = Instantiate(Card1, new Vector2(0, 0), Quaternion.identity); 
                    card.transform.SetParent(PlayerArea.transform, false);
                    CardsInHand++;
                }
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        dayCount = GameObject.Find("Day_Count").GetComponent<Text>();
        days = 0;
    }

    // Called from DragDrop.cs
    public void RemoveCardInHand()
    {
        CardsInHand -= 1;
    }

    // Increment to next day
    public void IncreaseDays()
    {
        days++;
        dayCount.text = "Current Day: " + days + "/7";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
