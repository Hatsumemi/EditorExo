using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.Tilemaps;

public class Map : MonoBehaviour
{
   public PaintingMap _paintingMap;
   
   [SerializeField]private int _height;
   [SerializeField]private int _width;

   [SerializeField]private Tilemap _tilemap;
   [SerializeField]private List<Tile> _tilesForMap;
   [SerializeField]private List<Tile> _tiles;
   
   [SerializeField]private GameObject _prefabsButton;
   [SerializeField]private List<ChangeTilePaint> _changeTilePaints;
   [SerializeField]private GameObject _buttonParents;
   
   
   
   private void Start()
   {
      for (int y = 0; y < _height; y++)
      {
         for (int x = 0; x < _width; x++)
         {
            int r = Random.Range(0, _tilesForMap.Count);
            _tilemap.SetTile(new Vector3Int(x, y, 0), _tilesForMap[r]);
         }
      }

      foreach (var tile in _tiles)
      {
         GameObject button = Instantiate(_prefabsButton);
         button.transform.SetParent(_buttonParents.transform);
         _changeTilePaints.Add(button.GetComponent<ChangeTilePaint>());
         button.GetComponent<ChangeTilePaint>().PaintingMap = _paintingMap;
         button.GetComponent<ChangeTilePaint>().Tile = tile;
      }
      
   }
   
}
