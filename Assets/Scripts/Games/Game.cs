using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class Game : MonoBehaviour
{

    [field: SerializeField]
    public Map map { get; set; }
    [field: SerializeField]
    public Team team1 { get; set; }
    [field: SerializeField]
    public Team team2 { get; set; }

    private void Awake()
    {
        Debug.Log("Initatted game!");


        team1 = Instantiate(team1, new Vector3(team1.baseLocation, 0), new Quaternion(), this.transform);
        team2 = Instantiate(team2, new Vector3(team2.baseLocation, 0), new Quaternion(), this.transform);
    }

    public Team GetTarget(Team team)
    {
        if (team == team1)
            return team2;
        if (team == team2)
            return team1;
        throw new ArgumentException(nameof(team));
    }

}

