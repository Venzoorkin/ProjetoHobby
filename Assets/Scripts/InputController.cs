using UnityEngine;
using System.Collections;


public enum Directions { DOWN_LEFT, DOWN, DOWN_RIGHT, LEFT, NEUTRAL, RIGHT, UP_LEFT, UP, UP_RIGHT }


public class InputController : MonoBehaviour
{
    Vector3 input;
    Vector3 mousePosEnd, mousePosInit, deltaSwipe;
   Transform AngleFixer;
    public Swipe currentSwipe;

    public delegate void SwipeActon(Swipe swipeDegree);
    public static event SwipeActon Swiped;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mousePosInit = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        else if (Input.GetMouseButtonUp(0))
        {
            mousePosEnd = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            deltaSwipe = mousePosEnd - mousePosInit;
            deltaSwipe.Normalize();
            float swipeDegree = Mathf.Atan2(deltaSwipe.y, deltaSwipe.x) * Mathf.Rad2Deg;
            transform.GetChild(0).transform.rotation = Quaternion.Euler(0f, 0f, swipeDegree);
            swipeDegree = transform.GetChild(0).transform.rotation.eulerAngles.z;
            currentSwipe = new Swipe(swipeDegree);
            Swiped(currentSwipe);

        }
    }
}

[System.Serializable]
public class Swipe
{
    public Directions swipeDirection { get { return FindSwipeDirection(swipeDegree); } }
    private float swipeDegree;

    public Swipe(float newSwipeDegree)
    {
        swipeDegree = newSwipeDegree;
    }

    private Directions FindSwipeDirection(float Degree)
    {
       if((Degree <=30 && Degree > 0 ) || Degree > 330)
        {
            return Directions.RIGHT;
        }
       else if (Degree >30 && Degree<= 60)
        {
            return Directions.UP_RIGHT;
        }
       else if (Degree > 60 && Degree <= 120)
        {
            return Directions.UP;
        }
       else if (Degree >120 && Degree <= 150)
        {
           return Directions.UP_LEFT;
        }
       else if (Degree>150 && Degree <= 210)
        {
            return Directions.LEFT;
        }
       else if (Degree>210 && Degree <= 240)
        {
            return Directions.DOWN_LEFT;
        }
       else if (Degree >240 && Degree <= 300)
        {
            return Directions.DOWN;
        }
       else if (Degree >300 
            &&
            Degree <= 330)
        {
            return Directions.DOWN_RIGHT;
        }
       else
        {
           return Directions.NEUTRAL;
        }
        
    }
}
