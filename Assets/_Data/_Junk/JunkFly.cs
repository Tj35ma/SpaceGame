using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkFly : ObjectFly
{
    protected override void ResetValue()
    {
        base.ResetValue();
        this.moveSpeed = 1f;
    }
}
