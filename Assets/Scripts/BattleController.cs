using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleController : MonoBehaviour
{
    [Header("Debug Tools")]
    public bool showDebugMessages;

    public enum State
    {
        IDLE,
        PLAYER_TURN,
        ENEMY_TURN
    }

    public State state = State.IDLE;

    public EntityStats player;
    public EntityStats enemy;
    public GameObject playerTurnUI;

    public float enemyCooldownTimer = 1f;
    private float currentEnemyCooldownTimer;

    private void Start()
    {
        StartBattle();
    }

    private void Update()
    {
        if (state == State.PLAYER_TURN)
        {
            playerTurnUI.SetActive(true);
        }
        else
        {
            playerTurnUI.SetActive(false);
        }

        if (currentEnemyCooldownTimer <= 0 && state == State.ENEMY_TURN)
        {
            Log($"{enemy.gameObject.name} attacks {player.gameObject.name}");
            player.TakeDamage(enemy.damage.Value);

            Log($"{player.gameObject.name}'s turn...");
            state = State.PLAYER_TURN;
        }

        currentEnemyCooldownTimer -= Time.deltaTime;
    }

    public void StartBattle()
    {
        // figure out who goes first depending on speed
        if (player.speed.Value > enemy.speed.Value)
        {
            Log($"{player.gameObject.name} has a higher speed so they move first");
            state = State.PLAYER_TURN;
        }
        else if (player.speed.Value < enemy.speed.Value)
        {
            Log($"{enemy.gameObject.name} has a higher speed so they move first");
            state = State.ENEMY_TURN;
        }
        else
        {
            Log($"{player.gameObject.name} and {enemy.gameObject.name} both have the same speed so a random entity will be chosen to go first");
            state = (State)Random.Range(1, 3);
        }
    }

    public void PlayerAttack()
    {
        Log($"{player.gameObject.name} attacks {enemy.gameObject.name}");

        // use the return int from the enemy's TakeDamage method and perform things based on the value
        switch(enemy.TakeDamage(player.damage.Value))
        {
            case 2:
                Log($"{enemy.gameObject.name} killed, going idle...");
                state = State.IDLE;
                break;
            default:
                Log($"{enemy.gameObject.name}'s turn...");
                state = State.ENEMY_TURN;
                currentEnemyCooldownTimer = enemyCooldownTimer;
                break;
        }
    }

    protected void Log(string _message)
    {
        if (showDebugMessages) Debug.Log(_message);
    }
}