using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : PlayerAbstract
{
    [SerializeField] protected bool isShooting = false;
    [SerializeField] protected float shootDelay = 1f;
    [SerializeField] protected float shootTimer = 0f;
    [SerializeField] protected Transform bulletPrefab;

   
    private void FixedUpdate()
    {
        this.Shooting();        
    }

    protected virtual void Shooting()
    {
        if (InputManager.Instance.OnFiring == 0) return;

        this.shootTimer += Time.fixedDeltaTime;
        if (this.shootTimer < this.shootDelay) return;
        this.shootTimer = 0f;

        BulletCtrl newBullet = this.playerCtrl.BulletSpawner.Spawn(this.playerCtrl.Bullet, transform.position);
        Vector3 rotatorDirection = transform.parent.forward;

        newBullet.gameObject.SetActive(true);
    }
    
}
