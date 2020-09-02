using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUpdateable 
{
    void IUpdate();

    void ILateUpdate();

    void IFixedUpdate();
}
