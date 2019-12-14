using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public abstract class EntityAsset : Asset
{
    public override Type objectType { get { return typeof(Entity); } }

    [field: SerializeField]
    public string displayName { get; set; }
    [field: SerializeField]
    public Sprite sprite { get;set; }
    [field: SerializeField]
    public Entity entityPrefab { get; set; }

    [field: SerializeField]
    public int health { get; set; }

    [field: SerializeField]
    public int damage { get; set; }
}
