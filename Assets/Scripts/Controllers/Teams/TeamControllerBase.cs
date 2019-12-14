using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

[RequireComponent(typeof(Team))]
public abstract class TeamControllerBase : ControllerBase
{
    protected Team team;

    private DateTime lastIncrement = DateTime.UtcNow;

    protected virtual void Awake()
    {
        this.team = GetComponent<Team>();
    }

    public abstract void Buy(MenuItemAsset item);

    protected virtual void Update()
    {
        if (DateTime.UtcNow > lastIncrement.AddMilliseconds(team.teamAsset.incrementInterval))
        {
            team.bankAccount.Add(team.teamAsset.incrementAmount);
            lastIncrement = DateTime.UtcNow;
        }
    }
}

