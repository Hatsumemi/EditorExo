using System;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class ChangeTilePaint : MonoBehaviour
{
    [SerializeField]private PaintingMap _paintingMap;
    
    public Tile Tile;
    [SerializeField]private Image _buttonImage;

    private void Start()
    {
        _buttonImage.sprite = Tile.sprite;
    }


    public void ChangeTile()
    {
        _paintingMap._replacementTile = Tile;
    }
}
