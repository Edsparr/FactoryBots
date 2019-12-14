using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

[RequireComponent(typeof(Projectile))]
[RequireComponent(typeof(EntityTracker))]
public class ProjectileController : ControllerBase
{
    private Projectile projectile;
    private EntityTracker entityTracker;

    private void Start()
    {
        projectile = GetComponent<Projectile>();
        entityTracker = GetComponent<EntityTracker>();
        entityTracker.targetTeam = GameManager.instance.currentGame.GetTarget(projectile.owner);
    }


    private void Update()
    {
        if (entityTracker.currentTarget == null)
        {
            EntityManager.instance.Kill(projectile);
            return;
        }

        var step = projectile.projectileAsset.projectileSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, entityTracker.currentTarget.transform.position, step);
        if (Vector3.Distance(transform.position, entityTracker.currentTarget.transform.position) < 0.1f)
            Implode(entityTracker.currentTarget);
    }

    public void Implode(Entity entity)
    {
        entity.Damage(projectile.projectileAsset.damage);
        EntityManager.instance.Kill(projectile);
    }
}

