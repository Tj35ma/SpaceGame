using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]

public class JunkDamageReceiver : DamageReceiver
{
    [SerializeField] protected float disappearTime = 0.2f;
    [SerializeField] protected CircleCollider2D circleCollider;
    [SerializeField] protected JunkCtrl junkCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSphereCollider();
        this.LoadEnemyCtrl();
    }

    protected virtual void LoadSphereCollider()
    {
        if (circleCollider != null) return;
        this.circleCollider = GetComponent<CircleCollider2D>();
        this.circleCollider.radius = 0.4f;
        Debug.Log(transform.name + ": LoadSphereCollider", gameObject);
    }

    protected virtual void LoadEnemyCtrl()
    {

        if (this.junkCtrl != null) return;
        this.junkCtrl = transform.parent.GetComponent<JunkCtrl>();
        Debug.Log(transform.name + ": LoadEnemyCtrl", gameObject);
    }

    protected override void OnDead()
    {
        base.OnDead();
        //this.junkCtrl.Animator.SetBool("isDead", this.isDead);
        this.circleCollider.enabled = false;
        this.RewardOnDead();
        Invoke(nameof(this.Disappear), this.disappearTime);
    }

    protected override void OnHurt()
    {
        base.OnHurt();
        //this.junkCtrl.Animator.SetTrigger("isHurt");
    }

    protected virtual void Disappear()
    {
        this.junkCtrl.DespawnBase.DoDespawn();
        if (this.junkCtrl.JunkDespawn != null)
        {
            this.junkCtrl.JunkDespawn.RebornByTime();
        }
    }

    protected override void OnReborn()
    {
        base.OnReborn();
        this.circleCollider.enabled = true;
    }

    protected virtual void RewardOnDead()
    {
        //ItemsDropManager.Instance.DropMany(ItemEnum.Gold, 10, transform.position);
        //ItemsDropManager.Instance.DropMany(ItemEnum.PotionMana, 1, transform.position);
        //ItemsDropManager.Instance.DropMany(ItemEnum.PlayerExp, 2, transform.position);
    }
}