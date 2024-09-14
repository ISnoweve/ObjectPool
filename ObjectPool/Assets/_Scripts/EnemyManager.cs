using System;
using UnityEngine;

namespace _Scripts
{
    public class EnemyManager : MonoBehaviour
    {
        private ObjectPool<Enemy> _enemyPool;
        public Enemy enemyPrefab;
        public int poolSize;
        public EnemyScriptObject enemyData;

        private void Awake()
        {
            _enemyPool = new ObjectPool<Enemy>(enemyPrefab, poolSize);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                Enemy enemy = _enemyPool.GetObjectFromPool();
                enemy.InitEnemy(enemyData.GetEnemyData(1));
                enemy.gameObject.transform.position = new Vector3(5, 5, 0);
            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                Enemy enemy = _enemyPool.GetObjectFromPool();
                enemy.InitEnemy(enemyData.GetEnemyData(2));
                enemy.gameObject.transform.position = new Vector3(-5, 5, 0);
            }
        }
    }
}