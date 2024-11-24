using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class MonsterControlScript : MonoBehaviour
{
    [SerializeField] private MovementScript movementScript;
    [SerializeField] private float monsterTime;
    [SerializeField][Range(0f, 1f)] private float chasePlayerChance = 0.25f;

    [SerializeField] private float rotateToPlayerSpeed = 10;
    [SerializeField] private float minRandomRotation = -20;
    [SerializeField] private float maxRandomRotation = 20f;
    
    private float _monsterTimer;
    private bool _chasePlayer;

    private PlayerControlScript.PlayerInput _monsterInput;

    private Transform _playerTransform;
    

    private void Start()
    {
        _monsterInput = new PlayerControlScript.PlayerInput
        {
            axisInput = Vector2.up,
            isJumpPressed = false
        };

        _playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        RandomizeMonsterStrategy();
        RotateMonsterIfNecessary();
        movementScript.MovePlayer(_monsterInput);
    }

    private void RandomizeMonsterStrategy()
    {
        if (_monsterTimer > monsterTime)
        {
            _monsterTimer = 0f;
            ChangeMonsterStrategy();
        }
        else
        {
            _monsterTimer += Time.deltaTime;
        }
    }

    private void RotateMonsterIfNecessary()
    {
        if (_playerTransform == null) return;
        
        var rot = 0f;
        if (_chasePlayer)
        {
            var dirToPlayer = _playerTransform.position - transform.position;
            dirToPlayer.y = 0;
            var monsterDir = new Vector3(transform.forward.x, 0f, transform.forward.z);
            var angleDiff = Vector3.SignedAngle(dirToPlayer, monsterDir, Vector3.up);

            rot = Mathf.Abs(angleDiff) > 0.5f ? rotateToPlayerSpeed * -Mathf.Sign(angleDiff) * Time.deltaTime : 0f;
        }
        else
        {
            rot = Random.Range(minRandomRotation, maxRandomRotation);
        }
        transform.Rotate(0f, rot, 0f);
    }


    private void ChangeMonsterStrategy()
    {
        var randFloat = Random.Range(0f, 1f);

        _chasePlayer = randFloat < chasePlayerChance;
    }
}
