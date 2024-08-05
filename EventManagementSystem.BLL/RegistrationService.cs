using EventManagementSystem.DAL;
using EventManagementSystem.Models;

namespace EventManagementSystem.BLL
{
    public class RegistrationService : GenericService<Registration, RegistrationDAL>
    {
        public RegistrationService(RegistrationDAL registrationDAL) : base(registrationDAL) { }
        public List<Registration> GetAll()
        {
            return _dal.GetAllRegistrations();
        }

        public List<Registration> GetRegistrationsByAttendeeId(int attendeeId)
        {
            return _dal.GetRegistrationsByAttendeeId(attendeeId);
        }

        public List<Registration> GetRegistrationsByEventId(int eventId)
        {
            return _dal.GetRegistrationsByEventId(eventId);
        }

        public void RemoveRegistrationsByAttendeeId(int id)
        {
            var registrations = GetRegistrationsByAttendeeId(id);
            foreach (var reg in registrations)
            {
                Remove(reg.RegistrationId);
            }
        }

        public void RemoveRegistrationsByEventId(int id)
        {
            var registrations = GetRegistrationsByEventId(id);
            foreach (var reg in registrations)
            {
                Remove(reg.RegistrationId);
            }
        }
    }
}