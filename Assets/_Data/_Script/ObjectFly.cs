using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFly : SGMonoBehaviour
{
    [SerializeField] protected float moveSpeed = 10f;
    [SerializeField] protected Vector3 direction = Vector3.up;   
    
    void Update()
    {
        transform.parent.Translate(this.direction * this.moveSpeed * Time.deltaTime);
    }    
}
