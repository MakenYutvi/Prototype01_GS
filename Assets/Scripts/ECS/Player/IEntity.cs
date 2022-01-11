
namespace ECS
{

    public interface IEntity
    {
       T GetComponent<T>();
    }
}