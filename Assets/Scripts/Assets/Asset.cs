using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public abstract class Asset : MonoBehaviour
{
    public int assetId { get; set; }
    public abstract Type objectType { get; }
}

