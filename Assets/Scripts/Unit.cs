using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{
    public void TakeDamage(int damage);
}


public class Unit : MonoBehaviour, IDamageable
{
    public IntWrapper health;

    public void TakeDamage(int damage)
    {
        health.Value -= damage;
        if (health.Value <= 0) Destroy(gameObject);
    }

}