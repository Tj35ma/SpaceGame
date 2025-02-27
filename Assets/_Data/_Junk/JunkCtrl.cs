using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkCtrl : PoolObj
{
    [SerializeField] protected JunkEnum junkEnum;
    public override string GetName() => this.junkEnum.ToString();
   

    protected override void OnDisable()
    {
        base.OnDisable();       
    }
}
