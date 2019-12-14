using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class TeamBaseEntity : Entity
{
    protected override void Start()
    {
        base.Start();
        spriteRenderer.size = new UnityEngine.Vector2(5, GameManager.instance.currentGame.map.bounds.y);
    }
}