using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDrop : MonoBehaviour
{
    public GameObject Canvas;
    public GameObject Button;
    private GameObject DropZone1, DropZone2, DropZone3, DropZone4;
    private GameObject manaBar;

    private bool isDragging = false;
    private GameObject startParent;
    private Vector2 startPosition;
    private GameObject dropZone;
    private bool isOverDropZone;

    // Start is called before the first frame update
    void Start()
    {
        Canvas = GameObject.Find("Main_Canvas");
        DropZone1 = GameObject.Find("Plot_1_area");
        DropZone2 = GameObject.Find("Plot_2_area");
        DropZone3 = GameObject.Find("Plot_3_area");
        DropZone4 = GameObject.Find("Plot_4_area");
        Button = GameObject.Find("Draw_button");
        manaBar = GameObject.Find("newManaBar");

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isOverDropZone = true;
        dropZone = collision.gameObject;
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
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isOverDropZone = false;
        dropZone = null;
    }

    public void StartDrag()
    {
        isDragging = true;
        startParent = transform.parent.gameObject;
        startPosition = transform.position;
    }

    public void EndDrag()
    {
        isDragging = false;
        if (isOverDropZone)
        {

            if (dropZone == DropZone1)
            {
                Debug.Log("plot 1 +1");
                manaBar.GetComponent<Mana>().reduceMana(.1);

            }
            else if (dropZone == DropZone2)
            {
                Debug.Log("plot 2 +1");
                manaBar.GetComponent<Mana>().reduceMana(.1);
            }
            else if (dropZone == DropZone3)
            {
                Debug.Log("plot 3 +1");
                manaBar.GetComponent<Mana>().reduceMana(.1);
            }
            else if (dropZone == DropZone4)
            {
                Debug.Log("plot 4 +1");
                manaBar.GetComponent<Mana>().reduceMana(.1);
            }
            Button.GetComponent<Draw_button>().RemoveCardInHand();
            Destroy(gameObject);

        }
        else
        {
            transform.position = startPosition;
            transform.SetParent(startParent.transform, false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isDragging)
        {
            transform.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            transform.SetParent(Canvas.transform, true);
        }
    }

    
}
