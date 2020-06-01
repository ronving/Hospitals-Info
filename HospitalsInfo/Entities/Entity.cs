
namespace HospitalsInfo.Entities
{
    public abstract class Entity
    {
        public virtual int Id { get; set; }

        public sealed override string ToString() {
            return string.Format("{0,7} {1}", Id, ToDataString());
        }

        protected abstract string ToDataString();
    }
}
