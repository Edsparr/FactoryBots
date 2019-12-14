using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class EntityTracker : MonoBehaviour
{
    public Entity currentTarget { get; set; }

    public Team targetTeam { get; set; }

    public Predicate<Entity> condition { get; set; }

    private void Start()
    {
        EntityManager.instance.EntityKilled += EntityKilled;
        EntityManager.instance.EntitySpawned += EntitySpawned;
        UpdateTarget();
    }

    private void OnDestroy()
    {
        EntityManager.instance.EntityKilled -= EntityKilled;
        EntityManager.instance.EntitySpawned -= EntitySpawned;

    }
    public bool UpdateTarget()
    {
        if (targetTeam == null)
            return false;

        currentTarget = EntityManager.instance.GetEntities(targetTeam, transform.position, null, 1, condition)?.FirstOrDefault();

        return currentTarget != null;
    }

    private void EntityKilled(object sender, Entity e)
    {
        UpdateTarget();
    }

    private void EntitySpawned(object sender, Entity e)
    {
        UpdateTarget();
    }
}
