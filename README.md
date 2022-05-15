# elevator

1. Defined the lift class which have id, capacity, defaultStay, numPeopleInLift, floorNumber, status, Enum ElevatorStatus,  and constructor

id                     ---> for unique identification of lift
capacity               ---> Max number of ppl a lift can carry
defaultStay            ---> Floor num where a lift will stand by default
numPeopleInLift        ---> Num of ppl lift has carry
floorNumber            ---> currently at what floor num lift is
status                 ---> lift status have type ElevatorStatus(inherited the status from enum defined in lift class)
Enum ElevatorStatus    ---> a lift can have multiple status ( i have consider working, maintenance, damaged)
Constructor            ---> will set lift with id , capacity and status

u can set different capacity and status of each lift.
id will start from 1...it means first lift have id 1 and second will have 2....

2. Defined Lift Management system class which have numberOfFloors, numberOfLifts, lifts and few methods

numberOfFloors        ---> num of floors a building can have ( i have assumed numberOfFloors as 8 and first floor will start from 0 and last floor will have 7 as its floor num ..... means 0 to 7 )

numberOfLifts         ---> number of Lifts a building can have ( i have assumed numberOfLifts as 2 ...first lift will have id as 1 and second one will have id as 2)

lifts                 ---> list of lift (collection of lifts registered with lift management system)

AddLift               ---> After declaring the lift ... u have add the lift to lift management system so we can reduce the wait time of each lift

SettingUpSystem       ---> This method will set up lift to their default floor (defaultStay)
(i have assumed 8 floors and 2 lifts so lift have id 1 will dedicated to 0-3 floors has defaultStay as 0 and 
lift have id 2 will dedicated to 4 - 7 floors has defaultStay as 4.... so u don't have wait more amount of time when u call for lift at any floor)

SettingLiftAtMorning  ---> This special method will call at morning 8 to 9 by lift sensor ...this method will move all lift  to ground floor ( so all lift are available at ground floor (0) to serve all employee so they don't have to wait)

IsLiftFull            ---> Method to check a particular lift is full or not

MoveLiftToFloor       ---> When person press the button in lift (inside lift) to go up/down for destination than this method will call and will set floorNumber to that pressed floorNumber
Let me given a example suppose u r on  floor 5 and u call for lift so lift have id 2 will come at ur place ...so u get inside the lift when it arrive now u have pressed 7 as destination floor so lift will go to floor 7 and will stay there until someone from floor 4-7 will not call for lift

CallLift             --->  CallLift will be called when person press button to call the lift and lift will come to ur place if lift is not full & is in working condition and u can enter the floor number where u want to go (for code purpose i have handled if u press bigger number than allowed floor numbers (means in my case number more than 7 ) than lift will go to top building means floor 7)
Let me given a example suppose u r on floor 5 and u call for lift so according to our logic, lift have id 2 suppose to come at ur place before coming to ur place lift management system will check 
a. lift-2 is not in working status or not if it is not in working status than it will not come to ur place
b. lift-2 is full or not (capacity) if it is full it will not come to ur location and will print appropriate msg otherwise will come to ur location
Here lift will come to ur place means lift arrive at ur location than gate will open for u at floor...
and lift will not come to ur place means gate of lift will not open for u at ur floor
  
ChangeStatusOfLift   ---> it will change the status of lift (suppose some lift will get damaged than it needs maintenance u can change its status by calling this method)


InfoOfLifts          ---> Give status of all lift where it is, its status and number of ppl it can carry ( if it came 1 it means that particular lift can take 1 more person and if it comes as 0 it means lift is full and it can't take more ppl)



