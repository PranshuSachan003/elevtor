using System;

namespace LiftSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            // Declare the lift unique identification number, with their capacity and their initial condition
            Lift l1 = new Lift(1, 2, Lift.ElevatorStatus.working);
            Lift l2 = new Lift(2, 2, Lift.ElevatorStatus.working);

            // Lift Management to make lift work effieciently
            LiftManagementSystem lms = new LiftManagementSystem();
            // Adding the lift to managementsystem
            lms.AddLift(l1);
            lms.AddLift(l2);
            // Seting up the lift to stay their initial position to make use of lift management system efficient
            lms.SettingUpSystem();

            // Change the status of lift (if something happened wrong with lift u change status of that lift)
            // uncomment below line of code
            //lms.ChangeStatusOfLift(l1,Lift.ElevatorStatus.damaged);

            // checking the lift 
            lms.CallLift(0);
            lms.CallLift(7);

            // suppose there is sensor which keep checking the time
            // assume time is between 8 to 9
            // which trigger below line of code
            // uncomment the below line of code to see this functionality
            //lms.SettingLiftAtMorning();

            // Gives information of each lift
            lms.InfoOfLifts();
        }
    }
}
