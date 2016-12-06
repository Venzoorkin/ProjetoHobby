using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BattleController : MonoBehaviour
{
    public List<LivingEntity> entities;

    void Start()
    {
        entities = new List<LivingEntity>();
        foreach(LivingEntity element in FindObjectsOfType<LivingEntity>())
        {
            entities.Add(element);
        }
    }


}
