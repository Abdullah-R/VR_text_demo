# Crowdsourcing VR Demo
This demo is meant to demonstrate the capabilities of the "Crowdsourcing VR" project. This project combines virtual reality with realtime input through sms messaging to trigger events in game. The following demo can be installed onto an Oculus Quest through the use of the completed APK or built into a desktop executable using the included unity files.

## How does it work?
In assets you'll find a file called PlayerControl.cs
This file contains a subroutine that continually sends get requests to two StdLib webhooks. The function of these two is to return the latest message sent to a specified number and then to reset the airtable after receiving the message. 
The game itself is a simple maze with the twist that all the walls have colored doors which only open when a text with the corresponding color is sent.

## How can I use this?
This is meant to provide a platform for game developers to create a whole new genre of games that are much more interactive.

## What's next?
We are going use twitch comments instead of text messages in the future. How exactly a large number of requests are handled will depend on the game developer and how much they want to involve the audience. Depending upon the game, it could be a polling system where the audience decides what happens next at certain moments in the game. It can also designed so that only a limited number of people are allowed to control the game. 
