using System.IO;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.Tilemaps;
using System.Collections.Generic;

public class Map : MonoBehaviour
{
    public PaintingMap _paintingMap; 
    [SerializeField] private int _height;
    [SerializeField] private int _width;
    [SerializeField] private Tilemap _tilemap;
    [SerializeField] private List<Tile> _tilesForMap;
    [SerializeField] private List<Tile> _tiles;
    [SerializeField] private GameObject _prefabsButton;
    [SerializeField] private List<ChangeTilePaint> _changeTilePaints;
    [SerializeField] private GameObject _buttonParents;

    private List<int> _tileIndices = new List<int>();

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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F5))
        {
            Save();
        }
    }

    public void Save()
    {
        MapInfos mapInfos = new MapInfos();
        mapInfos.Width = _width;
        mapInfos.Height = _height;
        mapInfos.CellPos.Clear();

        // Loop through the map tiles to record their indexes in _tilesForMap
        for (int y = 0; y < _height; y++)
        {
            for (int x = 0; x < _width; x++)
            {
                //Tile tile = _tilemap.GetTile<Tile>(new Vector3Int(x, y));
                Vector2Int pos = new Vector2Int(x, y);
                mapInfos.CellPos.Add(pos);
            }
        }

        // Serialize mapInfos to XML file
        XmlSerializer serializer = new XmlSerializer(typeof(MapInfos));
        string path = Path.Combine(Application.persistentDataPath, "map.xml");

        using (FileStream stream = new FileStream(path, FileMode.Create))
        {
            serializer.Serialize(stream, mapInfos);
        }

        Debug.Log("Map saved to " + path);
    }
}
