using EventManagementSystem.Models;
using System.Security.AccessControl;

namespace EventManagementSystem.DAL
{
    public class EventDAL : GenericDAL<Event, ERSContext>
    {
        public EventDAL(ERSContext context) : base(context) { }
    }
}