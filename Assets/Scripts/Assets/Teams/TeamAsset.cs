using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class TeamAsset : Asset
{
    public override Type objectType => typeof(Team);

    [field: SerializeField]
    public int incrementAmount { get; set; }
    [field: SerializeField]
    public double incrementInterval { get; set; }

    [field: SerializeField]
    public MenuItemAsset[] buyables { get; set; }

    [field: SerializeField]
    public TeamBaseEntityAsset baseAsset { get; set; }

}
