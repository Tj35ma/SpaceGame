using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerShooting : TowerAbtrast
{
    [SerializeField] protected float targetLoadSpeed = 0.5f;
    [SerializeField] protected int currentFirePoint = 0;
    [SerializeField] protected float shootSpeed = 0.1f;
    [SerializeField] protected float rotationSpeed = 2f;
    [SerializeField] protected JunkCtrl target;
    [SerializeField] protected BulletCtrl bullet;
    [SerializeField] public int totalKill = 0;
    [SerializeField] public int killCount = 0;
    public int KillCount => killCount;

    protected override void Start()
    {
        base.Start();
        Invoke(nameof(this.TargetLoading), this.targetLoadSpeed);
        Invoke(nameof(this.Shooting), this.shootSpeed);
    }

    protected void FixedUpdate()
    {
        this.Looking();
        this.IsTargetDead();
    }

    protected virtual void TargetLoading()
    {
        Invoke(nameof(this.TargetLoading), this.targetLoadSpeed);
        this.target = this.towerCtrl.TowerTargeting.Nearest;
    }

    protected virtual void Looking()
    {
        if (this.target == null) return;
        Vector3 direction = this.target.TowerTargetable.transform.position - this.towerCtrl.Sprite.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        this.towerCtrl.Sprite.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));
    }

    protected virtual void Shooting()
    {
        Invoke(nameof(this.Shooting), this.shootSpeed);
        if (this.target == null) return;

        FirePoint firePoint = this.GetFirePoint();
        BulletCtrl newBullet = this.towerCtrl.BulletSpawner.Spawn(this.towerCtrl.Bullet, firePoint.transform.position);

        newBullet.transform.rotation = this.towerCtrl.Sprite.rotation;
        newBullet.gameObject.SetActive(true);
    }

    protected virtual FirePoint GetFirePoint()
    {
        FirePoint firePoint = this.towerCtrl.FirePoint[this.currentFirePoint];
        this.currentFirePoint++;
        if (this.currentFirePoint == this.towerCtrl.FirePoint.Count) this.currentFirePoint = 0;
        return firePoint;
    }

    protected virtual bool IsTargetDead()
    {
        if (this.target == null) return true;
        if (!this.target.JunkDamageReceiver.IsDead()) return false;
        this.killCount++;
        this.totalKill++;
        this.target = null;
        return true;
    }

    public virtual bool DeductKillCount(int count)
    {
        if (this.killCount < count) return false;
        this.killCount -= count;
        return true;
    }
}