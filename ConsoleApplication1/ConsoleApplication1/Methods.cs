using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Methods
    {

        List<Event> eventList = new List<Event>();
        List<Event> scheduledList = new List<Event>();
        List<Event> unacceptableList = new List<Event>();
        DateTime morningStartDate = new DateTime(2016, 3, 17, 9, 0, 0);
        DateTime afternoonStartDate = new DateTime(2016, 3, 17, 13, 0, 0);
        int beforeLunchTime = 180;
        int afterLunchTime = 240;
        int initialCount = 0;

        public void initEventList()
        {
            eventList.Add(new Event("A",60));
            eventList.Add(new Event("B",45));
            eventList.Add(new Event("C",30));
            eventList.Add(new Event("D",45));
            eventList.Add(new Event("E",45));
            eventList.Add(new Event("F",60));
            eventList.Add(new Event("G",60));
            eventList.Add(new Event("H",45));
            eventList.Add(new Event("I",30));
            eventList.Add(new Event("J",30));
            eventList.Add(new Event("K",45));
            eventList.Add(new Event("L",60));
            eventList.Add(new Event("M",60));
            eventList.Add(new Event("N",45));
            eventList.Add(new Event("O",30));
            eventList.Add(new Event("P",30));
            eventList.Add(new Event("Q",60));
            eventList.Add(new Event("R",30));
            eventList.Add(new Event("S",30));
            initialCount = eventList.Count;
        }

        public void createMorningEventSchedule()
        {
            Random r = new Random();
            int shortestEventDuration = 0;
            int scheduledAndCurrentTotal = 0;
            while (eventList.Count > 0 && getScheduledEventDuration(scheduledList) < beforeLunchTime)
            {
                int nextEvent = r.Next(eventList.Count);
                Event e = eventList.ElementAt(nextEvent);
                scheduledAndCurrentTotal = getScheduledEventDuration(scheduledList) + e.getDuration();
                shortestEventDuration = findShortestEventDuration(eventList);
                if (scheduledAndCurrentTotal <= beforeLunchTime && ((beforeLunchTime - scheduledAndCurrentTotal) >= shortestEventDuration) || beforeLunchTime == scheduledAndCurrentTotal)
                {
                    scheduledList.Add(e);
                    eventList.RemoveAt(nextEvent);
                    Console.WriteLine(e.getName() + " Start Time : " + morningStartDate.ToString("HH:mm") + " Duration : " + e.getDuration());
                    morningStartDate = morningStartDate.AddMinutes(e.getDuration());
                }
            }
            scheduledList.Clear();
            Console.WriteLine("\nLunch Start Time : 12:00 Duration : 60\n");
            morningStartDate = new DateTime(2016, 3, 17, 9, 0, 0);
        }

        public void createAfternoonEventSchedule()
        {
            Random r = new Random();
            int shortestEventDuration = 0;
            int scheduledAndCurrentTotal = 0;
            while (eventList.Count > 0 && getScheduledEventDuration(scheduledList) < afterLunchTime)
            {
                int nextEvent = r.Next(eventList.Count);
                Event e = eventList.ElementAt(nextEvent);
                scheduledAndCurrentTotal = getScheduledEventDuration(scheduledList) + e.getDuration();
                shortestEventDuration = findShortestEventDuration(eventList);
                if (scheduledAndCurrentTotal <= afterLunchTime && ((afterLunchTime - scheduledAndCurrentTotal) >= shortestEventDuration) || afterLunchTime == scheduledAndCurrentTotal)
                {
                    scheduledList.Add(e);
                    eventList.RemoveAt(nextEvent);
                    Console.WriteLine(e.getName() + " Start Time : " + afternoonStartDate.ToString("HH:mm") + " Duration : "+ e.getDuration());
                    afternoonStartDate = afternoonStartDate.AddMinutes(e.getDuration());
                }
            }
            scheduledList.Clear();
            Console.WriteLine("Networking Start Time : 17:00\n");
            afternoonStartDate = new DateTime(2016, 3, 17, 13, 0, 0);
        }

        public int getScheduledEventDuration(List<Event> scheduledEventList)
        {
            int totalDuration = 0;
            foreach (Event e in scheduledEventList)
            {
                totalDuration += e.getDuration();
            }
            return totalDuration;
        }

        public int findShortestEventDuration(List<Event> eventList)
        {
            int shortestDuration = eventList.ElementAt(0).getDuration();
            foreach (Event ev in eventList)
            {
                if (ev.getDuration() < shortestDuration)
                {
                    shortestDuration = ev.getDuration();
                }
            }
            return shortestDuration;
        }

        public int getTotalEventDuration(List<Event> eventList)
        {
            int totalEventDuration = 0;
            foreach (Event e in eventList)
            {
                totalEventDuration += e.getDuration();
            }
            return totalEventDuration;
        }

        public void createNDayCalendar(int day)
        {
            if (day > 0) {
                try
                {
                    if (getTotalEventDuration(eventList) < day * 420)
                    {
                        Console.WriteLine("Not enough events to create a schedule.");
                    }
                    else {
                        int currDay = 1;
                        while (day >= currDay)
                        {
                            Console.WriteLine("Day " + currDay++ + "\n");
                            createMorningEventSchedule();
                            createAfternoonEventSchedule();
                        }
                        Console.WriteLine("Scheduled event count : " + initialCount);
                        Console.WriteLine("Unscheduled event count : " + eventList.Count);
                    }  
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error occured, please try again");
                }
            }
            else
            {
                Console.WriteLine("Date should be greater than zero.");
            }
            
        }
    }
}
