using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiftSystem
{
    public class LiftManagementSystem
    {
        // I am assuming floor count will start from 0
        // so if total no of floors are 8 then they will be counted from 0 to 7
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

        /// <summary>
        /// This method will register the lift to lift management system
        /// </summary>
        /// <param name="lift"></param>
        public void AddLift(Lift lift)
        {
            lifts.Add(lift);
        }

        /// <summary>
        /// This method will set up lift to their default floor
        /// </summary>
        public void SettingUpSystem()
        {
            int ind = 0, i = 1;
            foreach (var lift in lifts)
            {
                lift.DefaultStay = ind;
                lift.FloorNumber = ind;
                ind = (numberOfFloors / numberOfLifts) * (i);
                i++;
            }
        }

        /// <summary>
        /// This special method will call at morning 8 to 9 by lift sensor
        /// this method will move all lift to ground floor
        /// </summary>
        public void SettingLiftAtMorning()
        {
            int defIndex = 0;
            foreach (var lift in lifts)
            {
                lift.DefaultStay = defIndex;
                MoveLiftToFloor(lift, defIndex);
            }
        }

        /// <summary>
        /// Method to check a lift is full or not
        /// </summary>
        /// <param name="lift"></param>
        /// <returns></returns>
        public bool IsLiftFull(Lift lift)
        {
            if (lift.Capacity == lift.NumPeopleInLift)
                return true;
            else
                return false;
        }

        /// <summary>
        /// When person press the button in lift (inside lift) to go up/down for destination
        /// this method will called
        /// </summary>
        /// <param name="lift"></param>
        /// <param name="floorNo"></param>
        public void MoveLiftToFloor(Lift lift, int floorNo)
        {
            Console.WriteLine(string.Format("You have reached to your desired floor {0}", floorNo));
            lift.FloorNumber = floorNo;
        }

        /// <summary>
        /// CallLift will be called when person press button to call the lift
        /// </summary>
        /// <param name="floor"></param>
        public void CallLift(int floor)
        {
            int floorPerLift = numberOfFloors / numberOfLifts;
            foreach (var lift in lifts)
            {
                if (lift.DefaultStay == (floor / floorPerLift) * floorPerLift)
                {
                    if (lift.Status == Lift.ElevatorStatus.maintenance || lift.Status == Lift.ElevatorStatus.damaged)
                    {
                        Console.WriteLine(string.Format("Lift having id {0} is in {1} state", lift.Id, lift.Status.ToString()));
                    }
                    else if (!IsLiftFull(lift) && lift.Status == Lift.ElevatorStatus.working)
                    {
                        lift.NumPeopleInLift = lift.NumPeopleInLift + 1;
                        Console.WriteLine("lift having id {0} is coming to ur place....please wait", lift.Id);
                        Console.WriteLine("Enter FloorNumber:");
                        int floorNo = 0;
                        Int32.TryParse(Console.ReadLine(), out floorNo);
                        floorNo = floorNo < 8 ? floorNo : 7;
                        MoveLiftToFloor(lift, floorNo);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("lift having id {0} is full ....please wait while the lift is serving to others", lift.Id);
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Changed the status of lift
        /// </summary>
        /// <param name="lift"></param>
        /// <param name="value"></param>
        public void ChangeStatusOfLift(Lift lift, Lift.ElevatorStatus value)
        {
            lift.Status = value;
        }

        /// <summary>
        /// Give status of all lift where it is, its status and its current capacity 
        /// </summary>
        public void InfoOfLifts()
        {
            foreach (var lift in lifts)
            {
                Console.WriteLine(string.Format("Lift having id {0} stayed on {1} and status {2} has current capacity {3} ", lift.Id, lift.FloorNumber, lift.Status, lift.Capacity - lift.NumPeopleInLift));
            }
        }
    }
}
