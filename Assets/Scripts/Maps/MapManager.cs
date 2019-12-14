using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class MapManager : ManagerBase<MapManager>
{
    [field: SerializeField]
    public SpriteRenderer backgroundRenderer { get; set; }

    public void SetMap(Map map)
    {
        backgroundRenderer.sprite = map?.mapSprite;

        //Set background to map etc
    }
}

