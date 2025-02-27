using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkSpawnPoints : SpawnPoints
{
    [SerializeField] protected JunkSpawnCtrl junkSpawnCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadJunkSpawnCtrl();
    }

    protected virtual void LoadJunkSpawnCtrl()
    {
        if (this.junkSpawnCtrl != null) return;
        this.junkSpawnCtrl = transform.GetComponent<JunkSpawnCtrl>();
        Debug.Log(transform.name + ": LoadJunkSpawnCtrl", gameObject);
    }

    protected virtual void JunkSpawning()
    {
        Transform ranPoint = this.GetRandom();
        Vector3 pos = ranPoint.position;
        Quaternion rot = transform.rotation;
        JunkCtrl obj = this.junkSpawnCtrl.JunkSpawner.Spawn(this.junkSpawnCtrl.Meteorite, transform.position);
        obj.gameObject.SetActive(true);

        Invoke(nameof(this.JunkSpawning), 1f);
    }
}
