using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class TowerTargetable : SGMonoBehaviour
{
    [SerializeField] protected CircleCollider2D circleCollider2D;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCircleCollider2D();
    }

    protected virtual void LoadCircleCollider2D()
    {
        if (this.circleCollider2D != null) return;
        this.circleCollider2D = GetComponent<CircleCollider2D>();
        this.circleCollider2D.isTrigger = true;
        Debug.Log(transform.name + ": LoadCircleCollider2D", gameObject);
    }
}