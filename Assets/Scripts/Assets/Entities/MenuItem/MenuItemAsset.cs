using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public abstract class MenuItemAsset : EntityAsset
{
    [field: SerializeField]
    public int buyCost { get; set; }
}
