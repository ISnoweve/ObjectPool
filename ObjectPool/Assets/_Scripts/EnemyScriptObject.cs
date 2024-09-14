using System;
using System.Collections.Generic;
using UnityEngine;

namespace _Scripts
{
    [CreateAssetMenu(fileName = "EnemyScriptObject", menuName = "EnemyScriptObject")]
    public class EnemyScriptObject : ScriptableObject
    {
        public List<EnemyData> data; 
        
        public EnemyData GetEnemyData(int id)
        {
            return data.Find(enemyData => enemyData.id == id);
        }
    }
}