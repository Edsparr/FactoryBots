using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

[RequireComponent(typeof(BotEntity))]
[RequireComponent(typeof(EntityTracker))]
public class BotController : ControllerBase
{
    private BotEntity botEntity;

    private EntityTracker entityTracker;
    
    [field: SerializeField]
    public float speed { get; set; }
    
    [field: SerializeField]
    public float explodeRadius { get; set; }

    private void Awake()
    {

    }

    private void Start()
    {
        botEntity = GetComponent<BotEntity>();
        entityTracker = GetComponent<EntityTracker>();
        entityTracker.condition = (entity) => entity.health > 0;
        entityTracker.targetTeam = GameManager.instance.currentGame.GetTarget(botEntity.owner);
    }


    private void Update()
    {
        if (entityTracker.currentTarget != null)
        {
            float step = speed * Time.deltaTime;

            this.transform.position = Vector3.MoveTowards(transform.position, entityTracker.currentTarget.transform.position, step);

            var distance = Vector3.Distance(this.transform.position, entityTracker.currentTarget.transform.position);
            if (distance < explodeRadius)
                Explode();
            
        }
    }



    public void Explode()
    {
        botEntity.Kill();
        foreach (var entity in EntityManager.instance.GetEntities(entityTracker.targetTeam, transform.position, explodeRadius))
        {
            entity.Kill();
        }
    }
}
