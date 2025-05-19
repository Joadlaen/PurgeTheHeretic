# PurgeTheHeretic
i am recreating warhammer in a simplified form for uni coursework.

to play the game,you press start and two players choose which side to play.

the game will dictate who goes first with a 50% chance for the enemy or home player going first.

when the game begins, the player who's turn it is clicks on the piece to move, then they click one of the indicators that spawns after to move the piece.

this piece can no longer move and a new piece will need to be chosen.

when both pieces are moved, the player will then use the phase change button. this will activate the shooting phase.

the shooting phase will generate the shooting indicators that run a function taking the stats of the piece that is shooting in a similar way to the movement phase.

the target is assigned by looking at the vector2 position and finding the piece in that given location.

the button will change the player and phase when necessary such as pressing it during the shooting phase.

the game ends when a player reaches the opposite objective or kills both of the other player's pieces.
