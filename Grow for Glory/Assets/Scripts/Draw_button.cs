using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Draw_button : MonoBehaviour
{
    public GameObject Card1; // +3 add card
    public GameObject Card2; // X3 multi card
    public GameObject Card3; // Pest card
    public GameObject Card4; // +10 weather
    public GameObject Card5; // +5 add card
    public GameObject Card6; // +10 add card
    public GameObject Card7; // X2 multi card
    public GameObject Card8; // X3 Weather card
    public GameObject Card9; // X4 multi card
    public GameObject Card10;// X10 multi card


    public GameObject PlayerArea;
    public GameObject card;
    public Text dayCount;
    public int days = 0; 

    private static int CardsInHand = 0;
    private int Rand;

    private GameObject manaBar;

    public void OnClick()
    {
        Debug.Log("OnClick start: " + days);

        if (days < 7)
        {
            IncreaseDays();
            Debug.Log("if days < 7: " + days);

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
                    card = Instantiate(Card3, new Vector2(0, 0), Quaternion.identity); // Instantiate Basic_Pest card inside PlayerArea
                    card.transform.SetParent(PlayerArea.transform, false);
                    CardsInHand++;
                }
                else if (Rand >= 11 && Rand <= 30)
                {
                    if (Rand >= 11 && Rand <= 19)
                    {
                        card = Instantiate(Card7, new Vector2(0, 0), Quaternion.identity); // Instantiate X2 multi card inside PlayerArea
                        card.transform.SetParent(PlayerArea.transform, false);
                        CardsInHand++;
                    }
                    else if (Rand >= 20 && Rand <= 25)
                    {
                        card = Instantiate(Card2, new Vector2(0, 0), Quaternion.identity); // Instantiate X3 multi card inside PlayerArea
                        card.transform.SetParent(PlayerArea.transform, false);
                        CardsInHand++;
                    }
                    else if (Rand >= 26 && Rand <= 28)
                    {
                        card = Instantiate(Card9, new Vector2(0, 0), Quaternion.identity); // Instantiate X4 multi card inside PlayerArea
                        card.transform.SetParent(PlayerArea.transform, false);
                        CardsInHand++;
                    }
                    else if (Rand >= 29 && Rand <= 30)
                    {
                        card = Instantiate(Card10, new Vector2(0, 0), Quaternion.identity); // Instantiate X10 multi card inside PlayerArea
                        card.transform.SetParent(PlayerArea.transform, false);
                        CardsInHand++;
                    }
                }
                else if (Rand >= 31 && Rand <= 50)
                {
                    if (Rand >= 31 && Rand <= 36)
                    {
                        card = Instantiate(Card8, new Vector2(0, 0), Quaternion.identity); // Instantiate X3 weather card card inside PlayerArea
                        card.transform.SetParent(PlayerArea.transform, false);
                        CardsInHand++;
                    }
                    else
                    {
                        card = Instantiate(Card4, new Vector2(0, 0), Quaternion.identity); // Instantiate +10 weather card inside PlayerArea
                        card.transform.SetParent(PlayerArea.transform, false);
                        CardsInHand++;
                    }

                }
                else if (Rand >= 51 && Rand <= 100)
                {
                    if (Rand >= 51 && Rand <= 70)
                    {
                        card = Instantiate(Card1, new Vector2(0, 0), Quaternion.identity); // Instantiate +3 Add card inside PlayerArea
                        card.transform.SetParent(PlayerArea.transform, false);
                        CardsInHand++;
                    }
                    else if (Rand >= 71 && Rand <= 85)
                    {
                        card = Instantiate(Card5, new Vector2(0, 0), Quaternion.identity); // Instantiate +5 Add card inside PlayerArea
                        card.transform.SetParent(PlayerArea.transform, false);
                        CardsInHand++;
                    }
                    else if (Rand >= 86 && Rand <= 100)
                    {
                        card = Instantiate(Card6, new Vector2(0, 0), Quaternion.identity); // Instantiate +10 Add card inside PlayerArea
                        card.transform.SetParent(PlayerArea.transform, false);
                        CardsInHand++;
                    }
                }
            }

            if (days == 7)
            {
                // Change text on Button to "End Week"
                GameObject.Find("Draw_button").GetComponentInChildren<Text>().text = "End Week";
            }
        }
        else
        {
            // We are now on day 7, end game
            SceneManager.LoadScene("Scene_1");

            
        }
         manaBar = GameObject.FindGameObjectWithTag("manaBar");
         manaBar.GetComponent<Mana>().setCurrMana(1);



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
