using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1_PTTKGT
{
    class Color
    {
        private List<ExaminationRoom> listRoom;

        internal List<ExaminationRoom> ListRoom
        {
            get { return listRoom; }
            set { listRoom = value; }
        }
        private int day = 0;

        public int Day
        {
            get { return day; }
            set { day = value; }
        }
        private int slot = 0;

        public int Slot
        {
            get { return slot; }
            set { slot = value; }
        }
        private List<Course> listCourse;

        internal List<Course> ListCourse
        {
            get { return listCourse; }
            set { listCourse = value; }
        }

        public Color(int day, int slot) {
            this.day = day;
            this.slot = slot;
        }

        public int availableCapacity()
        {
            int capacity = 0;

            for (int i = 0; i < listRoom.Count(); i++)
            {
                capacity += listRoom.ElementAt(i).Capacity;
            }
            return capacity;
        }

        public List<ExaminationRoom> getAvailableRooms()
        {
            List<ExaminationRoom> listAvailableRooms = new List<ExaminationRoom>();
            for (int i = 0; i < listRoom.Count(); i++)
            {
                ExaminationRoom room = listRoom.ElementAt(i);
                if (room.Capacity > 0)
                {
                    listAvailableRooms.Add(room);
                }
            }
            return listAvailableRooms;
        }
    }
}
