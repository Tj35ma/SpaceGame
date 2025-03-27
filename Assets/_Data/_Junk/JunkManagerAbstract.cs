using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class JunkManagerAbstract : SGMonoBehaviour
{
    [SerializeField] protected JunkManager junkManager;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadJunkManager();
    }

    protected virtual void LoadJunkManager()
    {
        if (junkManager != null) return;
        this.junkManager = transform.GetComponentInParent<JunkManager>();
        Debug.Log(transform.name + ": LoadJunkManager", gameObject);
    }
}