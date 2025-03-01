using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Despawn<T> : DespawnBase where T : PoolObj
{
    [SerializeField] protected T parent;
    [SerializeField] protected Spawner<T> spawner;
    [SerializeField] protected float timeLife = 2f;
    [SerializeField] protected float currentTime = 2f;
    [SerializeField] protected bool isDespawnByTime = true;

    protected override void OnDisable()
    {
        base.OnDisable();
        this.StopCoroutine(this.DespawnCheckingCoroutine());


    }
    protected override void OnEnable()
    {
        base.OnEnable();
        this.StartCoroutine(this.DespawnCheckingCoroutine());

    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadParent();
        this.LoadSpawner();
    }

    protected virtual void LoadParent()
    {
        if (this.parent != null) return;
        this.parent = transform.parent.GetComponent<T>();
        Debug.Log(transform.name + "Load Parent", gameObject);
    }
    protected virtual void LoadSpawner()
    {
        if (this.spawner != null) return;
        this.spawner = GameObject.FindAnyObjectByType<Spawner<T>>();
        Debug.Log(transform.name + "LoadSpawner", gameObject);
    }

    public override void DespawnObj()
    {
        this.spawner.Despawn(this.parent);
    }

    protected virtual IEnumerator DespawnCheckingCoroutine()
    {
        while (true)
        {
            if (!this.isDespawnByTime)
            {
                yield return null;
                continue;
            }
            this.currentTime -= Time.deltaTime;
            if (this.currentTime <= 0)
            {
                this.DespawnObj();
                this.currentTime = this.timeLife;
            }

            yield return null;
        }
    }
}