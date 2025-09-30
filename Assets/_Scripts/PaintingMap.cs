using System;
using System.Collections.Generic;
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
    public bool _hasClicked = false;


    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
            _hasClicked = false;

        if (Input.GetMouseButton(0))
        {
            IsOnUI(Input.mousePosition);
            if (_hasClicked == false)
                PaintOver();
        }
    }

    public void PaintOver()
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3Int cellPos = _tileMap.WorldToCell(pos);

        _tileMap.SetTile(cellPos, _replacementTile);
    }


    bool IsOnUI(Vector2 position)
    {
        UnityEngine.EventSystems.PointerEventData pointer =
            new UnityEngine.EventSystems.PointerEventData(UnityEngine.EventSystems.EventSystem.current);
        pointer.position = position;
        List<UnityEngine.EventSystems.RaycastResult> raycastResult = new List<UnityEngine.EventSystems.RaycastResult>();
        UnityEngine.EventSystems.EventSystem.current.RaycastAll(pointer, raycastResult);

        if (raycastResult.Count > 0)
            _hasClicked = true;
        
        return raycastResult.Count > 0;
    }
}