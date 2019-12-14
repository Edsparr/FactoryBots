using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class GameManager : ManagerBase<GameManager>
{
    [field: SerializeField]
    public GameObject ingameObject { get; set; }

    [field: SerializeField]
    public Game gamePrefab { get; set; }

    public Game currentGame { get; private set; }

    protected override void Awake()
    {
        base.Awake();
    }

    protected override void Start()
    {
        EntityManager.instance.EntityKilled += EntityKilled;
    }

    protected override void OnDestroy()
    {
        EntityManager.instance.EntityKilled -= EntityKilled;
    }

    public void StartGame(Game game)
    {
        if (currentGame != null)
            throw new Exception("Game already started!");
        currentGame = Instantiate(game, ingameObject.transform);

        ingameObject.SetActive(true);

        MapManager.instance.SetMap(currentGame.map);

    }

    public void StopGame()
    {
        if (currentGame == null)
            throw new Exception("No game running!");
        MapManager.instance.SetMap(null);
        currentGame = null;
    }

    public void DecleareWinner(Team team)
    {
        if (currentGame == null)
            throw new Exception("Game is not running!");
        foreach (var entity in EntityManager.instance.GetEntities())
            entity.Kill();
        StopGame();
    }

    private void EntityKilled(object sender, Entity e)
    {
        if (!(e is TeamBaseEntity teamBase))
            return;

        var winner = currentGame.GetTarget(teamBase.owner);
        DecleareWinner(winner);
    }
}

