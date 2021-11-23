using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : EntityStats
{
    public void DeathCallback()
    {
        Log($"{gameObject.name} died.");
        Destroy(gameObject);
    }
}
