using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class PlayerController : ControllerBase
{
    private static Dictionary<KeyCode, Vector2> keys = new Dictionary<KeyCode, Vector2>()
    {
        { KeyCode.A, new Vector2(-0.1f, 0) },
        { KeyCode.D, new Vector2(0.1f, 0) }
    };

    private void Awake()
    {

    }

    private void Start()
    {
        GameManager.instance.StartGame(GameManager.instance.gamePrefab);
    }

    private void Update()
    {
        if (GameManager.instance.currentGame != null)
            MoveIngame();
    }

    private void MoveIngame()
    {
        Vector2 result = Vector2.zero;
        foreach (var key in keys)
        {
            if (Input.GetKey(key.Key))
                result += key.Value;
        }
        var newPosition = transform.position + (Vector3)result;
        Debug.Log($"Moving camera to: {newPosition}!");

        var cameraBounds = GameManager.instance.currentGame.map.bounds;


        var boundsRight = cameraBounds.x;
        var boundsLeft = cameraBounds.x * -1;

        if (newPosition.x >= boundsRight)
            newPosition.x = boundsRight;

        if (newPosition.x <= boundsLeft)
            newPosition.x = boundsLeft;

        Debug.Log($"Bounds right: {boundsRight}, bounds left: {boundsLeft}!");

        transform.position = newPosition;
    }
}