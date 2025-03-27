using System.Collections.Generic;
using UnityEngine;

public class TowerCtrl : SGMonoBehaviour
{
    [SerializeField] protected Transform sprite;
    public Transform Sprite => sprite;

    [SerializeField] protected TowerTargeting towerTargeting;
    public TowerTargeting TowerTargeting => towerTargeting;


    [SerializeField] protected BulletSpawner bulletSpawner;
    public BulletSpawner BulletSpawner => bulletSpawner;


    [SerializeField] protected string bulletName = "Bullet";


    [SerializeField] protected BulletCtrl bullet;
    public BulletCtrl Bullet => bullet;


    [SerializeField] protected List<FirePoint> firePoints = new();
    public List<FirePoint> FirePoint => firePoints;


    [SerializeField] protected BulletPrefabs bulletPrefabs;
    public BulletPrefabs BulletPrefabs => bulletPrefabs;


    [SerializeField] protected TowerShooting towerShooting;
    public TowerShooting TowerShooting => towerShooting;

    //[SerializeField] protected LevelAbstract level;
    //public LevelAbstract Level => level;    

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadTowerTargeting();
        this.LoadBulletSpawner();
        this.LoadBulletPrefabs();
        this.LoadFirePoint();
        this.LoadSprite();
        this.LoadTowerShooting();
        //this.LoadLevel();
    }

    //protected virtual void LoadLevel()
    //{
    //    if (this.level != null) return;
    //    this.level = GetComponentInChildren<LevelAbstract>();
    //    Debug.Log(transform.name + ": LoadLevel", gameObject);
    //}

    protected virtual void LoadSprite()
    {
        if (this.sprite != null) return;
        this.sprite = transform.Find("SpriteTower");
        Debug.Log(transform.name + ": LoadSprite", gameObject);
    }

    protected virtual void LoadTowerShooting()
    {
        if (this.towerShooting != null) return;
        this.towerShooting = transform.GetComponentInChildren<TowerShooting>();
        Debug.Log(transform.name + ": LoadTowerShooting", gameObject);
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
        this.bullet = this.bulletPrefabs.GetPrefabByName(this.bulletName);
        Debug.Log(transform.name + ": LoadBullet", gameObject);
    }

    protected virtual void LoadBulletPrefabs()
    {
        if (this.bulletPrefabs != null) return;
        this.bulletPrefabs = GameObject.FindAnyObjectByType<BulletPrefabs>();
        Debug.Log(transform.name + ": LoadBulletPrefabs", gameObject);

        this.LoadBullet();
    }
    

    protected virtual void LoadTowerTargeting()
    {
        if (this.towerTargeting != null) return;
        this.towerTargeting = transform.GetComponentInChildren<TowerTargeting>();
        this.towerTargeting.transform.localPosition = new Vector3(0, 0, 0);
        Debug.Log(transform.name + ": LoadTowerTargeting", gameObject);
    }

    protected virtual void LoadFirePoint()
    {
        if (this.firePoints.Count > 0) return;
        FirePoint[] points = transform.GetComponentsInChildren<FirePoint>();
        this.firePoints = new List<FirePoint>(points);
        Debug.Log(transform.name + ": LoadFirePoint", gameObject);
    }

    //protected virtual void HidePrefabs()
    //{
    //    this.bullet.gameObject.SetActive(false);
    //}
}