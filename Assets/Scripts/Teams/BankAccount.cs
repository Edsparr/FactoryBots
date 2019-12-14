using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class BankAccount : MonoBehaviour
{
    [field: SerializeField]
    public int balance { get; set; }

    public bool TryRemove(int amount)
    {
        if (amount > balance)
            return false;
        balance -= amount;
        return true;
    }

    public void Add(int amount)
    {
        balance += amount;
    }
}

