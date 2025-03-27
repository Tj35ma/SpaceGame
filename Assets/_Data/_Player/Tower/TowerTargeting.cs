using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
public class TowerTargeting : SGMonoBehaviour
{
    [SerializeField] protected Rigidbody2D rigid;
    [SerializeField] protected CircleCollider2D circleCollider;

    [SerializeField] protected JunkCtrl nearest;
    public JunkCtrl Nearest => nearest;

    [SerializeField] protected LayerMask obstacleLayerMask = -1;

    [SerializeField] protected List<JunkCtrl> targets = new();

    protected virtual void FixedUpdate()
    {
        this.FindNearest();
        this.RemoveDeadEnemy();
    }

    protected virtual void OnTriggerEnter2D(Collider2D collider)
    {
        this.AddEnemy(collider);
    }

    protected virtual void OnTriggerExit2D(Collider2D collider)
    {
        this.RemoveEnemy(collider);
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCircleCollider();
        this.LoadRigidbody2D();
    }

    protected virtual void LoadCircleCollider()
    {
        if (this.circleCollider != null) return;
        this.circleCollider = GetComponent<CircleCollider2D>();
        this.circleCollider.radius = 4f;
        this.circleCollider.isTrigger = true;
        Debug.Log(transform.name + ": LoadCircleCollider", gameObject);
    }

    protected virtual void LoadRigidbody2D()
    {
        if (this.rigid != null) return;
        this.rigid = GetComponent<Rigidbody2D>();        
        Debug.Log(transform.name + ": LoadRigidbody2D", gameObject);
    }

    protected virtual void AddEnemy(Collider2D collider)
    {
        if (collider.name != Const.TOWER_TARGETABLE) return;
        JunkCtrl junkCtrl = collider.transform.parent.GetComponent<JunkCtrl>();

        if (junkCtrl == null || junkCtrl.JunkDamageReceiver.IsDead()) return;
        this.targets.Add(junkCtrl);
    }

    protected virtual void RemoveEnemy(Collider2D collider)
    {
        var parentTransform = collider.transform.parent;
        if (parentTransform == null) return;

        JunkCtrl junkCtrl = parentTransform.GetComponent<JunkCtrl>();
        if (junkCtrl == null) return;

        if (junkCtrl == this.nearest) this.nearest = null;
        this.targets.Remove(junkCtrl);
    }

    protected virtual void FindNearest()
    {
        float nearestDistance = Mathf.Infinity;
        float targetDistance;
        foreach (JunkCtrl junkCtrl in this.targets)
        {
            if (!this.CanSeeTarget(junkCtrl)) continue;

            targetDistance = Vector3.Distance(transform.position, junkCtrl.transform.position);
            if (targetDistance < nearestDistance)
            {
                nearestDistance = targetDistance;
                this.nearest = junkCtrl;
            }
        }
    }

    protected virtual bool CanSeeTarget(JunkCtrl target)
    {
        Vector3 directionToTarget = target.transform.position - transform.position;
        float distanceToTarget = directionToTarget.magnitude;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, directionToTarget, distanceToTarget, this.obstacleLayerMask);
        if (hit.collider != null && hit.collider.gameObject != this.gameObject)
        {
            Debug.Log("Raycast hit object: " + hit.collider.gameObject.name);
            Debug.DrawRay(transform.position, directionToTarget.normalized * distanceToTarget, Color.red);
            return false;
        }

        Debug.DrawRay(transform.position, directionToTarget.normalized * distanceToTarget, Color.green);
        return true;
    }


    protected virtual void RemoveDeadEnemy()
    {
        List<JunkCtrl> deadEnemies = new List<JunkCtrl>();
        foreach (JunkCtrl junkCtrl in this.targets)
        {
            if (junkCtrl.JunkDamageReceiver.IsDead())
            {
                if (junkCtrl == this.nearest) this.nearest = null;
                deadEnemies.Add(junkCtrl);
            }
        }

        foreach (JunkCtrl deadEnemy in deadEnemies)
        {
            this.targets.Remove(deadEnemy);
        }
    }
}
