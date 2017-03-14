using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Player :LivingEntity
{
    State currentState;
    PlayerController controller;
    public Combo[] playerCombos;
    public int comboCount;
    int currentCombo = 0;
    public float speed = 5;
    InputController InputHandlerPlayer;
	protected override void Start ()
    {
        InputController.Swiped += SwipeHandler;
        playerCombos = PlayerComboBuilder.instance.BuildCombos();
        InputHandlerPlayer = FindObjectOfType<InputController>();
        controller = GetComponent<PlayerController>();
	}

    void SwipeHandler(Swipe currentSwipe)
    {
        if (currentSwipe.swipeDirection == Directions.RIGHT&&currentState == State.Idle)
        {
            StartCoroutine(MovingTo());
        }
    }

    private  IEnumerator MovingTo ()
    {
        currentState = State.Moving;
        Vector3 originalPosition = transform.position;
        Vector3 attackPosition = FindObjectOfType<Enemy>().transform.position;
        attackPosition.x = attackPosition.x-1;
        float moveSpeed = 1;
        float percent = 0;

        while (percent <= 1)
        {
            percent += Time.deltaTime * moveSpeed;
            float interpolationValue = (-Mathf.Pow(percent, 2) + percent) * 4;
            transform.position = Vector3.Lerp(originalPosition, attackPosition, interpolationValue);
            if (transform.position == attackPosition)
            {
                break;
            }
            yield return null;
        }

        currentState = State.Idle;
        StopCoroutine(MovingTo());
    }

}
