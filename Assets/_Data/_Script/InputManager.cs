using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputManager : SGSingleton<InputManager>
{
    
    [SerializeField] protected Vector3 mouseWorldPos;
    
    public Vector3 MouseWorldPos => mouseWorldPos;

    [SerializeField] protected float onFiring;

    public float OnFiring => onFiring;

    private void Update()
    {
        this.GetMouseDown();
    }

    void FixedUpdate()
    {
        this.GetMousePos();
    }

    protected virtual void GetMouseDown()
    {
        this.onFiring = Input.GetAxis("Fire1");

    }

    protected virtual void GetMousePos()
    {
        this.mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

    }
}
