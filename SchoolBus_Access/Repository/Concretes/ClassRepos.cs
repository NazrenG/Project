using SchoolBus_Access.Repository.Abstract;
using SchoolBus_Model.Entities.Concretes;

namespace SchoolBus_Access.Repository.Concretes
{
    public class ClassRepos : BaseRepos<Class>, IClassRepos
    {
        public List<string> GetAllClass()
        {
            return _context.Classes.Select(c => c.Name).ToList();
        }
    }
}
