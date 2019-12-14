using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

[RequireComponent(typeof(TowerEntity))]
[RequireComponent(typeof(EntityTracker))]
public class TowerController : ControllerBase
{
    private TowerEntity towerEntity;
    private EntityTracker entityTracker;

    private DateTime lastFire = DateTime.UtcNow;

    private void Start()
    {
        towerEntity = GetComponent<TowerEntity>();
        entityTracker = GetComponent<EntityTracker>();
        entityTracker.targetTeam = GameManager.instance.currentGame.GetTarget(towerEntity.owner);
    }

    private void Update()
    {
        if((DateTime.UtcNow - lastFire).TotalMilliseconds > towerEntity.towerAsset.fireRate &&
            entityTracker.currentTarget != null)
        {
            Fire(entityTracker.currentTarget);
            lastFire = DateTime.UtcNow;
        }
    }

    public void Fire(Entity entity)
    {
        var projectile = EntityManager.instance.SpawnEntity(towerEntity.towerAsset.projectileAsset, towerEntity.owner, transform.position, Quaternion.identity, transform)
            .GetComponent<EntityTracker>();
        projectile.targetTeam = GameManager.instance.currentGame.GetTarget(towerEntity.owner); 
        projectile.currentTarget = entity;
        
    }
}
