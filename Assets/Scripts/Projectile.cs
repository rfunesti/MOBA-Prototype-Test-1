using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float moveSpeed = 10f;
    public int damage = 1;
    public bool destroyOnDamage = true;

    void Update() => transform.position += transform.forward * moveSpeed * Time.deltaTime;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<IDamageable>(out var damageable))
        {
            damageable.TakeDamage(damage);
            if (destroyOnDamage) Destroy(gameObject);
        }
    }
}
