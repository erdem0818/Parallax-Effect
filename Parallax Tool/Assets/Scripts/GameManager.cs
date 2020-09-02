using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterKit.Base;
using System;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Player player;
    [SerializeField]
    private ParallaxBackGround parallaxBackGround;  

    [SerializeField]
    private BaseObject[] basedObjects;

    private void Awake()
    {
        SetUpBaseObjects();

        CallBaseObjectsAwake();
    }
    private void Start()
    {
        CallBaseObjectsStarts();
    }

    private void Update()
    {
        CallIUpdateableUpdates();
    }

    private void FixedUpdate()
    {
        CallIUpdateableFixedUpdates();
    }

    private void LateUpdate()
    {
        CallIUpdateableLateUpdates();
    }
    
    private void OnDestroy()
    {
        CallBaseObjectsDestroys();
    }

    private void SetUpBaseObjects()
    {
        basedObjects = FindObjectsOfType<BaseObject>();
    }

    private void CallBaseObjectsAwake()
    {
        foreach(var e in basedObjects)
        {
            e.BaseObjectAwake();
        }
    }

    private void CallBaseObjectsStarts()
    {
        foreach(var e in basedObjects)
        {
            e.BaseObjectStart();
        }
    }

    private void CallIUpdateableUpdates()
    {
        foreach (var e in basedObjects)
        {
            e.GetComponent<IUpdateable>().IUpdate();
        }
    }
    
    private void CallIUpdateableFixedUpdates()
    {
        foreach (var e in basedObjects)
        {
            e.GetComponent<IUpdateable>().IFixedUpdate();
        }
    }

    private void CallIUpdateableLateUpdates()
    {
        foreach (var e in basedObjects)
        {
            e.GetComponent<IUpdateable>().ILateUpdate();
        }
    }

    private void CallBaseObjectsDestroys()
    {
        foreach (var e in basedObjects)
        {
            e.BaseObjecDestroy();
        }
    }
}
