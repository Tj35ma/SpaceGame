using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class JunkAbstract : SGMonoBehaviour
{
    [SerializeField] protected JunkCtrl junkCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadJunkCtrl();
    }

    protected virtual void LoadJunkCtrl()
    {
        if (this.junkCtrl != null) return;
        this.junkCtrl = transform.GetComponentInParent<JunkCtrl>();
        Debug.Log(transform.name + ": Load LoadJunkCtrl", gameObject);
    }
}
