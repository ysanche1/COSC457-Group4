using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DragDrop : MonoBehaviour
{

    //declares all needed varables
    public GameObject Canvas;
    public GameObject Button;
    private GameObject DropZone1, DropZone2, DropZone3, DropZone4;
    public GameObject manaBar;
  
    private bool isDragging = false;
    private GameObject startParent;
    private Vector2 startPosition;
    public GameObject dropZone;
    private bool isOverDropZone;
    private GameObject selectedCard;



    // Start is called before the first frame update
    void Start()
    {
        //all store their respective game objects
        Canvas = GameObject.Find("Main_Canvas");
        Button = GameObject.Find("Draw_button");
        manaBar = GameObject.Find("newManaBar");
        DropZone1 = GameObject.Find("Plot_1_area");
        DropZone2 = GameObject.Find("Plot_2_area");
        DropZone3 = GameObject.Find("Plot_3_area");
        DropZone4 = GameObject.Find("Plot_4_area");

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //checks if it is over a plot 
        isOverDropZone = true;
        // grabs the plot it collided with 
        dropZone = collision.gameObject;
     
        /*
        if (dropZone == DropZone1)
        {
            Debug.Log("plot 1");
        }
        else if (dropZone == DropZone2)
        {
            Debug.Log("plot 2");
        }
        else if (dropZone == DropZone3)
        {
            Debug.Log("plot 3");
        }
        else if (dropZone == DropZone4)
        {
            Debug.Log("plot 4");
        }
        */
        
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isOverDropZone = false;
        dropZone = null;
    }
    
    public string returnTag()
    {
        return selectedCard.tag;
    }


    public void StartDrag()
    {
        selectedCard = this.gameObject;
        isDragging = true;
        //saves parent object 
        startParent = transform.parent.gameObject;
        //saves initional locatrion to be returned to
        startPosition = transform.position;
    }

    public void EndDrag()
    {
        
        //stops the card from following the mouse
        isDragging = false;
        if (isOverDropZone)
        {
            selectedCard.GetComponent<CardEffects>().doCardAction(selectedCard);
            /*if (dropZone == DropZone1) {
                // check the tag of the card that is selected and reduce mana / increase total accordingly

                Debug.Log("plot 1 +1");
          

            }
            else if (dropZone == DropZone2)
            {
                Debug.Log("plot 2 +1");
                //calls reduce mana method to deacease overall mana by one  
                //manaBar.GetComponent<Mana>().reduceMana(.1);
                //call increase total form the plotstats script based on the plot
                //dropZone.GetComponent<PlotStats2>().IncreaseTotal(1);

            }
            else if (dropZone == DropZone3)
            {
                Debug.Log("plot 3 +1");
                //calls reduce mana method to deacease overall mana by one
                //manaBar.GetComponent<Mana>().reduceMana(.1);
                //call increase total form the plotstats script based on the plot
                //dropZone.GetComponent<PlotStats3>().IncreaseTotal(1);
            }
            else if (dropZone == DropZone4)
            {
                Debug.Log("plot 4 +1");
                //calls reduce mana method to deacease overall mana by one
                //manaBar.GetComponent<Mana>().reduceMana(.1);
                //call increase total form the plotstats script based on the plot
                //dropZone.GetComponent<PlotStats4>().IncreaseTotal(1);
            }
            */
            //reduces the number of card in hand by 1

            Button.GetComponent<Draw_button>().RemoveCardInHand();
            //destories the played card

          

        }
        else
        {
            //returns card to the play area if not placed on a plot
            transform.position = startPosition;
            transform.SetParent(startParent.transform, false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isDragging)
        {
            //follows the mouse position
            transform.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            transform.SetParent(Canvas.transform, true);
        }
    }

    
}
