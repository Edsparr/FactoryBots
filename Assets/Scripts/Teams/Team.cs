using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


[RequireComponent(typeof(TeamControllerBase))]
public class Team : MonoBehaviour
{

    [field: SerializeField]
    public BankAccount bankAccount { get; set; }

    [field: SerializeField]
    public TeamAsset teamAsset { get; set; }

    [field: SerializeField]
    public float baseLocation { get; set; }

    public TeamBaseEntity teamBase { get; private set; }

    private void Awake()
    {

    }

    private void Start()
    {
        teamBase = EntityManager.instance.SpawnEntity<TeamBaseEntity>(teamAsset.baseAsset, this, new Vector2(baseLocation, 0), null, this.transform);
    }

    public bool Contains(Vector2 position)
    {
        if (baseLocation < 0)
            return position.x < 0 && position.x > baseLocation;
        if (baseLocation > 0)
            return position.x > 0 && position.x < baseLocation;
        return false;
    }
}
