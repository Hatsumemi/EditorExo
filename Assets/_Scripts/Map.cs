using UnityEngine;
using UnityEngine.Tilemaps;

public class Map : MonoBehaviour
{
   [SerializeField]private int _height;
   [SerializeField]private int _width;

   [SerializeField]private Tilemap _tilemap;
   [SerializeField]private Tile _tile;
   private void Start()
   {
      for (int y = -_height/2; y < _height/2; y++)
      {
         for (int x = -_width/2; x < _width/2; x++)
         {
            _tilemap.SetTile(new Vector3Int(x, y, 0), _tile);
         }
      }
   }
   
   
   
}
