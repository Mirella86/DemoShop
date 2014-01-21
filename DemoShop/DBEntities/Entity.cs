
namespace DBEntities
{
    public abstract  class Entity: IEntity
    {

        public abstract bool CompareTo(Entity otherEntity);

    }
}