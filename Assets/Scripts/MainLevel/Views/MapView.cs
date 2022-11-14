using UnityEngine;
using UnityEngine.Tilemaps;

namespace OutworldMini.MainLevel.Views
{
    public class MapView: MonoBehaviour
    {
        [SerializeField] private Tile tileCell;
        private Tilemap tilemap;
        private readonly Camera gameCamera;
        
        public void Init()
        {
            tilemap = GetComponent<Tilemap>();
        }

        public void SetTileColor(Vector3Int pos, Color color)
        {
            tilemap.SetTileFlags(pos, TileFlags.None);
            tilemap.SetColor(pos,color);
        }

        public void AddTile(Vector3Int pos)
        {
            tilemap.SetTileFlags(pos, TileFlags.None);
            tilemap.SetTile(pos, tileCell);
        }
        
        public Vector3Int GetTilePositionFromMousePosition()
        {
            Vector3 mouseWorldPos = gameCamera.ScreenToWorldPoint(Input.mousePosition);
            return tilemap.WorldToCell(mouseWorldPos);
        }
    }
}