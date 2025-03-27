using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]

public class PlayerTargeting : SGMonoBehaviour
{
    [SerializeField] protected SphereCollider sphereCollider;

    [SerializeField] protected JunkCtrl nearest;
    public JunkCtrl Nearest => nearest;

    [SerializeField] protected LayerMask obstacleLayerMask;

    [SerializeField] protected List<JunkCtrl> junks = new();


    protected virtual void FixedUpdate()
    {
        this.FindNearest();
        //this.RemoveDead();
    }

    protected virtual void OnTriggerEnter(Collider collider)
    {
        //this.AddJunk(collider);
    }

    protected virtual void OnTriggerExit(Collider collider)
    {
        this.RemoveJunk(collider);
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSphereCollider();
    }

    protected virtual void LoadSphereCollider()
    {
        if (this.sphereCollider != null) return;
        this.sphereCollider = GetComponent<SphereCollider>();
        this.sphereCollider.radius = 10f;
        this.sphereCollider.isTrigger = true;
        Debug.Log(transform.name + ": LoadSphereCollider", gameObject);
    }

    //protected virtual void AddJunk(Collider collider)
    //{
    //    if (collider.name != Const.TOWER_TARGETABLE) return;
    //    JunkCtrl junkCtrl = collider.transform.parent.GetComponent<JunkCtrl>();
    //    if (junkCtrl.EnemyDamageRecever.IsDead()) return;
    //    this.junks.Add(junkCtrl);
    //}

    protected virtual void RemoveJunk(Collider collider)
    {
        foreach (JunkCtrl junkCtrl in this.junks)
        {
            if (collider.transform.parent == junkCtrl.transform)
            {
                if (junkCtrl == this.nearest) this.nearest = null;
                this.junks.Remove(junkCtrl);
                return;
            }
        }
    }

    protected virtual void FindNearest()
    {
        float nearestDistance = Mathf.Infinity;
        float junkDistance;
        foreach (JunkCtrl junkCtrl in this.junks)
        {
            if (!this.CanSeeTarget(junkCtrl)) continue;

            junkDistance = Vector3.Distance(transform.position, junkCtrl.transform.position);
            if (junkDistance < nearestDistance)
            {
                nearestDistance = junkDistance;
                this.nearest = junkCtrl;
            }
        }
    }

    protected virtual bool CanSeeTarget(JunkCtrl target)
    {
        Vector3 directionToTarget = target.transform.position - transform.position;
        float distanceToTarget = directionToTarget.magnitude;

        if (Physics.Raycast(transform.position, directionToTarget, out RaycastHit hitInfo, distanceToTarget, this.obstacleLayerMask))
        {
            Vector3 directionToCollider = hitInfo.point - transform.position;
            float distanceToCollider = directionToCollider.magnitude;

            Debug.DrawRay(transform.position, directionToCollider.normalized * distanceToCollider, Color.red);
            return false;
        }

        Debug.DrawRay(transform.position, directionToTarget.normalized * distanceToTarget, Color.green);
        return true;
    }


    //protected virtual void RemoveDead()
    //{
    //    foreach (JunkCtrl junkCtrl in this.junks)
    //    {
    //        if (junkCtrl.EnemyDamageRecever.IsDead())
    //        {
    //            if (junkCtrl == this.nearest) this.nearest = null;
    //            this.junks.Remove(junkCtrl);
    //            return;
    //        }
    //    }
    //}
}
