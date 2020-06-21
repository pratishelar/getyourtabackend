using System;
using backend.Models;

namespace backend.Dtos
{
    public class EventForReturnDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public bool Draggable { get; set; }
        public string EventType { get; set; }
        public string Color { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }
        public string StayType { get; set; }
        public string Km { get; set; }
        public string Fair { get; set; }
        public string DaRate { get; set; }
        public DateTime TimeIn { get; set; }
        public DateTime TimeOut { get; set; }
        public string TotalTime { get; set; }
        public string Da { get; set; }
        public string DaPercent { get; set; }
        public string Total { get; set; }
    }
}