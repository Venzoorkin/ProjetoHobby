using UnityEngine;
using System.Collections;

public class Player :LivingEntity
{
    PlayerController controller;
    public float speed = 5;
    InputController InputHandlerPlayer;
	protected override void Start ()
    {
        InputHandlerPlayer = FindObjectOfType<InputController>();
        controller = GetComponent<PlayerController>();
	}
    void Update()
    {
    }

}
