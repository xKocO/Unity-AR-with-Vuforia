using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData  {

    private static bool jugando = false;
    public bool Jugando {
        get {
            return jugando;
        }
        set {
            jugando = value;
        }
    }

    private int vidaZombie = 10, vidaCaster = 20, vidaMonstruo = 15,vidaPlayer = 15;
    private static int puntos = 0;

    public int vidaZ {
        get {
            return vidaZombie;
        }
    }

    public int vidaC
    {
        get
        {
            return vidaCaster;
        }
    }

    public int vidaM
    {
        get
        {
            return vidaMonstruo;
        }
    }

    public int vidaP {
        get {
            return vidaPlayer;
        }
    }

    public int puntaje {
        get {
            return puntos;
        }
        set {
            puntos = value;
        }
    }

}
