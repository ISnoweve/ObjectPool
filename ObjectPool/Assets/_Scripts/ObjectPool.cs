using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace _Scripts
{
    public class ObjectPool<T> where T : MonoBehaviour
    {
        private readonly List<T> _pool = new();
        private readonly T _objectPrefab;
        private readonly int _poolSize;
        private GameObject _objectParent;
        
        public ObjectPool(T objectPrefab, int poolSize)
        {
            _objectPrefab = objectPrefab;
            _poolSize = poolSize;
            Initialize();
        }

        private void Initialize()
        {
            _objectParent = new GameObject($"{typeof(T).Name}_TopParent");
            for (var i = 0; i < _poolSize; i++)
            {
                AddToPool();
            }
        }
        
        public void AddToPool()
        {
            var obj = GameObject.Instantiate(_objectPrefab, _objectParent.transform);
            obj.name = $"{typeof(T).Name}";
            _pool.Add(obj);
            obj.gameObject.SetActive(false);
            Debug.Log($"Current {typeof(T).Name}pool count:{_pool.Count}");
        }
        
        public void RemoveFromPool()
        {
            if (CheckPoolIsOutLimit())
            {
                Debug.Log("Pool is not out of limit.");
                return;
            }
            
            var notActiveObjects = _pool.Where(objectInPool => objectInPool.gameObject.activeSelf == false).ToList();

            if (!CheckPoolIsOutLimit() && !notActiveObjects.Any())
            {
                Debug.Log("Pool is out of limit. But the reason of out of limit because of active object.");
                return;
            }
                
            for (var i = 0; i < notActiveObjects.Count; i++)
            {
                if (CheckPoolIsOutLimit())
                {
                    return;
                }
                
                GameObject.Destroy(notActiveObjects[i].gameObject);
                _pool.Remove(notActiveObjects[i]);
                Debug.Log($"Removed PoolObject count:{i+1}");
            }
        }
        
        private bool CheckPoolIsOutLimit()
        {
            return _poolSize >= _pool.Count;
        }
        
        public T GetObjectFromPool()
        {
            var obj = _pool.Where(objectsInPool => objectsInPool.gameObject.activeSelf == false);

            if (!obj.Any())
            {
                AddToPool();
            }

            foreach (var objectsInPool in _pool.Where(objectsInPool => objectsInPool.gameObject.activeSelf == false))
            {
                objectsInPool.gameObject.SetActive(true);
                return objectsInPool;
            }

            return null;
        }
        
        public void ReturnObjectToPool(T obj)
        {
            obj.gameObject.SetActive(false);
        }
    }
}
