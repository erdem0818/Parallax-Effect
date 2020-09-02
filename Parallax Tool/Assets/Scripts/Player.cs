using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterKit.Base;

public class Player : BaseObject , IUpdateable
{
    Rigidbody2D _rigidbody2d;

    [SerializeField]
    private float speed;

    public override void BaseObjectAwake()
    {
        _rigidbody2d = GetComponent<Rigidbody2D>();
    }

    public override void BaseObjecDestroy()
    {
        Debug.Log("player destroyed");
    }

    public void IUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        _rigidbody2d.velocity = new Vector2(x,y)*Time.deltaTime* speed;
    }
    
    public void IFixedUpdate()
    {
        //
    }
    
    public void ILateUpdate()
    {
        //
    }
}
