using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class TeamBotController : TeamControllerBase
{
    private DateTime lastBuy = DateTime.UtcNow;

    [field: SerializeField]
    public float tryBuyInterval { get; set; }

    public override void Buy(MenuItemAsset item)
    {
        if (!team.bankAccount.TryRemove(item.buyCost))
            return;
        var pos = UnityEngine.Random.Range(0, team.baseLocation);
        var yBounds = GameManager.instance.currentGame.map.bounds.y; 
        EntityManager.instance.SpawnEntity(item, team, new UnityEngine.Vector2(pos, UnityEngine.Random.Range(yBounds *-1, yBounds)), null, transform);
    }

    protected override void Update()
    {
        base.Update();
        if((DateTime.UtcNow - lastBuy).TotalMilliseconds > tryBuyInterval)
        {
            lastBuy = DateTime.UtcNow;
            var index = UnityEngine.Random.Range(0, this.team.teamAsset.buyables.Length);
            var buyThis = team.teamAsset.buyables.ElementAt(index);
            Buy(buyThis);
        }
    }
}

