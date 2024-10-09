using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPattern : MonoBehaviour
{
    private Enemy enemy;

    public void Init(Enemy enemy)
    {
        this.enemy = enemy;
    }
}
