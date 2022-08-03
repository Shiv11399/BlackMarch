using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum TileState
{
    ObsticleOFF = 0,
    ObsticleON = 1,
}
public class Tile : MonoBehaviour
{
    public int tileIndex;
    public TileState _TileState = TileState.ObsticleOFF;
    public GameObject Obstacle;

    
}
