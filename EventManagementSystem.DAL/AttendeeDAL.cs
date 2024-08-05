using EventManagementSystem.Models;

namespace EventManagementSystem.DAL
{
    public class AttendeeDAL : GenericDAL<Attendee, ERSContext>
    {
        public AttendeeDAL(ERSContext context) : base(context) { }
    }
}