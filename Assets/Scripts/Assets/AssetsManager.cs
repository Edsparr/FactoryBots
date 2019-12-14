using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class AssetsManager : ManagerBase<AssetsManager>
{

    private const string AssetsPath = "Assets/{0}";
    public T GetAsset<T>(int id) where T : Asset
    {
        var resource = Resources.Load<T>(string.Format(AssetsPath, id));
        return resource;
    }
}
