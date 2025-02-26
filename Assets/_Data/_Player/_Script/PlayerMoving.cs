using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoving : PlayerAbstract
{
    [SerializeField] protected float speed = 0.1f;
    [SerializeField] protected Vector3 targetPos;
    
    void FixedUpdate()
    {
        this.GetTargetPos();
        this.LookAtTarget();
        this.Moving();
    }

    protected virtual void GetTargetPos()
    {
        this.targetPos = InputManager.Instance.MouseWorldPos;
        this.targetPos.z = 0;
    }

    protected virtual void LookAtTarget()
    {
        Vector3 direction = this.targetPos - transform.parent.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.parent.rotation = Quaternion.Euler(0, 0, angle - 90);
    }

    protected virtual void Moving()
    {
        Vector3 newPos = Vector3.Lerp(transform.parent.position,this.targetPos, this.speed);
        transform.parent.position = newPos;
    }
}
