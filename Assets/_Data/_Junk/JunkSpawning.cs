using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkSpawning : JunkManagerAbstract
{
    [SerializeField] protected float spawnSpeed = 1f;
    [SerializeField] protected int maxSpawn = 100;
    protected List<JunkCtrl> spawnedJunks = new();

    protected override void Start()
    {
        base.Start();
        Invoke(nameof(this.Spawning),this.spawnSpeed);
    }

    protected virtual void FixedUpdate()
    {
        this.RemoveDeadOne();

    }

    protected virtual void Spawning()
    {
        Invoke(nameof(this.Spawning), this.spawnSpeed);
        if(this.spawnedJunks.Count > this.maxSpawn) return;

        JunkCtrl prefab = this.junkManager.JunkPrefabs.GetRandom();
        Transform posSpawn = this.junkManager.JunkSpawnPoints.GetRandom();
        JunkCtrl newEnemy = this.junkManager.JunkSpawner.Spawn(prefab, posSpawn.position);
        newEnemy.gameObject.SetActive(true);

        this.spawnedJunks.Add(newEnemy);        
    }

    protected virtual void RemoveDeadOne()
    {
        foreach (JunkCtrl junkCtrl in this.spawnedJunks)
        {
            if (junkCtrl.JunkDamageReceiver.IsDead())
            {
                this.spawnedJunks.Remove(junkCtrl);
                return;
            }
        }
    }

}