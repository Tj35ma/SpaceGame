using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectPrefabs : PoolPrefabs<EffectCtrl>
{
    public virtual EffectCtrl GetEffectByEnum(EffectEnum effectEnum)
    {
        return this.GetPrefabByName(effectEnum.ToString());
    }
}
