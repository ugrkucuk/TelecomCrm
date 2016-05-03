using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Event
    {
        String name;
        int duration;

        public Event(String name, int duration)
        {
            setName("Event " + name);
            setDuration(duration);
        }

        public String getName()
        {
            return name;
        }
        
        public void setName(String name)
        {
            this.name = name;
        }

        public int getDuration()
        {
            return duration;
        }

        public void setDuration(int duration)
        {
            this.duration = duration;
        }
    }
}
