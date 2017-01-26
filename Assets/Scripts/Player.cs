using UnityEngine;
using System.Collections.Generic;

public class Player :LivingEntity
{
    PlayerController controller;
    public Combo[] playerCombos;
    public int comboCount;
    int currentCombo = 0;
    public float speed = 5;
    InputController InputHandlerPlayer;
	protected override void Start ()
    {
        playerCombos = PlayerComboBuilder.instance.BuildCombos();
        InputHandlerPlayer = FindObjectOfType<InputController>();
        controller = GetComponent<PlayerController>();
	}
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Combo[] comboCheck = playerCombos;

            Debug.Log(comboCheck[currentCombo].directionsQueue.Dequeue());
            if (comboCheck[currentCombo].directionsQueue.Count == 0)
                currentCombo++;
        }
    }

}
