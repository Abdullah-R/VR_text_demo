# Crowdsourcing VR Demo
This demo is meant to demonstrate the capabilities of the "Crowdsourcing VR" project. This project combines virtual reality with realtime input through sms messaging to trigger events in game. The following demo can be installed onto an Oculus Quest through the use of the completed APK or built into a desktop executable using the included unity files.

## How does it work?
In assets you'll find a file called PlayerControl.cs
This file contains a subroutine that continually sends get requests to two StdLib webhooks. The function of these two is to return the latest message sent to a specified number and then to reset the airtable after receiving the message.