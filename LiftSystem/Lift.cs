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

        private int floorNumber;

        public int FloorNumber
        {
            set { floorNumber = value;}
            get { return floorNumber; }
        }

        public enum ElevatorStatus
        {
            damaged,
            maintenance,
            working
        }

        private ElevatorStatus status;
        public ElevatorStatus Status
        {
            set { status = value; }
            get { return status; }
        }


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id"></param>
        /// <param name="capacity"></param>
        /// <param name="status"></param>
        public Lift( int id, int capacity, ElevatorStatus status)
        {
            this.capacity = capacity;
            this.id = id;
            this.status = status;
        }
    }
}
