using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : EntityStats
{
    public void DeathCallback()
    {
        Log($"{gameObject.name} died.");
        Destroy(gameObject);
    }
}
