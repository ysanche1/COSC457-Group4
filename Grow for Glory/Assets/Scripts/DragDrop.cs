using UnityEngine;

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

    public GameObject flower1;
    public GameObject flower2;
    public GameObject flower3;
    public GameObject flower4;

    private int growthLimitOne = 10;
    private int growthLimitTwo = 50;

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
        flower1 = GameObject.Find("EntireFlower1");
        flower2 = GameObject.Find("EntireFlower2");
        flower3 = GameObject.Find("EntireFlower3");
        flower4 = GameObject.Find("EntireFlower4");
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

   public void returnToHand()
    {
        transform.position = startPosition;
        transform.SetParent(startParent.transform, false);
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
            if (dropZone.tag == "PlotStats1" || dropZone.tag == "PlotStats2" || dropZone.tag == "PlotStats3" || dropZone.tag == "PlotStats4")
            {
                

                selectedCard.GetComponent<CardEffects>().doCardAction(selectedCard);
                Debug.Log(Button.GetComponent<Draw_button>().CardsInHand);
                //destories the played card
            }
            else
            {
                this.returnToHand();
            }

          

        }
        else
        {
            //returns card to the play area if not placed on a plot
            this.returnToHand();
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

        if (GameObject.Find("Plot_1_area").GetComponent<PlotStats1>().getPlotScore() >= growthLimitTwo)
        {
            ScaleHelper(flower1, DropZone1, 2.5f, 2.5f, -30);
        }
        else if (GameObject.Find("Plot_1_area").GetComponent<PlotStats1>().getPlotScore() >= growthLimitOne) {
            ScaleHelper(flower1, DropZone1, 2, 2, -30);
        }

        if (GameObject.Find("Plot_2_area").GetComponent<PlotStats2>().getPlotScore() >= growthLimitTwo)
        {
            ScaleHelper(flower2, DropZone2, 2.75f, 2.75f, -30);
        }
        else if (GameObject.Find("Plot_2_area").GetComponent<PlotStats2>().getPlotScore() >= growthLimitOne)
        {
            ScaleHelper(flower2, DropZone2, 2, 2, -30);
        }

        if (GameObject.Find("Plot_3_area").GetComponent<PlotStats3>().getPlotScore() >= growthLimitTwo)
        {
            ScaleHelper(flower3, DropZone3, 2.35f, 2.35f, -50);
        }
        else if (GameObject.Find("Plot_3_area").GetComponent<PlotStats3>().getPlotScore() >= growthLimitOne)
        {
            ScaleHelper(flower3, DropZone3, 2, 2, -30);
        }

        if (GameObject.Find("Plot_4_area").GetComponent<PlotStats4>().getPlotScore() >= growthLimitTwo)
        {
            ScaleHelper(flower4, DropZone4, 2.35f, 2.35f, -50);
        }
        else if (GameObject.Find("Plot_4_area").GetComponent<PlotStats4>().getPlotScore() >= growthLimitOne)
        {
            ScaleHelper(flower4, DropZone4, 2, 2, -30);
        }

    }

    private void ScaleHelper(GameObject go, GameObject dropZ, float scaleX, float scaleY, int transformY) {
        go.transform.localScale = new Vector2(scaleX, scaleY);
        go.transform.position = new Vector2(dropZ.transform.position.x, dropZ.transform.position.y + transformY);
    }
}
