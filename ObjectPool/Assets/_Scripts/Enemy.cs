using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace _Scripts
{
    public class Enemy : MonoBehaviour
    {
        public EnemyData data;
        public MeshRenderer meshRenderer;

        private void Awake()
        {
            meshRenderer = GetComponent<MeshRenderer>();
        }
        
        public void InitEnemy(EnemyData data)
        {
            this.data = data;
            UpdateData();
        }

        private void UpdateData()
        {
            meshRenderer.material = data.material;
        }
    }
    
    [Serializable]
    public class EnemyData
    {
        public string description;
        public int id;
        public int health;
        public int damage;
        public Material material;
    }
}