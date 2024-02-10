using Microsoft.EntityFrameworkCore;
using SchoolBus_Access.Repository.Abstract;
using SchoolBus_Model.Entities.Concretes;

namespace SchoolBus_Access.Repository.Concretes
{
    public class BusRepos : BaseRepos<Bus>, IBusRepos
    {
        public int FindId(string name)
        {
            var bus = _context.Buses.FirstOrDefault(b => b.Name == name);
            return bus != null ? bus.Id : 0;
        }

        public List<string> GetAllBusName()
        {
            return _context.Buses.Select(bus => bus.Name).ToList();
        }

        public ICollection<Bus> GetDriverName()
        {
            return _context.Buses.Include(a => a.Driver.Username).ToList();
        }

    }
}


