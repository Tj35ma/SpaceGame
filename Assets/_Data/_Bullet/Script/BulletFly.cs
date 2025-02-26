using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFly : ObjectFly
{
    protected override void ResetValue()
    {
        base.ResetValue();
        this.moveSpeed = 10;
    }
}
