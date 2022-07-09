using System.Collections.Generic;
using ECS.Components.EntityReference;
using ECS.Factory;
using ECS.Tags;
using JetBrains.Annotations;
using Leopotam.Ecs;
using UnityEngine;

namespace ECS.Pool
{
    public sealed class EntitiesPool : MonoBehaviour
    {
        private readonly List<MonoEntity> _elements = new List<MonoEntity>();
        public List<MonoEntity> Elements => _elements;

        private IObjectsFactoryForPool _factory;

        public void Construct(in IObjectsFactoryForPool factory)
        {
            _factory = factory;
        }

        public void SetCapacity(in int capacity)
        {
            _elements.Capacity = capacity;
        }

        public void AddElement(in MonoEntity entity)
        {
            _elements.Add(entity);
        }

        private int _willGetElement = 0;

        [CanBeNull]
        public MonoEntity GetNextElement()
        {
            if (_elements.Count == _willGetElement)
            {
                _willGetElement = 0;
            }

            if (_elements[_willGetElement].Entity.Has<InactiveObjectTag>())
            {
                Debug.Log("return element from Pool");
                Debug.Log($"_willGetElement {_willGetElement}");

                return _elements[_willGetElement];
            }
            else
            {
                
            }

            _willGetElement += 1;

            return null;
        }
    }
}