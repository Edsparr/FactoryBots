using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


public class ProjectileAsset : EntityAsset
{
    [field: SerializeField]
    public float projectileSpeed { get; set; } 
}
