using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]


public abstract class DamageSender : SGMonoBehaviour
{
    [SerializeField] protected int damage = 2;
    [SerializeField] protected Rigidbody2D rigid;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadRigidbody2D();
    }

    public virtual void OnTriggerEnter2D(Collider2D collider)
    {
        DamageReceiver damageReceiver = collider.GetComponent<DamageReceiver>();
        if (damageReceiver == null) return;
        this.Send(damageReceiver);
        Debug.Log("OnTriggerEnter2D: " + collider.name);
    }

    protected virtual void Send(DamageReceiver damageRecever)
    {
        damageRecever.Deduct(this.damage);
    }

    protected virtual void LoadRigidbody2D()
    {
        if (rigid != null) return;
        this.rigid = GetComponent<Rigidbody2D>();
        Debug.Log(transform.name + ": LoadRigidbody", gameObject);
    }
}