using EventManagementSystem.DAL;
using EventManagementSystem.Models;

namespace EventManagementSystem.BLL
{
    public class EventService : GenericService<Event, GenericDAL<Event, ERSContext>>
    {
        private readonly RegistrationService _registrationService;

        public EventService(GenericDAL<Event, ERSContext> eventDAL, RegistrationService registrationService) : base(eventDAL)
        {
            _registrationService = registrationService;
        }

        public void Remove(int id)
        {
            _registrationService.RemoveRegistrationsByEventId(id);
            _dal.Remove(id);
        }

    }
}