using System.Collections.Generic;

public class SpriteVariables
{
    // top left x pixel of sprite,
    // top left y pixel of the sprite, 
    // width of the sprite,
    // height of the sprite, 
    // number of frames for sprite, 
    // scalar size variable, 
    // spritesheet number

    public static Dictionary<string, int[]> spriteNumbers = new Dictionary<string, int[]> {
        //top left x pixel of sprite,top left y pixel of the sprite, width of the sprite, height of the sprite, number of frames for sprite, scalar size variable, spritesheet number
            // items
            { "fireFlower", new int[] { 0, 0, 16, 16, 4, 1, 0 } },
            { "star", new int[] { 0, 16, 16, 16, 4, 1, 0 } },
            { "coin", new int[] { 0, 32, 16, 16, 4, 1, 0 } },
            { "mushroom", new int[] { 16, 64, 16, 16, 1, 1, 0 } },
            { "1up", new int[] { 0, 64, 16, 16, 1, 1, 0 } },
            //underground
            { "coinUnderground", new int[] { 0, 48, 16, 16, 4, 1, 0 } },
            { "brickTileUnderground", new int[] { 0, 16, 16, 16, 1, 1, 1 } },
            { "floorTileUnderground", new int[] { 32, 16, 16, 16, 1, 1, 1 } },
            { "pipeTileSideways", new int[] { 48, 32, 64, 32, 1, 1, 1 } },
            // blocks
            { "questionMarkTile", new int[] { 0, 0, 16, 16, 3, 1, 1 } },
            { "brickTile", new int[] { 0, 16, 16, 16, 1, 1, 1 } },
            { "brokenBrickTile", new int[] { 0, 48, 16, 16, 1, 1, 1 } },
            { "invisibleBlock", new int[] { 48, 0, 16, 16, 1, 1, 1 } },
            { "emptyBlockTile", new int[] { 16, 16, 16, 16, 1, 1, 1 } },
            { "floorTile", new int[] { 32, 16, 16, 16, 1, 1, 1 } },
            { "stoneTile", new int[] { 0, 32, 16, 16, 1, 1, 1 } },
            { "pipeTile", new int[] { 16, 32, 32, 32, 1, 1, 1 } },
            { "pipeTube", new int[] { 16, 48, 32, 16, 1, 1, 1 } },
            //goomba
            { "goomba", new int[] { 0, 0, 16, 16, 2, 1, 2 } },
            { "flippedGoomba", new int[] { 0, 64, 16, 16, 2, 1, 2 } },
            { "stompedGoomba", new int[] { 32, 0, 16, 8, 1, 1, 2 } },
            // koopa
            { "rightKoopa", new int[] { 0, 16, 16, 24, 2, 1, 2 } },
            { "leftKoopa", new int[] { 0, 40, 16, 24, 2, 1, 2 } },
            { "shellLegsKoopa", new int[] { 32, 16, 16, 16, 1, 1, 2 } },
            { "shellKoopa", new int[] { 32, 40, 16, 16, 1, 1, 2 } },
            //bullet
            { "bulletLauncher", new int[] { 80, 0, 16, 32, 1, 1, 1 } },
            { "leftBullet", new int[] { 0, 80, 16, 14, 1, 1, 2 } },
            { "rightBullet", new int[] { 16, 80, 16, 14, 1, 1, 2 } },
            { "leftBulletFlipped", new int[] { 0, 96, 16, 14, 1, 1, 2 } },
            { "rightBulletFlipped", new int[] { 16, 96, 16, 14, 1, 1, 2 } },
            //piranha
            { "piranha", new int[] { 0, 112, 16, 23, 2, 1, 2 } },
            //mario
            { "rightJumpStateMario", new int[] { 0, 16, 16, 16, 1, 1, 3 } },
            { "leftRunStateMario", new int[] { 16, 0, 16, 16, 3, 1, 3 } },
            { "rightStandStateMario", new int[] { 64, 16, 16, 16, 1, 1, 3 } },
            { "leftJumpStateMario", new int[] { 0, 0, 16, 16, 1, 1, 3 } },
            { "rightRunStateMario", new int[] { 16, 16, 16, 16, 3, 1, 3 } },
            { "leftStandStateMario", new int[] { 64, 0, 16, 16, 1, 1, 3 } },
            { "leftDeadStateMario", new int[] { 80, 0, 16, 16, 1, 1, 3 } },
            { "rightDeadStateMario", new int[] { 80, 0, 16, 16, 1, 1, 3 } },
            { "rightSlideStateMario", new int[] { 96, 16, 16, 16, 1, 1, 3 } },
            { "leftSlideStateMario", new int[] { 96, 0, 16, 16, 1, 1, 3 } },

            //big mario
            { "leftJumpStateBigMario", new int[] { 0, 32, 16, 32, 1, 1, 3 } },
            { "leftRunStateBigMario", new int[] { 16, 32, 16, 32, 3, 1, 3 } },
            { "leftStandStateBigMario", new int[] { 64, 32, 16, 32, 1, 1, 3 } },
            { "leftCrouchStateBigMario", new int[] { 80, 32, 16, 32, 1, 1, 3 } },
            { "rightJumpStateBigMario", new int[] { 0, 64, 16, 31, 1, 1, 3 } },
            { "rightRunStateBigMario", new int[] { 16, 64, 16, 32, 3, 1, 3 } },
            { "rightStandStateBigMario", new int[] { 64, 64, 16, 32, 1, 1, 3 } },
            { "rightCrouchStateBigMario", new int[] { 80, 64, 16, 32, 1, 1, 3 } },
            { "leftSlideStateBigMario", new int[] { 96, 32, 16, 32, 1, 1, 3 } },
            { "rightSlideStateBigMario", new int[] { 96, 64, 16, 32, 1, 1, 3 } },
            //fire mario
            { "rightJumpStateFireMario", new int[] { 0, 96, 16, 31, 1, 1, 3 } },
            { "rightRunStateFireMario", new int[] { 16, 96, 16, 32, 3, 1, 3 } },
            { "rightStandStateFireMario", new int[] { 64, 96, 16, 32, 1, 1, 3 } },
            { "rightCrouchStateFireMario", new int[] { 80, 96, 16, 32, 1, 1, 3 } },
            { "leftJumpStateFireMario", new int[] { 0, 128, 16, 32, 1, 1, 3 } },
            { "leftRunStateFireMario", new int[] { 16, 128, 16, 32, 3, 1, 3 } },
            { "leftStandStateFireMario", new int[] { 64, 128, 16, 32, 1, 1, 3 } },
            { "leftCrouchStateFireMario", new int[] { 80, 128, 16, 32, 1, 1, 3 } },
            { "leftSlideStateFireMario",new int[] { 96, 128, 16, 32, 1, 1, 3 }},
            { "rightSlideStateFireMario",new int[] { 96, 96, 16, 32, 1, 1, 3 }},
            { "leftAttackStateFireMario", new int[] { 16, 128, 16, 32, 1, 1, 3 }  },
            { "rightAttackStateFireMario",new int[] { 16, 96, 16, 32, 1, 1, 3 }  },
            //power Up animations
            {"leftPowerUpStateBigMario",new int[] {0, 0, 16, 32, 7, 1, 5 } },
            {"rightPowerUpStateBigMario",new int[] {0, 32, 16, 32, 7, 1, 5 } },
            {"rightPowerUpStateFireMario",new int[] {0, 64, 16, 32, 7, 1, 5 } },
            {"leftPowerUpStateFireMario",new int[] {0, 96, 16, 32, 7, 1, 5 } },
             //fireball
            { "fireball", new int[] { 0, 0, 8, 8, 2, 1, 4 } } ,
            { "fireballExplosion", new int[] { 0, 8, 16, 16, 3, 1, 4 } }
     };
}
