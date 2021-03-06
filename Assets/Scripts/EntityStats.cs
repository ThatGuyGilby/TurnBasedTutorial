using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class EntityStats : MonoBehaviour
{
    [Header("Debug Tools")]
    public bool showDebugMessages;

    [Header("Stats")]
    public float currentHealth;
    public float maxHealth = 10;
    public Stat damage;
    public Stat armour;

    [Header("Events")]
    public UnityEvent onDeath;

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    public bool TakeDamage(int _damage)
    {
        Log($"_damage before armour: {_damage}");

        _damage -= armour.Value;

        Log($"_damage after armour: {_damage}");

        if (_damage <= 0)
        {
            Log($"Damage was below 0 so the method is exiting: {_damage}");
            return false;
        }

        Log($"currentHealth before damage: {currentHealth}");

        currentHealth -= _damage;

        Log($"currentHealth after damage: {currentHealth}");

        if (currentHealth <= 0)
        {
            Die();
        }

        return true;
    }

    public virtual void Die()
    {
        if (onDeath != null)
        {
            onDeath.Invoke();
        }
    }

    protected void Log(string _message)
    {
        if (showDebugMessages) Debug.Log(_message);
    }
}
