using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class PaintingMap : MonoBehaviour
{
    [SerializeField] private Tilemap _tileMap;
    [FormerlySerializedAs("_tileToPaint")] public Tile _replacementTile;


    private void Update()
    {
        if (Input.GetMouseButton(0))
            PaintOver();
    }

    public void PaintOver()
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3Int cellPos = _tileMap.WorldToCell(pos);

            _tileMap.SetTile(cellPos, _replacementTile);
    }
}