using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkSpawnCtrl : SGMonoBehaviour
{
    protected JunkEnum junkEnum;
    public JunkEnum JunkEnum => junkEnum;

    [SerializeField] protected string junkName = "Meteorite";

    [SerializeField] protected JunkCtrl meteorite;
    public JunkCtrl Meteorite => meteorite;

    [SerializeField] protected JunkSpawner junkSpawner;
    public JunkSpawner JunkSpawner => junkSpawner;


    [SerializeField] protected JunkPrefabs junkPrefabs;
    public JunkPrefabs JunkPrefabs => junkPrefabs;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadJunkSpawner();
        this.LoadMeteorite();
        this.LoadJunkPrefabs();
    }

    protected virtual void LoadJunkSpawner()
    {
        if (this.junkSpawner != null) return;
        this.junkSpawner = FindObjectOfType<JunkSpawner>();
        Debug.Log(transform.name + ": LoadJunkSpawner", gameObject);
    }

    protected virtual void LoadMeteorite()
    {
        if (this.meteorite != null) return;
        this.meteorite = this.junkPrefabs.GetPrefabByName(this.junkName);
        Debug.Log(transform.name + ": LoadMeteorite", gameObject);
    }

    protected virtual void LoadJunkPrefabs()
    {
        if (this.junkPrefabs != null) return;
        this.junkPrefabs = GameObject.FindAnyObjectByType<JunkPrefabs>();
        Debug.Log(transform.name + ": LoadJunkPrefabs", gameObject);

        this.LoadMeteorite();
    }
}
