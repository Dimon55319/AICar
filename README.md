# AICar

A little project to test wheel colliders an AI in a Unity 3D Car.

## Instructions

* Create a new project and import CarBaseProject.unitypackage (from here)
* The folder Challenges has the scenes for each Challenge. 
* You need to proceed in order and reuse part of the code you will generate. 
* All the resources for the challenge are provided in the folder content.
* Use the links for the next slide to get the information needed to complete the challenges!
* Good Luck :)

## Resources

Wheelcollider:
* http://docs.unity3d.com/Manual/class-WheelCollider.html
* http://www.theappguruz.com/tutorial/unity-wheel-collider-motor-vehicle/

Rigid Body:
* http://docs.unity3d.com/Manual/class-Rigidbody.html

Raycasting:
* https://www.youtube.com/watch?v=P0PHY1hJp5k

Use Youtube… a lot of material is there :)

## Challenge 01 - Part 1
Goal : Create a basic car and move it using Wheel Colliders

* Open the scene Challenge1
* In the center of the scene you will find a basic 3D model of a car. The chassis and the wheels are independent objects.
* Using Wheel Colliders create a Monobehaviour to control the car movement using the arrow keys.

Hints:
* You will need a Rigid body for the chassis. Adjust the physical parameters like Mass or Center of Gravity to improve the stability of your car.
* The motorTorque could be calculated like : EngineTorque / GearRatio * Input.GetAxis("Vertical");
* If you want to simplify the equation, assume your car only have one GearRatio, and this is equal to 4.31f;

## Challenge 01 - Part 2
Goal : Explore properties of Wheel Colliders and Pimp Your Ride!

* Continue working in the scene Challenge1
* Make all the wheels rotate in the direction of the movement.
* Rotate the front wheels every time the user turns to left or right.
* Add Slips to your Wheels (check the prefab folder)

Optional:
* Pimp your Ride, change the chassis and add your custom one!
* Explore the Wheel Colliders Suspension Spring parameters… Create a Low Rider!

## Challenge 02
Goal : Make the car move alone

* Grab the car you created on the Challenge1 and create a prefab with that.
* Open the scene Challenge2, you will see and empty scene with a plane.
* Copy the car prefab in the scene.
* Create an empty GameObject called WayPoints
* For the prefab folder drag the WayPoint prefab inside the GameObject you created, generate several copies and create a circuit (you will see something similar to the left image, several cubes united by lines)
* Define one of the WayPoints as a starting point.
* Based on the original behaviour you used for your car, do the modifications to make the car navigate alone using the Waypoints.
* Change the place of the Waypoints to see how your car performs.


## Challenge 03
Goal : Make the car move alone and avoid obstacles

* Grab the car you created on the Challenge2 and create a prefab with that.
* Open the scene Challenge3, you will see and empty scene with a circuit of Waypoints and obstacles.
* Copy the car prefab in the scene.
* Based on the original behaviour you used for your car in the Challenge2, do the modifications to make the car navigate alone using the Waypoints and also avoid Obstacles

Hints:
* Use Ray cast to see what is in front of you.


