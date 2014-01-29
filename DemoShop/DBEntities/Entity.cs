
namespace DBEntities
{
    public abstract  class Entity: IEntity
    {
        public virtual bool CompareTo(IEntity otherEntity)
        {
            throw new System.NotImplementedException();
        }
    }
}