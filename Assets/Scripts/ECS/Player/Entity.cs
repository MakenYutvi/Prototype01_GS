using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
namespace ECS
{

    public class Entity : MonoBehaviour, IEntity
    {

        [SerializeField]
        private List<ComponentEntity> _components;

        private Dictionary<Type, ComponentEntity> _componentsDictionary;

        private void Awake()
        {
            InitializeComponents();
        }
        public T GetComponentFromEntity<T>()
        {
          if(_componentsDictionary.ContainsKey(typeof(T)))
            {
                return _componentsDictionary[typeof(T)];
            }


            return default;
        }

        private void InitializeComponents()
        {
            var count = _components.Count;
            _componentsDictionary = new Dictionary<Type, ComponentEntity>(count);
            for(int i = 0; i < count; i++)
            {
                var component = _components[i];
                var type = component.GetType();
                this._componentsDictionary.Add(type, component);
            }
            
        }
    }
}