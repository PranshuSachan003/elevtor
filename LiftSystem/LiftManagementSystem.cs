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

        /// <summary>
        /// This method will set up the lift management system to
        /// </summary>
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

        /// <summary>
        /// This special method will call at morning 8 to 9 by lift sensor
        /// this method will move all lift to default position
        /// </summary>
        public void SettingLiftAtMorning()
        {
            int defIndex = 0;
            foreach (var lift in lifts)
            {
                lift.DefaultStay = defIndex;
                MoveLiftToDefault(lift);
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

            Console.WriteLine(string.Format("You have arrived at floor {0}", floorNo));
            lift.FloorNumber = floorNo;
            //Moving lift to original its default position
            MoveLiftToDefault(lift);
        }

        /// <summary>
        /// Method will move to lift at their default position
        /// </summary>
        /// <param name="lift"></param>
        private void MoveLiftToDefault(Lift lift)
        {
            // lift will move
            lift.FloorNumber = lift.DefaultStay;
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
                        Console.WriteLine("lift having id {0} is full ....please wait for next lift to come at ur place", lift.Id);
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
        /// Give status of all lift where they stay(by default), their status and current capacity they have
        /// </summary>
        public void InfoOfLifts()
        {
            foreach (var lift in lifts)
            {
                Console.WriteLine(string.Format("Lift having id {0} stayed on {1} and status {2} has current capacity {3} ", lift.Id, lift.DefaultStay, lift.Status, lift.Capacity - lift.NumPeopleInLift));
            }
        }
    }
}
