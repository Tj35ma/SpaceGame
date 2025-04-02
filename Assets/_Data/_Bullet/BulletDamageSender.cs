using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]

public class BulletDamageSender : DamageSender
{
    [SerializeField] protected BulletCtrl bulletCtrl;
    [SerializeField] protected CircleCollider2D circleCollider;

    

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCircleCollider2D();
        this.LoadBulletCtrl();        
    }

    protected virtual void LoadCircleCollider2D()
    {
        if (circleCollider != null) return;
        this.circleCollider = GetComponent<CircleCollider2D>();
        this.circleCollider.radius = 0.05f;
        this.circleCollider.isTrigger = true;
        Debug.Log(transform.name + ": LoadCircleCollider2D", gameObject);
    }

    

    protected virtual void LoadBulletCtrl()
    {
        if (bulletCtrl != null) return;
        this.bulletCtrl = GetComponentInParent<BulletCtrl>();
        Debug.Log(transform.name + ": LoadBulletCtrl", gameObject);
    }
    protected override void Send(DamageReceiver damageReceiver)
    {
        base.Send(damageReceiver);
        this.CreateImpactFX();
        this.bulletCtrl.DespawnBase.DoDespawn();
    }

    protected virtual void CreateImpactFX()
    {
        EffectCtrl impactFX = this.bulletCtrl.EffectManager.EffectSpawner.Spawn(this.bulletCtrl.EffectCtrl, transform.position);
        impactFX.transform.rotation = transform.rotation;
        impactFX.gameObject.SetActive(true);
    }
}