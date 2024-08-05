using EventManagementSystem.DAL;
using EventManagementSystem.Models;

namespace EventManagementSystem.BLL
{
    public class AttendeeService : GenericService<Attendee, GenericDAL<Attendee, ERSContext>>
    {
        private readonly RegistrationService _registrationService;

        public AttendeeService(GenericDAL<Attendee, ERSContext> attendeeDAL, RegistrationService registrationService) : base(attendeeDAL)
        {
            _registrationService = registrationService;
        }

        public void Remove(int id)
        {
            _registrationService.RemoveRegistrationsByAttendeeId(id);
            _dal.Remove(id);
        }
    }
}