using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

public class PaintingMap : MonoBehaviour
{
    [SerializeField] private Tilemap _tileMap;
    [SerializeField] private Tile _tileToPaint;


    private void Update()
    {
        if (Input.GetMouseButton(0))
            PaintOver();
    }

    public void PaintOver()
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3Int cellPos = _tileMap.WorldToCell(pos);

        if (_tileMap.HasTile(cellPos))
            _tileMap.SetTile(cellPos, _tileToPaint);
    }
}