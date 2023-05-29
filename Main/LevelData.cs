using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelData{

    private static int levelIdPuzzle = 0, levelIdAuto = 0;

    public int setPuzzleLevel {

        get {
            return levelIdPuzzle;
        }

        set {
            levelIdPuzzle = value;
        }
    }

    public int setAutoLevel {

        get {
            return levelIdAuto;
        }

        set {
            levelIdAuto = value;
        }
    }
}
