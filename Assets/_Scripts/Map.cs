using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.Tilemaps;

public class Map : MonoBehaviour
{
   [SerializeField]private int _height;
   [SerializeField]private int _width;

   [SerializeField]private Tilemap _tilemap;
   [FormerlySerializedAs("_tile")] [SerializeField]private List<Tile> _tiles;
   
   private void Start()
   {
      for (int y = 0; y < _height; y++)
      {
         for (int x = 0; x < _width; x++)
         {
            int r = Random.Range(0, _tiles.Count);
            _tilemap.SetTile(new Vector3Int(x, y, 0), _tiles[r]);
         }
      }
   }
   
}
