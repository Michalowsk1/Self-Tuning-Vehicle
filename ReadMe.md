**Self-Tuning Vehicle Simulation**



This project is a follow-up of my Self-Driving Vehicle Simulation, this project however focuses on improving the driving of the vehicle

by allowing the user to change multiple variables of the Vehicle impacting it's performance on a 2D race track.



**How To Play**

When you load up the project you will be presented with a race track, racecar, a box with the current stats of the vehicle.

You will also be presented with 4 buttons, they are as follows:

* A flag icon 'Start Race' - This as the name suggests starts the lap for the vehicle.
* A gear icon 'Configuration' - Here you open up a panel with all the current variables where you have the option to either:

&#x20;                               - Manually change a value of a variable,

&#x20;                               - Change the variance rate (this is explained in the Info tab in the program),

&#x20;                               - Enabled or Disable the variables, this stops them from being changed by the program,

&#x20;                               - Reset all the variable values to their default values using the 'ResetToDefaultValues' button,

&#x20;                               - Open up an Info page, this explains briefly what each variable does,

* A red circle 'Reset Race' - As name suggests, resets the current lap.
* A stopwatch 'Reset Best Time' - This resets the best time back to nothing so a new one can be set.



**How It Works**

Each time the vehicle completes a lap the self-tuning algorithm is ran which takes each values and adds a variance to it, a random

number between -variance and +variance, i.e. -0.25 and +0.25. Before this is added the algorithm checks if the user has the box 

checked for the variable wanting to be changed, and if the last change helped and if it was a positive or negative, if has helped

the symbol stays the same, however, if the last change didn't help, the sign is flipped meaning + becomes - and vice versa.



**Quick Notes**

* Running all variables at ones can affect all of them however this doesn't lead to positive results, as 4 variables can have a small

positive impact whereas another variable has a major negative impact overshadowing the 4 positive changes and causes them to be altered

in the wrong direction.



* Sometimes the 'Start Race' will need to be pressed and extra time or 2, however, this also leads to the timer potentially recording a

best time as a really small impossible to beat value, this is what the 'Reset Best Time' button is for. However, the button only works when

a race has started, as it's still storing the last lap time.

* When a race is started the 'Start Race' and 'Configuration' buttons can't be accessed until the lap is either restarted or the lap is finished.







