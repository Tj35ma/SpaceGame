using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectCtrl : PoolObj
{
    [SerializeField] protected EffectEnum effectEnum;
    public override string GetName() => this.effectEnum.ToString();

    protected override void OnDisable()
    {
        base.OnDisable();
    }
}
