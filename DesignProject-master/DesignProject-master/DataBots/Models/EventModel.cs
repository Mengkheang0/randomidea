using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBots.Models
{
    public class EventModel
    {
        public int Id { get; set; }
        public string EventName { get; set; }
        public string CopyToPath { get; set; }
        public string CopyFromPath { get; set; }
        public DateTime EndDate { get; set; }
    }
    public class DataAccessEvent
    {
        public List<EventModel> Events { get; set; }= new List<EventModel>();
        public DataAccessEvent()
        {
            Events.Add(new EventModel() {Id=1,EventName="project1",CopyFromPath=@"D:\BG",CopyToPath=@"C:\Temp",EndDate= DateTime.Now.AddMinutes(10)});
        }
        public List<EventModel> GetEvents()
        {
            return Events;
        }
        public void AddEvent(EventModel eventModel)
        {
            Events.Add(eventModel);
        }
    }
}
