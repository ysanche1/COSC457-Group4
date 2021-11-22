using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
                    card = Instantiate(Card2, new Vector2(0, 0), Quaternion.identity); // Instantiate Basic_Mult card inside PlayerArea
                    card.transform.SetParent(PlayerArea.transform, false);
                    CardsInHand++;
                }
                else if (Rand >= 31 && Rand <= 50)
                {
                    card = Instantiate(Card4, new Vector2(0, 0), Quaternion.identity); // Instantiate Basic_Pest card inside PlayerArea
                    card.transform.SetParent(PlayerArea.transform, false);
                    CardsInHand++;
                }
                else
                {
                    card = Instantiate(Card1, new Vector2(0, 0), Quaternion.identity); // Instantiate Basic_Add card inside PlayerArea
                    card.transform.SetParent(PlayerArea.transform, false);
                    CardsInHand++;
                }
            }
        } else
        {
            // We are now on day 7, end game
            SceneManager.LoadScene("Scene_1");

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
