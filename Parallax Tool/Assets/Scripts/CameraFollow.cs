using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterKit.Base;

public class CameraFollow : BaseObject, IUpdateable
{
    [SerializeField]
    private GameObject _target;

    [SerializeField]
    Vector3 _offset;

    [SerializeField]
    float _smooth;

    public override void BaseObjectStart()
    {
        _offset = transform.position - _target.transform.position; // for Z axis
    } 

    public void IUpdate()
    {
        //
    }
    public void IFixedUpdate()
    {
        Vector3 _camPos = _target.transform.position + _offset;
        Vector3 smoothedPos = Vector3.Lerp(transform.position , _camPos , _smooth);
        transform.position = smoothedPos;   
    }
    public void ILateUpdate()
    {
       // 
    }

}
