using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkCtrl : PoolObj
{
    [SerializeField] protected EffectEnum effectEnum = EffectEnum.Smoke;

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

    [SerializeField] protected EffectManager effectManager;
    public EffectManager EffectManager => effectManager;

    [SerializeField] protected EffectCtrl effectCtrl;
    public EffectCtrl EffectCtrl => effectCtrl;



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
        this.LoadEffectManager();
        this.LoadEffect();
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

    protected virtual void LoadEffectManager()
    {
        if (this.effectManager != null) return;
        this.effectManager = FindObjectOfType<EffectManager>();
        Debug.Log(transform.name + ": LoadEffectManager", gameObject);
    }
    

    protected virtual void LoadEffect()
    {
        if (this.effectCtrl != null) return;
        this.effectCtrl = this.effectManager.EffectPrefabs.GetEffectByEnum(this.effectEnum);
        Debug.Log(transform.name + ": LoadEffect", gameObject);
    }
}
