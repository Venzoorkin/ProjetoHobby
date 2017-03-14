using UnityEngine;
using System.Collections;

public class LivingEntity : MonoBehaviour
{
    public enum State { Idle,Moving,Attacking}
    public float startingHealth;
    protected float currentHealth;
    protected bool dead;

    public event System.Action OnDeath;

    protected virtual void Start()
    {
        currentHealth = startingHealth;
    }

    public virtual void TakeHit(float damage)
    {
        TakeDamage(damage);
    }

    public virtual void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if(currentHealth <=0 && !dead)
        {
            Die();
        }
    }

    protected void Die()
    {
        dead = true;
        if (OnDeath != null)
        {
            OnDeath();
        }
        GameObject.Destroy(gameObject);
    }

}
