using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugCombat : MonoBehaviour
{
    public EntityStats target;
    public int damage;

    private EntityStats myStats;

    private void Start()
    {
        myStats = GetComponent<EntityStats>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            target.TakeDamage(myStats.damage.Value);
        }
    }
}
