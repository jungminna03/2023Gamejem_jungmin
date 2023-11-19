using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Define
{
    public enum Scenes
    {
        Title,
        Lobby,
        Ingame,
        Story,
    }

    public enum Sound 
    { 
        PLANETSELECT, 
        ENDBUYING, 
        Error, 
        Start, 
        PauseButton,
        BuyButton,
        Settlement,
        ItemSpawn,
        ItemCombine,
        ItemCollision,
    }

    public enum Effect
    {
        COLLISION = 11,
        Money,
    }
}
