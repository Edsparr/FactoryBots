using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using UnityEngine;

public class EntityManager : ManagerBase<EntityManager>
{


    private IDictionary<Team, List<Entity>> entities = new Dictionary<Team, List<Entity>>();

    public event EventHandler<Entity> EntitySpawned;
    public event EventHandler<Entity> EntityKilled;

    public Entity SpawnEntity(EntityAsset asset, Team owner, Vector2 position, Quaternion? rotation = null, Transform parent = null)
    {
        parent = parent ?? GameManager.instance.ingameObject.transform;
        var prefab = asset.entityPrefab;
        if (prefab == null)
            throw new ArgumentException($"{asset.entityPrefab.GetType().Name} does not have the same type as {asset.objectType.Name}!");

        var result = Instantiate(prefab, position, rotation ?? new Quaternion(), parent)
            .GetComponent<Entity>();

        result.Initiate(asset, owner);

        if(!entities.TryGetValue(owner, out var value))
        {
            value = new List<Entity>();
            entities.Add(owner, value);
        }
        value.Add(result);

        EntitySpawned?.Invoke(this, result);
        return result;
    }

    public T SpawnEntity<T>(EntityAsset asset, Team owner, Vector2 position, Quaternion? rotation = null, Transform parent = null) where T : Entity
    {
        return (T)this.SpawnEntity(asset, owner, position, rotation, parent);
    }

    public bool Kill(Entity entity)
    {
        if (entity == null)
            return false;

        if (!entities.TryGetValue(entity.owner, out var value))
            return false;
        Destroy(entity.gameObject);
        entity.PlayDeathAnimation();
        value.Remove(entity);

        EntityKilled?.Invoke(this, entity);

        return true;
    }

    public IEnumerable<Entity> GetEntities()
    {
        List<Entity> result = new List<Entity>();
        foreach (var entity in entities)
            result.AddRange(entity.Value);
        return result;
    }

    public IEnumerable<Entity> GetEntities(Team team)
    {
        if (team == null)
            throw new ArgumentNullException(nameof(team));

        if (!entities.TryGetValue(team, out var result))
            result = new List<Entity>();

        return result;
    }

    public IEnumerable<Entity> GetEntities(Team team, Vector3 position, float? distance = null, int? max = null, Predicate<Entity> condition = null)
    {
        List<Entity> result = new List<Entity>();
        int count = 0;
        foreach (var entity in GetEntities(team).OrderBy(c => Vector3.Distance(c.transform.position, position)))
        {

            if (!(condition?.Invoke(entity) ?? true))
                continue;

            if (max.HasValue && count == max)
                break;

            var dist = Vector3.Distance(position, entity.transform.position);
            if (distance.HasValue && dist > distance)
                break;

            count++;
            result.Add(entity);

        }
        return result;
    }




}
