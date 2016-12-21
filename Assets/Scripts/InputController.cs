using UnityEngine;
using System.Collections;


public enum Directions { DOWN_LEFT, DOWN, DOWN_RIGHT, LEFT, NEUTRAL, RIGHT, UP_LEFT, UP, UP_RIGHT }

public class InputController : MonoBehaviour
{
    Vector3 input;
    Vector3 mousePosEnd, mousePosInit, deltaSwipe;
   Transform AngleFixer;
    public Swipe currentSwipe;
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
            //print(SwipeDegree);
            transform.GetChild(0).transform.rotation = Quaternion.Euler(0f, 0f, swipeDegree);
            swipeDegree = transform.GetChild(0).transform.rotation.eulerAngles.z;
            //print(SwipeDegree);

            currentSwipe = new Swipe();

            currentSwipe.swipeDegree = swipeDegree;
            currentSwipe.FindSwipeDirection(swipeDegree);

        }
    }
}

[System.Serializable]
public class Swipe
{
    Directions swipeDirection;
    public float swipeDegree;

    public void FindSwipeDirection(float Degree)
    {
       if((Degree <=30 && Degree > 0 ) || Degree > 330)
        {
            swipeDirection = Directions.RIGHT;
        }
       else if (Degree >30 && Degree<= 60)
        {
            swipeDirection = Directions.UP_RIGHT;
        }
       else if (Degree > 60 && Degree <= 120)
        {
            swipeDirection = Directions.UP;
        }
       else if (Degree >120 && Degree <= 150)
        {
            swipeDirection = Directions.UP_LEFT;
        }
       else if (Degree>150 && Degree <= 210)
        {
            swipeDirection = Directions.LEFT;
        }
       else if (Degree>210 && Degree <= 240)
        {
            swipeDirection = Directions.DOWN_LEFT;
        }
       else if (Degree >240 && Degree <= 300)
        {
            swipeDirection = Directions.DOWN;
        }
       else if (Degree >300 &&Degree <= 330)
        {
            swipeDirection = Directions.DOWN_RIGHT;
        }
       else
        {
            swipeDirection = Directions.NEUTRAL;
        }
        Debug.Log(swipeDirection);
    }
}
