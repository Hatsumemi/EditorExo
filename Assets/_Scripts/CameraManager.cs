using System;
using Unity.Android.Gradle.Manifest;
using UnityEngine;
using UnityEngine.Tilemaps;
using Screen = UnityEngine.Screen;

public class CameraManager : MonoBehaviour
{
    private Camera _cam;
    
    [SerializeField]private Tilemap _tilemap;
    
    private void Start()
    {
        _cam = GetComponent<Camera>();
        
        _cam.transform.position = new Vector3 (_cam.orthographicSize * _cam.aspect, _cam.orthographicSize, -10);
    }
}
