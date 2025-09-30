using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Map : MonoBehaviour
{
   [SerializeField]private int _height;
   [SerializeField]private int _width;

   [SerializeField]private Tilemap _tilemap;
   [SerializeField]private List<Tile> _tile;
   private void Start()
   {
      for (int y = 0; y < _height; y++)
      {
         for (int x = 0; x < _width; x++)
         {
            int r = Random.Range(0, _tile.Count);
            _tilemap.SetTile(new Vector3Int(x, y, 0), _tile[r]);
         }
      }
   }
   
   
   
}
