using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draw_button : MonoBehaviour
{
    public GameObject Card1;
    public GameObject Card2;
    public GameObject PlayerArea;

    public void OnClick() 
    {
        for (int i = 0; i < 5; i++)
        {
            GameObject card = Instantiate(Card1, new Vector2(0, 0), Quaternion.identity); //Instantiate creates the game object in the scene
            card.transform.SetParent(PlayerArea.transform, false);
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
