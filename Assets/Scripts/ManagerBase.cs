using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public abstract class ManagerBase<TSelf> : MonoBehaviour
    where TSelf : ManagerBase<TSelf>
{
    public static TSelf instance { get; private set; }
    protected virtual void Awake()
    {
        if(instance != null)
        {
            Destroy(this);
            throw new Exception($"{typeof(TSelf).Name} has already been initiated!");
        }
        instance = (TSelf)this;
        DontDestroyOnLoad(this);
   
    
    }

    protected virtual void Start()
    {

    }

    protected virtual void OnDestroy()
    {

    }
}
