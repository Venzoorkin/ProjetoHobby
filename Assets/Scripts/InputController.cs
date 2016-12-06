using UnityEngine;
using System.Collections;

public class InputController : MonoBehaviour
{
    public Vector3 input;
    public Vector3 mousePosEnd, mousePosInit, deltaSwipe;
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
        }
        if (deltaSwipe != Vector3.zero)
        {
            input = deltaSwipe;
        }
    }
}
