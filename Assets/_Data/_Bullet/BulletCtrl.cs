using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCtrl : PoolObj
{
    [SerializeField] protected EffectEnum effectEnum = EffectEnum.Impact;

    [SerializeField] protected BulletEnum bulletEnum;
    public override string GetName() => this.bulletEnum.ToString();

    [SerializeField] protected Transform shooter;
    public Transform Shooter => shooter;

    public virtual void SetShooter(Transform shooter) => this.shooter = shooter;

    [SerializeField] protected EffectManager effectManager;
    public EffectManager EffectManager => effectManager;

    [SerializeField] protected EffectCtrl effectCtrl;
    public EffectCtrl EffectCtrl => effectCtrl;

    protected override void OnDisable()
    {
        base.OnDisable();
        this.shooter = null;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEffectManager();
        this.LoadEffect();
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
