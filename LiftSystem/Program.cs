using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiftSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            // Declare the lift with their capacity & unique identification num
            Lift l1 = new Lift(2,1);
            Lift l2 = new Lift(2,2);
            // Lift Management to make lift work effieciently
            LiftManagementSystem lms = new LiftManagementSystem();
            // Adding the lift to managementsystem
            lms.AddLift(l1);
            lms.AddLift(l2);
            // Seeting up the lift to stay their initial position to make use of lift management system efficient
            lms.SettingUpSystem();
            lms.StatusOfLifts();
            // checking the lift 
            lms.CallLift(0);
            lms.CallLift(1);
            lms.CallLift(2);
            lms.CallLift(3);
            lms.CallLift(4);
            lms.CallLift(5);
            lms.CallLift(6);
            lms.CallLift(7);
            lms.StatusOfLifts();
            // suppose there is sensor which keep checking the time
            // assume time is between 8 to 9
            // which trigger below line of code
            lms.SettingLiftAtMorning();
            lms.StatusOfLifts();
        }
    }
}
