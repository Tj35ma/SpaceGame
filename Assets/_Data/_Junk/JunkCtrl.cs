using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkCtrl : PoolObj
{
    [SerializeField] protected JunkEnum junkEnum;
    public override string GetName() => this.junkEnum.ToString();

    [SerializeField] protected Transform sprite;

    public Transform Sprite => sprite;

    [SerializeField] protected TowerTargetable towerTargetable;
    public TowerTargetable TowerTargetable => towerTargetable;

    [SerializeField] protected JunkDamageReceiver junkDamageReceiver;
    public JunkDamageReceiver JunkDamageReceiver => junkDamageReceiver;

    [SerializeField] protected JunkDespawn junkDespawn;
    public JunkDespawn JunkDespawn => junkDespawn;

    protected override void OnDisable()
    {
        base.OnDisable();       
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSprite();
        this.LoadJunkDamageReceiver();
        this.LoadJunkDespawn();
        this.LoadTowerTargetable();
    }

    protected virtual void LoadSprite()
    {
        if (this.sprite != null) return;
        this.sprite = transform.Find("SpriteJunk");
        Debug.LogWarning(transform.name + ": LoadSprite", gameObject);
    }

    protected virtual void LoadJunkDespawn()
    {
        if (this.junkDespawn != null) return;
        this.junkDespawn = GetComponentInChildren<JunkDespawn>();
        Debug.Log(transform.name + ": LoadJunkDespawn", gameObject);
    }

    protected virtual void LoadTowerTargetable()
    {
        if (this.towerTargetable != null) return;
        this.towerTargetable = transform.GetComponentInChildren<TowerTargetable>();        
        Debug.Log(transform.name + ": LoadTowerTargetable", gameObject);
    }

    protected virtual void LoadJunkDamageReceiver()
    {
        if (this.junkDamageReceiver != null) return;
        this.junkDamageReceiver = GetComponentInChildren<JunkDamageReceiver>();
        Debug.Log(transform.name + ": LoadJunkDamageReceiver", gameObject);
    }

}
