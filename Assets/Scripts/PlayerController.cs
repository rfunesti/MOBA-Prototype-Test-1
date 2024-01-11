using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MoveToPosition))]
[RequireComponent(typeof(AttackTarget))]
public class PlayerController : MonoBehaviour
{
    MoveToPosition moveToPosition;
    AttackTarget attackTarget;

    void Awake()
    {
        moveToPosition = GetComponent<MoveToPosition>();
        attackTarget = GetComponent<AttackTarget>();
    }

    void Update()
    {
        if (!Input.GetMouseButtonDown(1)) return;
        RaycastHit hit; Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            GameObject hitObject = hit.collider.gameObject;
            if (hitObject.layer == LayerMask.NameToLayer("Team 2"))
            {
                if (hitObject.GetComponent<Unit>())
                {
                    Attack(hitObject);
                }
            }
            else SetDestination(hit.point);
        }
    }

    void SetDestination(Vector3 position)
    {
        moveToPosition.destination = position;
        moveToPosition.destinationSet = true;
        attackTarget.target = null;
    }

    void Attack(GameObject target)
    {
        attackTarget.target = target;
        moveToPosition.destinationSet = false;
    }
}
