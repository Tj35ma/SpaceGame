using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkFly : ObjectFly
{
    [SerializeField] protected float minCamPos = -9f;
    [SerializeField] protected float maxCamPos = 9f;

    protected override void ResetValue()
    {
        base.ResetValue();
        this.moveSpeed = 1f;
        this.direction = Vector3.right;
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        this.GetFlyDirection();
    }
    protected virtual void GetFlyDirection()
    {
        Vector3 camPos = this.GetCamPos();
        Vector3 objPos = transform.parent.position;

        camPos.x += Random.Range(this.minCamPos, this.maxCamPos);
        camPos.z += Random.Range(this.minCamPos, this.maxCamPos);

        Vector3 diff = camPos - objPos;
        diff.Normalize();
        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.parent.rotation = Quaternion.Euler(0f, 0f, rot_z);

        //this.direction = (pos - transform.position).normalized;
        Debug.DrawLine(objPos, objPos + diff * 7, Color.red, Mathf.Infinity);
    }

    protected virtual Vector3 GetCamPos()
    {
        if (CameraCtrl.Instance == null) return Vector3.zero;

        Vector3 camPos = CameraCtrl.Instance.MainCamera.transform.position;
        return camPos;
    }
}
