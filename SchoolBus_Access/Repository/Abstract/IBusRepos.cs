using SchoolBus_Model.Entities.Concretes;

namespace SchoolBus_Access.Repository.Abstract
{
    public interface IBusRepos:IBaseRepos<Bus>
    {
        public ICollection<Bus> GetDriverName();
        public List<string> GetAllBusName();
        public int FindId(string name);
    }
}
