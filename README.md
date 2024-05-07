Matt Izzo

IGME 750 Final

Genre: 2D platformer

Build: Unity 2022.3.4f1 with no external dependencies

Target platform: Windows

Features:
Quadtree custom collision detection
Debug line renders to show hitboxes
Custom Shader for the enemy
Scalable difficulty (Enemy speed and how often closely they follow the player)
Difficulty preferences saved between scenes
Works with standard gamepad (In theory, I lack the controller needed to test this)
3 levels and 1 “boss” level
4 different enemy AI patterns for the boss level
1 chases like the regular enemy
1 gets between the player and (0,0)
1 goes to a random location relatively near the player. This one moves slightly faster to keep it more relevant.
1 acts like the Centipede in the Atari game Centipede. This moves a lot faster than the other enemies since it generally isn’t a threat.

Technical Details:
Controls are set and saved via the Unity input actions system
Enemy difficulty preferences are saved by the Unity PlayerPrefs system
The platforms are saved in 4 different arrays, one for each quadrant. The game only checks if the player is colliding with platforms in the same quadrant. Platforms on or near the edge of a quadrant are held in two different arrays.
Collision detection just uses the corners of the object and don’t take rotation into account
The “generic” enemy AI uses two variables, speed and coolDownTime (aka intelligence). The enemy moves to their target at the speed indicated by the variable speed. When the coolDownTime is 0, the enemy sets the player’s current position as the target. The “smarter” the enemy slider is the lower the coolDownTimer will be, meaning it gets the player’s position more often.
Instructions: WASD/Left Control stick to move. Space/South Button to jump. R/East Button to reset the scene. Escape/Start to pause the game. `/Select to toggle visible hitboxes. Avoid the black cube chasing you and reach the green capsule in all 4 levels.

Known Issues:
The line renders used to show hitboxes don’t appear as cleanly as I would like. Sometimes they are too thin and don’t fully appear in gameplay despite showing in the scene.
If the player is at the top of their jump and they hit the top of a wall, they gain a little bit of extra height to clear the wall and land on top of the platform.

Post Mortem: Overall I’m happy with the game. The player movement feels pretty good and the quadtree collision is functional but not totally perfect. The enemy shader looks cool especially considering I am very much not an artist. I’m particularly proud of difficulty scaling, having two scalable variables for the enemies means the player has a lot of control over how the game plays. The enemy patterns on the last level are also good. At higher speeds it can really become tough which I am satisfied with. I think every level plays pretty differently as well which makes me happy.
	That being said, there are some things I would improve on or add if I had more time. The biggest thing is adding some more persistent data and keeping that data in a JSON instead of the Unity PlayerPrefs systems. I particularly wanted to keep track of time and deaths and show those at the end.

Video Demo: https://www.youtube.com/watch?v=d6dpPOBUjSI 
