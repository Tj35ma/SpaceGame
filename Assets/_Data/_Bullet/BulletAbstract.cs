using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BulletAbstract : SGMonoBehaviour
{
    [SerializeField] protected BulletCtrl bulletCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBulletCtrl();
    }

    protected virtual void LoadBulletCtrl()
    {
        if (this.bulletCtrl != null) return;
        this.bulletCtrl = transform.GetComponentInParent<BulletCtrl>();
        Debug.Log(transform.name + ": Load BulletCtrl", gameObject);
    }
}
