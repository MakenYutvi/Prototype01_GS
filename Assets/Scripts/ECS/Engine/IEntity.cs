using System.Collections.Generic;

namespace ECS
{
    public interface IEntity
    {
        bool TryGetElement<T>(out T element);

        List<T> GetElements<T>();

        void AddElement<T>(T element);

        void RemoveElement<T>(T element);
    }
}