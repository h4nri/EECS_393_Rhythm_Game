<Description>

Rhythm Master is a Guitar Hero-style rhythm game currently being developed by Henry Zheng, Kalli Schumacher, and Lucas Alva-Ganoza for EECS 393 Software Engineering at Case Western Reserve University. What sets Rhythm Master apart from other rhythm games is its emphasis on using both the keyboard and mouse to hit notes. More information on the game will be added at a later date.

<TODO List>

Improve UI and create menu scenes (ex. settings)
Create animations for button presses and note hits
Develop a level editor
Design and create more levels and a campaign mode (done after the level editor is complete)

<Referential Information for Developers>

Steps to determine the distance (y) between beats:
  1) Find BPM and convert it to BPS
  2) Divide BPS by fall speed of notes
  3) Divide 1 by the above quotient

1920x1080 background images should have position.y = 5.6, rotation.x = -65, and scale.x and scale.y both = 1.3. 