using System.Collections.Generic;
using UnityEngine;

namespace ECS
{
    public sealed class MonoEntity : MonoBehaviour, IEntity,
        ISerializationCallbackReceiver
    {
        [SerializeField]
        private MonoElement[] monoElements;

        private List<object> elements;
        
        public bool TryGetElement<T>(out T element)
        {
            for (int i = 0, count = this.elements.Count; i < count; i++)
            {
                if (this.elements[i] is T result)
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
            for (int i = 0, count = this.elements.Count; i < count; i++)
            {
                if (this.elements[i] is T tElement)
                {
                    result.Add(tElement);
                }
            }

            return result;
        }

        public void AddElement<T>(T element)
        {
            this.elements.Add(element);
        }

        public void RemoveElement<T>(T element)
        {
            this.elements.Remove(element);
        }
        
        void ISerializationCallbackReceiver.OnAfterDeserialize()
        {
            this.elements = new List<object>(this.monoElements);
        }

        void ISerializationCallbackReceiver.OnBeforeSerialize()
        {
        }
    }
}