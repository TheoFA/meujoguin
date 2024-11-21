using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using System.Linq;

public class GameManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI enemiesLeftText;
    List<Enemy> enemies = new List<Enemy>();
    private void Awake() {
        enemies = FindObjectsOfType<Enemy>().ToList();
        UpdateEnemiesLeftText();
    }

    private void OnEnable()
    {
        Enemy.OnEnemyKilled += HandleEnemyDefeated;
    }
    private void OnDisable() {
        Enemy.OnEnemyKilled -= HandleEnemyDefeated;
    }

    void HandleEnemyDefeated(Enemy enemy)
    {
       if(enemies.Remove(enemy))
       {
        UpdateEnemiesLeftText();
       }
    }
    void UpdateEnemiesLeftText()
    {
        enemiesLeftText.text = $"Enemies Left: {enemies.Count}";
        Debug.Log(enemies.Count);
    }
   
}
