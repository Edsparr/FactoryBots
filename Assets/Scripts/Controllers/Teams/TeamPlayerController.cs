using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(TeamUiRenderer))]
public class TeamPlayerController : TeamControllerBase
{
    private MenuItemAsset currentlyPlacing;

    private TeamUiRenderer teamUiRenderer;

    protected override void Awake()
    {
        base.Awake();
        teamUiRenderer = GetComponent<TeamUiRenderer>();
    }

    public override void Buy(MenuItemAsset item)
    {
        if (currentlyPlacing != null)
            return;


        currentlyPlacing = item;
    }

    protected override void Update()
    {
        base.Update();
        if(Input.GetMouseButtonDown(0) && currentlyPlacing != null)
        {
            if(!team.bankAccount.TryRemove(currentlyPlacing.buyCost))
            {
                teamUiRenderer.DisplayPrompt($"You can't afford {currentlyPlacing.buyCost}!", Color.red);
                return;
            }
            PointerEventData pointerData = new PointerEventData(EventSystem.current)
            {
                pointerId = -1,
            };

            pointerData.position = Input.mousePosition;

            List<RaycastResult> results = new List<RaycastResult>();

            EventSystem.current.RaycastAll(pointerData, results);
            if (results.Count > 0)
                return; //There are UI elements there.

            var pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (!team.Contains(pos))
                return;

            EntityManager.instance.SpawnEntity(currentlyPlacing, team, pos);
        }
        if(Input.GetKey(KeyCode.Escape) && currentlyPlacing != null)
        {
            currentlyPlacing = null;
        }
    }
}

