using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
namespace ECS
{

    public class MonoEntity : MonoBehaviour, IEntity, ISerializationCallbackReceiver
    {

        [SerializeField]
        private MonoElement[] _monoElements;

        private List<object> _elements;

        public bool TryGetElement<T>(out T element)
        {
            for (int i = 0, count = _elements.Count; i < count; i++)
            {
                if (_elements[i] is T result)
                {
                    element = result;
                    return true;
                }
            }

            element = default;
            return false;
        }

        public List<T> GetElements<T>()
        {
            var result = new List<T>();
            for (int i = 0, count = _elements.Count; i < count; i++)
            {
                if (_elements[i] is T tElement)
                {
                    result.Add(tElement);
                }
            }

            return result;
        }

        public void AddElement<T>(T element)
        {
            _elements.Add(element);
        }

        public void RemoveElement<T>(T element)
        {
            _elements.Remove(element);
        }

        void ISerializationCallbackReceiver.OnAfterDeserialize()
        {
            _elements = new List<object>(this._monoElements);
        }

        void ISerializationCallbackReceiver.OnBeforeSerialize()
        {
        }
    }
}