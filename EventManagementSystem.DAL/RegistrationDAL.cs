using EventManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace EventManagementSystem.DAL
{
    public class RegistrationDAL : GenericDAL<Registration, ERSContext>
    {
        private readonly ERSContext _context;
        public RegistrationDAL(ERSContext context) : base(context)
        {
            _context = context;
        }

        public List<Registration> GetAllRegistrations()
        {
            return Filter(r => r
                            .Include(r => r.Event)
                            .Include(r => r.Attendee));
        }

        public List<Registration> GetRegistrationsByEventId(int id)
        {
            return Filter(q => q
                            .Include(r => r.Attendee)
                            .Include(r => r.Event)
                            .Where(r => r.EventId == id));
        }

        public List<Registration> GetRegistrationsByAttendeeId(int id)
        {
            return Filter(q => q
                            .Include(r => r.Attendee)
                            .Include(r => r.Event)
                            .Where(r => r.AttendeeId == id));
        }

    }
}