using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


public class Map : MonoBehaviour
{
    [field: SerializeField]
    public Sprite mapSprite { get; set; }

    [field: SerializeField]
    public Vector2 bounds { get; set; }

}
