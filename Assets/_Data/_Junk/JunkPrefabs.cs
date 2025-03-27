using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkPrefabs : JunkManagerAbstract
{
    [SerializeField] protected List<JunkCtrl> prefabs = new();

    protected override void Awake()
    {
        base.Awake();
        this.HidePrefabs();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadJunkPrefabs();
    }

    protected virtual void LoadJunkPrefabs()
    {
        if (this.prefabs.Count > 0) return;
        foreach (Transform child in transform)
        {
            JunkCtrl junkCtrl = child.GetComponent<JunkCtrl>();
            if (junkCtrl) this.prefabs.Add(junkCtrl);
        }
        Debug.Log(transform.name + ": LoadJunkPrefabs", gameObject);
    }

    protected virtual void HidePrefabs()
    {
        foreach (JunkCtrl junkCtrl in this.prefabs)
        {
            junkCtrl.gameObject.SetActive(false);
        }
    }

    public virtual JunkCtrl GetRandom()
    {
        int rand = Random.Range(0, this.prefabs.Count);
        return this.prefabs[rand];
    }
}