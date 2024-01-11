using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAbility
{
    public bool Request { get; set; }
    public Vector3 Target { get; set; }
}

public class ProjectileAbility : MonoBehaviour, ITask, IAbility
{
    [SerializeField] float cooldownTime = 1f;
    bool cooldownActive = false;
    bool aimActive = false;
    bool request = false;
    public Vector3 aimDirection;
    public GameObject projectilePrefab;

    public bool Request
    {
        get => request;
        set => request = value;
    }

    public Vector3 Target
    {
        get => aimDirection;
        set => aimDirection = (value - transform.position).normalized;
    }

    public bool Evaluate()
    {
        if (cooldownActive) return false;

        if (request && !aimActive)
        {
            aimActive = true;
            return true;
        }
        else if (request && aimActive) return true;
        else if (!request && aimActive)
        {
            Instantiate(projectilePrefab, transform.position, Quaternion.LookRotation(aimDirection));
            aimActive = false;
            StartCoroutine(Cooldown());
        }
        return false;
    }

    IEnumerator Cooldown()
    {
        cooldownActive = true;
        yield return new WaitForSeconds(cooldownTime);
        cooldownActive = false;
    }
}
