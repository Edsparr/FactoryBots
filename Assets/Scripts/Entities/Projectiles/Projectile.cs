using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

[RequireComponent(typeof(EntityTracker))]
public class Projectile : Entity
{
    public ProjectileAsset projectileAsset => (ProjectileAsset)entityAsset;


}
