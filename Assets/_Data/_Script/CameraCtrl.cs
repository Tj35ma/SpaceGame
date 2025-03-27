using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCtrl : SGMonoBehaviour
{
    private static CameraCtrl instance;
    public static CameraCtrl Instance => instance;

    [SerializeField] protected Camera mainCamera;
    public Camera MainCamera => mainCamera;

    protected override void Awake()
    {
        base.Awake();
        if (CameraCtrl.instance != null) Debug.LogError("Only 1 GameManager allow to exist");
        CameraCtrl.instance = this;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCamera();
    }

    protected virtual void LoadCamera()
    {
        if (this.mainCamera != null) return;
        this.mainCamera = GetComponentInChildren<Camera>();
        Debug.Log(transform.name + ": LoadCamera", gameObject);
    }
}