using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BattleController : MonoBehaviour
{

    public float timeBetweenInputs;
    public List<LivingEntity> entities;

    public delegate void TouchAction();
    public static event TouchAction OnTouch;

    public bool comboEnded, comboStarted;
    public Combo currentCombo;
    void Start()
    {
        entities = new List<LivingEntity>();
        foreach(LivingEntity element in FindObjectsOfType<LivingEntity>())
        {
            entities.Add(element);
        }
    }
}
