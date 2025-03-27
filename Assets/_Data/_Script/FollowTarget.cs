using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : SGMonoBehaviour
{
    [SerializeField] protected Transform target;
    [SerializeField] protected float speed = 7f;

    void FixedUpdate()
    {
        this.Following();
    }

    protected virtual void Following()
    {
        if (this.target == null) return;
        transform.position = Vector3.Lerp(transform.position, this.target.position, Time.fixedDeltaTime * this.speed);
    }

    public virtual void SetTarget(Transform target)
    {
        this.target = target;
    }
}
