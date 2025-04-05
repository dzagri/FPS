# First-Person-Controller
Unity FPS Input Manager Script

This Unity FPS Input Manager Script leverages the new Input System to provide smooth, customizable FPS mechanics. Whether you're starting a new FPS project or need a quick solution to enhance your existing one, this script offers:

 • RigidBody-based Physics Interactions for realistic movement.

 • Camera and Player Rotation handled with ease.

 • Smooth Player Movement and Jump Mechanics.

 • Ground Detection for precise jumping and movement control.

 • Easy to Modify and Expand – Adjust the script to fit your game’s needs.

With simple, intuitive variables to tweak, you can easily customize the controls to suit your project. It’s a great starting point for any FPS game, or a quick replacement for an existing system.

How to Set Up
Follow these easy steps to integrate the FPS Input Manager script into your project:

1. Install the New Input System
Open your project in Unity.

 • Go to Window > Package Manager.

 • Search for Input System in the Unity Registry.

 • Click Install to add the package to your project.
![PackageManager](https://github.com/user-attachments/assets/ca801b4a-7345-4e40-875b-7614ae225648)

2. Create an Input Action Asset
In your project, create a new folder for your Input Actions (e.g., Input).

 • Right-click inside the folder, and select Create > Input Actions.

 • Open the newly created asset and bind the necessary inputs, such as movement, jump, and camera control.
![IAFile](https://github.com/user-attachments/assets/0aa541f9-aff0-4e92-879c-e9da113b4cbb)

3. Configure the Player GameObject
Create or select a Player GameObject.

• Add the following components to your Player:

 • Rigidbody

 • Capsule Collider

 • FPS Input Manager Script (Drag and drop this script to your Player GameObject)

4. Assign Input Actions
In the FPS Input Manager Script component on your Player, assign the following actions:

 • Movement Action (from your Input Actions)

 • Jump Action (from your Input Actions)

 • Camera Action (from your Input Actions)
![PlayerComponents](https://github.com/user-attachments/assets/4d8c98ef-c74b-4a02-95fc-5fa6f5d23c20)

5. Set Ground Layer
 • In the FPS Input Manager Script, set the Ground Layer variable to define what should be considered ground for detecting jumps.

 • Apply the Ground Layer to any objects (e.g., the floor, terrain, platforms) that the player should collide with and stand on.

![Ground](https://github.com/user-attachments/assets/bbb0ad79-fac4-4a85-b10f-8d148e617076)

6. Tweak the Variables
 • Adjust the script’s variables to fit the movement and camera behavior you need. Fine-tune settings like speed, jump height, rotation sensitivity, and ground detection for a custom feel.

Customization and Expansion

The script is designed with expandability in mind. You can easily modify or extend the functionality to add more complex mechanics, like:

 • Advanced camera control (e.g., mouse smoothing, inverted controls).

 • Advanced player movement (e.g., sprinting, crouching, prone).

 • Custom collision detection (e.g., slopes, ladders).

 • Additional input actions (e.g., shooting, interacting with objects).

 • With clear and modular code, you can adjust or extend the behavior without hassle.

Support and Contributions
Feel free to submit issues, suggest features, or contribute to the project. If you run into any problems or need assistance, don’t hesitate to reach out.
