using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;

[Serializable]
public class MapInfos
{
    public int Height, Width;
    public float CellSize;
    public List<Vector2Int> CellPos;

    public MapInfos()
    {
        CellPos = new List<Vector2Int>();
    }
}
