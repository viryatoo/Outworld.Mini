using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace OutworldMini
{
    public class WorldMap
    {

        private Tile cellTile;
        private Tilemap tilemap;
        private Camera gameCamera;
        private int wight;
        private CellData[,] cellMap;

        private CellData selectedCell;

        public event Action<CellData> CellSelected;
        public event Action PropertyiesCellUpdated;
        public WorldMap(Tilemap map, Tile tile, int w)
        {
            tilemap = map;
            cellTile = tile;
            gameCamera = Camera.main;
            wight = w;

            GenerateWorld(5);
        }
        private void GenerateWorld(int totalCountryies, bool fillFullArea = false)
        {
            cellMap = new CellData[wight, wight];
            for (int i = 0; i < wight; i++)
            {
                for (int j = 0; j < wight; j++)
                {
                    InitCell(i, j);
                }
            }
            for(int i = 0 ; i<totalCountryies;i++)
            {
                GenerateCountry(UnityEngine.Random.Range(0,wight), UnityEngine.Random.Range(0,wight));
            }

        }

        private void InitCell(int x, int y)
        {
            tilemap.SetTileFlags(new Vector3Int(x, y, 0), TileFlags.None);
            tilemap.SetTile(new Vector3Int(x, y, 0), cellTile);
            cellMap[x, y] = new CellData(UnityEngine.Random.Range(0, 10),
                                         UnityEngine.Random.Range(10, 5000),
                                         UnityEngine.Random.Range(0, 100),
                                         UnityEngine.Random.Range(1, 6),
                                         UnityEngine.Random.Range(100, 50000));
        }

        public void NexTick()
        {
            for (int i = 0; i < wight; i++)
            {
                for (int j = 0; j < wight; j++)
                {
                    cellMap[i, j].UpdateProperties();

                }
            }
            PropertyiesCellUpdated?.Invoke();
        }

        public void SelectCell()
        {
            if (!UIExt.IsPointerOverUIElement())
            {
                Vector3 mouseWorldPos = gameCamera.ScreenToWorldPoint(Input.mousePosition);
                Vector3Int tilepos = tilemap.WorldToCell(mouseWorldPos);
                selectedCell = cellMap[tilepos.x, tilepos.y];
                CellSelected?.Invoke(selectedCell);

            }
        }

        private void GenerateCountry(int x, int y)
        {
            int totalIter = 6;
            Color color = UnityEngine.Random.ColorHSV();
            GenerateRecursiveCountry(x, y, totalIter, color);
        }

        private void GenerateRecursiveCountry(int x, int y, int iterations, Color color)
        {
            if (iterations == 0) { return; }
            int it = iterations - 1;
            Vector3Int pos = new Vector3Int(x, y, 0);
            tilemap.SetTileFlags(pos, TileFlags.None);
            tilemap.SetColor(pos, color);
            for (int i = 0; i < 4; i++)
            {
                int xOffset = (int)UnityEngine.Random.Range(-1, 2);
                int yOffset = (int)UnityEngine.Random.Range(-1, 2);
                if (CheckOutOfRangeArray(x + xOffset, y + yOffset) &&
                IsCurrentCountry(new Vector3Int(x + xOffset, y + yOffset, 0), color) == false)
                {
                    GenerateRecursiveCountry(x + xOffset, y + yOffset, it, color);
                    Debug.Log(xOffset.ToString() + yOffset.ToString());
                }

            }
        }
      
        private bool CheckOutOfRangeArray(int x, int y)
        {
            if (x >= 0 && x < wight && y >= 0 && y < wight)
            {
                return true;
            }
            return false;
        }

        private bool IsCurrentCountry(Vector3Int pos, Color color)
        {
            if (tilemap.GetColor(pos) == color)
            {
                return true;
            }
            return false;
        }

    }
}

