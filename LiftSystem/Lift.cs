using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiftSystem
{
    public class Lift
    {
        private int capacity;

        public int Capacity
        {
            get { return capacity; }
        }
        private int id;

        public int Id
        {
            get { return id; }
        }

        private int defaultStay;

        public int DefaultStay
        {
            set { defaultStay = value; }
            get { return defaultStay; }
        }

        private int numPeopleInLift = 0;
        public int NumPeopleInLift
        {
            set { numPeopleInLift = value; }
            get { return numPeopleInLift; }
        }
        public Lift(int capacity, int id)
        {
            this.capacity = capacity;
            this.id = id;
        }
    }
}
