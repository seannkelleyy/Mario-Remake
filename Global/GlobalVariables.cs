using System.Collections.Generic;

public class GlobalVariables
{
    public static Dictionary<string, int[]> spriteNumbers = new Dictionary<string, int[]> {
            { "fireFlower", new int[] { 0, 0, 16, 16, 4, 1, 0 } },
            { "star", new int[] { 0, 16, 16, 16, 4, 1, 0 } },
            { "coin", new int[] { 0, 32, 16, 16, 4, 1, 0 } },
            { "mushroom", new int[] { 0, 48, 16, 16, 1, 1, 0 } },
            { "1up", new int[] { 0, 64, 16, 16, 1, 1, 0 } },
            { "questionMarkTile", new int[] { 0, 0, 16, 16, 3, 1, 1 } },
            { "brickTile", new int[] { 0, 16, 16, 16, 1, 1, 1 } },
            { "emptyTile", new int[] { 16, 16, 16, 16, 1, 1, 1 } },
            { "rockTile", new int[] { 32, 16, 16, 16, 1, 1, 1 } },
            { "stoneTile", new int[] { 0, 32, 16, 16, 1, 1, 1 } },
            { "pipeTile", new int[] { 16, 32, 32, 32, 1, 1, 1 } },
            { "goomba", new int[] { 0, 0, 16, 16, 2, 1, 2 } },
            { "rightKoopa", new int[] { 0, 16, 16, 24, 2, 1, 2 } },
            { "leftKoopa", new int[] { 0, 40, 16, 24, 2, 1, 2 } },
            { "rightJumpMario", new int[] { 0, 0, 16, 16, 1, 1, 3 } },
            { "leftRunMario", new int[] { 16, 0, 16, 16, 3, 1, 3 } },
            { "rightStandMario", new int[] { 64, 0, 16, 16, 1, 1, 3 } },
            { "leftJumpMario", new int[] { 0, 16, 16, 16, 1, 1, 3 } },
            { "rightRunMario", new int[] { 16, 16, 16, 16, 3, 1, 3 } },
            { "leftStandMario", new int[] { 64, 16, 16, 16, 1, 1, 3 } } };
}
