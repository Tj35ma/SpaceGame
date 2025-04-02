using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : SGMonoBehaviour
{
    [SerializeField] protected EffectSpawner effectSpawner;
    public EffectSpawner EffectSpawner => effectSpawner;

    [SerializeField] protected EffectPrefabs effectPrefabs;
    public EffectPrefabs EffectPrefabs => effectPrefabs;

    

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEffectSpawner();
        this.LoadEffectPrefabs();
    }
    
    protected virtual void LoadEffectSpawner()
    {
        if (this.effectSpawner != null) return;
        this.effectSpawner = GetComponentInChildren<EffectSpawner>();
        Debug.Log(transform.name + ": LoadEffectSpawner", gameObject);
    }

    protected virtual void LoadEffectPrefabs()
    {
        if (this.effectPrefabs != null) return;
        this.effectPrefabs = GetComponentInChildren<EffectPrefabs>();
        Debug.Log(transform.name + ": LoadEffectPrefabs", gameObject);
    }

    
    }
