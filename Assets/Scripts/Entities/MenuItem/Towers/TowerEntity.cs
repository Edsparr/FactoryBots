using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class TowerEntity : MenuItemEntity
{
    public TowerAsset towerAsset { get; private set; }

    protected override void Start()
    {
        base.Start();
        towerAsset = (TowerAsset)entityAsset;
    }
}

