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
            { "brickTileUnderground", new int[] { 64, 16, 16, 16, 1, 1, 1 } },
            { "floorTileUnderground", new int[] { 48, 16, 16, 16, 1, 1, 1 } },
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
            { "rightJumpMario", new int[] { 0, 16, 16, 16, 1, 1, 3 } },
            { "leftRunMario", new int[] { 16, 0, 16, 16, 3, 1, 3 } },
            { "rightStandMario", new int[] { 64, 16, 16, 16, 1, 1, 3 } },
            { "leftJumpMario", new int[] { 0, 0, 16, 16, 1, 1, 3 } },
            { "rightRunMario", new int[] { 16, 16, 16, 16, 3, 1, 3 } },
            { "leftStandMario", new int[] { 64, 0, 16, 16, 1, 1, 3 } },
            { "deadMario", new int[] { 80, 0, 16, 16, 1, 1, 3 } },
            //big mario
            { "leftJumpBigMario", new int[] { 0, 32, 16, 32, 1, 1, 3 } },
            { "leftRunBigMario", new int[] { 16, 32, 16, 32, 3, 1, 3 } },
            { "leftStandBigMario", new int[] { 64, 32, 16, 32, 1, 1, 3 } },
            { "leftCrouchBigMario", new int[] { 80, 32, 16, 32, 1, 1, 3 } },
            { "rightJumpBigMario", new int[] { 0, 64, 16, 32, 1, 1, 3 } },
            { "rightRunBigMario", new int[] { 16, 64, 16, 32, 3, 1, 3 } },
            { "rightStandBigMario", new int[] { 64, 64, 16, 32, 1, 1, 3 } },
            { "rightCrouchBigMario", new int[] { 80, 64, 16, 32, 1, 1, 3 } },
            //fire mario
            { "rightJumpFireMario", new int[] { 0, 96, 16, 32, 1, 1, 3 } },
            { "rightRunFireMario", new int[] { 16, 96, 16, 32, 3, 1, 3 } },
            { "rightStandFireMario", new int[] { 64, 96, 16, 32, 1, 1, 3 } },
            { "rightCrouchFireMario", new int[] { 80, 96, 16, 32, 1, 1, 3 } },
            { "leftJumpFireMario", new int[] { 0, 128, 16, 32, 1, 1, 3 } },
            { "leftRunFireMario", new int[] { 16, 128, 16, 32, 3, 1, 3 } },
            { "leftStandFireMario", new int[] { 64, 128, 16, 32, 1, 1, 3 } },
            { "leftCrouchFireMario", new int[] { 80, 128, 16, 32, 1, 1, 3 } },
            //fireball
            { "fireball", new int[] { 0, 0, 8, 8, 2, 1, 4 } } ,
            { "fireballExplosion", new int[] { 0, 8, 16, 16, 3, 1, 4 } }
     };
}
