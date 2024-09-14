using System;
using System.Collections.Generic;
using UnityEngine;

namespace _Scripts
{
    public class TestObjectManager : MonoBehaviour
    {
        public TestObject prefabs;
        public int poolSize;
        private ObjectPool<TestObject> _objectPool;

        public TestObject returnobject;

        private void Awake()
        {
            _objectPool = new ObjectPool<TestObject>(prefabs, poolSize);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                _objectPool.AddToPool();
            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                _objectPool.RemoveFromPool();
            }
            
            if(Input.GetKeyDown(KeyCode.D))
            {
                TestObject obj = _objectPool.GetObjectFromPool();
                obj.gameObject.transform.position = new Vector3(5, 5, 0);
            }
            
            if(Input.GetKeyDown(KeyCode.F))
            {
                _objectPool.ReturnObjectToPool(returnobject);
            }
        }
    }
}