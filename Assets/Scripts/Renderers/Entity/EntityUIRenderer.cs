using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

[RequireComponent(typeof(Entity))]
public class EntityUIRenderer : RendererBase
{
    private Entity entity;

    [field: SerializeField]
    public GameObject bar { get; set; }
    [field: SerializeField]
    public GameObject background { get; set; }
    private void Start()
    {
        entity = GetComponent<Entity>();
        entity.HealthUpdated += HealthUpdated;
    }

    private void OnDestroy()
    {
        entity.HealthUpdated -= HealthUpdated;
    }
    private void HealthUpdated(object sender, int e)
    {
        var fullScale = background.transform.localScale;
        var percent = ((float)e / entity.entityAsset.health) * fullScale.x;

        bar.transform.localScale = new Vector3(percent, bar.transform.localScale.x, bar.transform.localScale.z);

    }
}
