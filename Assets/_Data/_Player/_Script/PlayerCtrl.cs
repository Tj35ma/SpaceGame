using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : SGMonoBehaviour
{
    protected BulletEnum bulletEnum;
    public BulletEnum BulletEnum => bulletEnum;

    [SerializeField] protected PlayerMoving playerMoving;
    public PlayerMoving PlayerMoving => playerMoving;


    [SerializeField] protected PlayerShooting playerShooting;
    public PlayerShooting PlayerShooting => playerShooting;

    [SerializeField] protected BulletCtrl bullet;
    public BulletCtrl Bullet => bullet;

    [SerializeField] protected BulletSpawner bulletSpawner;
    public BulletSpawner BulletSpawner => bulletSpawner;


    [SerializeField] protected BulletPrefabs bulletPrefabs;
    public BulletPrefabs BulletPrefabs => bulletPrefabs;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPlayerMoving();
        this.LoadPlayerShooting();
        this.LoadBulletSpawner();
        this.LoadBulletPrefabs();
        this.LoadBullet();
    }

    protected virtual void LoadBulletSpawner()
    {
        if (this.bulletSpawner != null) return;
        this.bulletSpawner = FindObjectOfType<BulletSpawner>();
        Debug.Log(transform.name + ": LoadBulletSpawner", gameObject);
    }

    protected virtual void LoadBullet()
    {
        if (this.bullet != null) return;
        this.bullet = this.bulletPrefabs.GetBulletByEnum(this.bulletEnum.Bullet);
        Debug.Log(transform.name + ": LoadBullet", gameObject);
    }

    protected virtual void LoadBulletPrefabs()
    {
        if (this.bulletPrefabs != null) return;
        this.bulletPrefabs = GameObject.FindAnyObjectByType<BulletPrefabs>();
        Debug.Log(transform.name + ": LoadBulletPrefabs", gameObject);

        this.LoadBullet();
    }

    protected virtual void LoadPlayerMoving()
    {
        if (this.playerMoving != null) return;
        this.playerMoving = transform.GetComponentInChildren<PlayerMoving>();
        Debug.Log(transform.name + ": LoadPlayerMoving", gameObject);
    }

    protected virtual void LoadPlayerShooting()
    {
        if (this.playerShooting != null) return;
        this.playerShooting = transform.GetComponentInChildren<PlayerShooting>();
        Debug.Log(transform.name + ": LoadPlayerShooting", gameObject);
    }
}
