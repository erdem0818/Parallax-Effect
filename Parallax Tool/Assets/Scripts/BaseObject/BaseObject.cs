using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StarterKit.Base
{
    //TODO interface segregation issue , IUpdateable ?
    public class BaseObject : MonoBehaviour
{
    public virtual void BaseObjectAwake()
    {

    }

    public virtual void BaseObjectStart()
    {
        
    }

    /*public virtual void BaseObjectLateUpdate()
    {
        
    }

    public virtual void BaseObjectFixedUpdate()
    {
        
    }

    public virtual void BaseObjectUpdate()
    {
        
    }*/

    public virtual void BaseObjecDestroy()
    {
        
    }
}
}
