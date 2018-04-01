using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1_PTTKGT
{
    class ExaminationRoom
    {
        // properties and get, set methods

        private string id = null;

        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        private int capacity = 0;

        public int Capacity
        {
            get { return capacity; }
            set { capacity = value; }
        }
        private string kind = null;

        public string Kind
        {
            get { return kind; }
            set { kind = value; }
        }
        private string note = null;

        public string Note
        {
            get { return note; }
            set { note = value; }
        }

        private Color color = null;

        internal Color Color
        {
            get { return color; }
            set { color = value; }
        }

        // factory method

        public ExaminationRoom(){
            this.id = null;
            this.capacity = 0;
            this.kind = null;
            this.note = null;
            this.color = null;
        }

        public ExaminationRoom(string id, int capacity, string kind, string note){
            this.id = id;
            this.capacity = capacity;
            this.kind = kind;
            this.note = note;
            this.color = null;
            /*
            switch (kind)
            {
                case "PM":
                    this.note = "Phòng máy";
                    break;
                case "LT":
                    this.note = "Phòng học lý thuyết";
                    break;
                case "H":
                    this.note = "Phòng họa thất";
                    break;
                case "NT":
                    this.note = "Phòng nội thất khoa MTCN";
                    break;
                default:
                    break;
            }
             */

        }

    }

    
}
