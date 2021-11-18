using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draw_button : MonoBehaviour
{
    public GameObject Card1;
    public GameObject Card2;
    public GameObject PlayerArea;

    private static int CardsInHand = 0;

    public void OnClick() 
    {
        while (CardsInHand < 5) {
            GameObject card = Instantiate(Card1, new Vector2(0, 0), Quaternion.identity); //Instantiate creates the game object in the scene
            card.transform.SetParent(PlayerArea.transform, false);
            CardsInHand++;
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RemoveCardInHand() {
        CardsInHand -= 1;
    }
}
