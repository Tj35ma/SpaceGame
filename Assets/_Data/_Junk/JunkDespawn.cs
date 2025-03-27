using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkDespawn : Despawn<JunkCtrl>
{
    protected override void ResetValue()
    {
        base.ResetValue();
        this.timeLife = 7f;
        this.currentTime = 7f;
    }
}
