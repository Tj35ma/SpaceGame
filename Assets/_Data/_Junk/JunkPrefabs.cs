using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkPrefabs : PoolPrefabs<JunkCtrl>
{
    public virtual JunkCtrl GetBulletByEnum(JunkEnum junkEnum)
    {
        return this.GetPrefabByName(junkEnum.ToString());
    }
}
