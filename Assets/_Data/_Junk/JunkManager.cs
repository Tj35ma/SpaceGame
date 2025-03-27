using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkManager : SGMonoBehaviour
{
    [SerializeField] protected JunkSpawner junkSpawner;
    public JunkSpawner JunkSpawner => junkSpawner;

    [SerializeField] protected JunkPrefabs junkPrefabs;
    public JunkPrefabs JunkPrefabs => junkPrefabs;

    [SerializeField] protected JunkSpawnPoints junkSpawnPoints;
    public JunkSpawnPoints JunkSpawnPoints => junkSpawnPoints;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadJunkSpawner();
        this.LoadJunkPrefabs();
        this.LoadJunkSpawnPoints();
    }

    protected virtual void LoadJunkSpawnPoints()
    {
        if (this.junkSpawnPoints != null) return;
        this.junkSpawnPoints = GetComponentInChildren<JunkSpawnPoints>();
        Debug.Log(transform.name + ": LoadJunkSpawnPoints", gameObject);
    }

    protected virtual void LoadJunkSpawner()
    {
        if (this.junkSpawner != null) return;
        this.junkSpawner = GetComponentInChildren<JunkSpawner>();
        Debug.Log(transform.name + ": LoadJunkSpawner", gameObject);
    }

    protected virtual void LoadJunkPrefabs()
    {
        if (this.junkPrefabs != null) return;
        this.junkPrefabs = GetComponentInChildren<JunkPrefabs>();
        Debug.Log(transform.name + ": LoadJunkPrefabs", gameObject);
    }

}