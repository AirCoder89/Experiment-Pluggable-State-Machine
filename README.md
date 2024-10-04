# Custom Pluggable State Machine Prototype


<table>
  <tr>
    <td><img src="https://github.com/user-attachments/assets/628d98c6-0224-48a2-b3e3-321b5f48e681" alt="InspectMe Logo" width="100"></td>
    <td>
      🛠️ Boost your Unity workflows with <a href="https://divinitycodes.de/">InspectMe</a>! Our tool simplifies debugging with an intuitive tree view. Check it out! 👉 
      <a href="https://assetstore.unity.com/packages/tools/utilities/inspectme-lite-advanced-debugging-code-clarity-283366">InspectMe Lite</a> - 
      <a href="https://assetstore.unity.com/packages/tools/utilities/inspectme-pro-advanced-debugging-code-clarity-256329">InspectMe Pro</a>
    </td>
  </tr>
</table>

---

Explore the capabilities of a fully customizable and independent Pluggable State Machine through this prototype. Designed from the ground up, this framework allows developers to plug in actions, decisions, and states via Scriptable Objects, creating a dynamic and versatile tool for managing AI behaviors.


**Demo Video:**

[![CLICK HERE](https://user-images.githubusercontent.com/62396712/110780204-b9c57c80-8264-11eb-8e72-919a976a2273.PNG)](https://www.youtube.com/watch?v=7Z4455O0J3Y)

## Project Overview

This prototype features NPC tanks that navigate a maze environment. The behavior of these tanks is controlled by a state machine which adjusts their actions based on environmental inputs:
- **Patrol**: Navigate through the maze following a set path.
- **Chase**: Seek out the player upon detection.
- **Attack**: Engage the player when within optimal range.

## Key Features

- **Fully Custom Framework**: Using Scriptable Objects, configure and modify behaviors, decisions, and states dynamically without modifying core system code.
- **Dynamic AI Behaviors**: Enable tanks to change behaviors based on gameplay, providing a rich and interactive player experience.

## System Components

The state machine consists of:
- **States**: What the AI is currently doing (e.g., patrolling, chasing).
- **Actions**: Tasks the AI performs while in a state (e.g., move to a point, look around).
- **Decisions**: Criteria that trigger transitions between states (e.g., player detected, health low).

---

<table>
  <tr>
    <td><img src="https://github.com/user-attachments/assets/628d98c6-0224-48a2-b3e3-321b5f48e681" alt="InspectMe Logo" width="100"></td>
    <td>
      🛠️ Boost your Unity workflows with <a href="https://divinitycodes.de/">InspectMe</a>! Our tool simplifies debugging with an intuitive tree view. Check it out! 👉 
      <a href="https://assetstore.unity.com/packages/tools/utilities/inspectme-lite-advanced-debugging-code-clarity-283366">InspectMe Lite</a> - 
      <a href="https://assetstore.unity.com/packages/tools/utilities/inspectme-pro-advanced-debugging-code-clarity-256329">InspectMe Pro</a>
    </td>
  </tr>
</table>



