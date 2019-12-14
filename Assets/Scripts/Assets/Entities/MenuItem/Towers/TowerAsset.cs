using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class TowerAsset : MenuItemAsset
{
    [field: SerializeField]
    public float fireRate { get; set; }

    [field: SerializeField]
    public ProjectileAsset projectileAsset { get; set; }

}

