using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiftSystem
{
    public class LiftManagementSystem
    {
        // I am assuming floor count with start from 0
        // in this case floor count will happened from 0 to 7
        private int numberOfFloors = 8;

        public int NumberOfFloors
        {
            get { return numberOfFloors; }
        }

        private int numberOfLifts = 2;

        public int NumberOfLift
        {
            get { return numberOfLifts; }
        }

        static List<Lift> lifts = new List<Lift>();

        public void AddLift(Lift lift)
        {
            lifts.Add(lift);
        }

        public void SettingUpSystem()
        {
            int ind = 0, i = 1;
            foreach (var lift in lifts)
            {
                lift.DefaultStay = ind;
                ind = (numberOfFloors / numberOfLifts) * (i);
                i++;
            }
        }

        public void SettingLiftAtMorning()
        {
            int defIndex = 0;
            foreach (var lift in lifts)
            {
                lift.DefaultStay = defIndex;
            }
        }

        public bool IsLiftFull(Lift lift)
        {
            if (lift.Capacity == lift.NumPeopleInLift)
                return true;
            else
                return false;
        }

        public void CallLift(int floor)
        {
            int floorPerLift = numberOfFloors / numberOfLifts;
            foreach (var lift in lifts)
            {
                if (lift.DefaultStay == (floor / floorPerLift) * floorPerLift)
                {
                    if (!IsLiftFull(lift))
                    {
                        lift.NumPeopleInLift = lift.NumPeopleInLift + 1;
                        // lift.come()
                        Console.WriteLine("lift having id {0} is coming to ur place....please wait", lift.Id);
                        break;
                    }
                    else
                    {
                        // lift.come()
                        Console.WriteLine("lift having id {0} is full ....please wait for next lift to come at ur place", lift.Id);
                        break;
                    }
                }
            }
        }

        
        public void StatusOfLifts()
        {
            foreach (var lift in lifts)
            {
                Console.WriteLine(string.Format("Lift having id {0} has stayed on {1} have current capacity {2}", lift.Id, lift.DefaultStay, lift.Capacity));
            }
        }
    }
}
