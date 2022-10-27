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
        public WorldMap(Tilemap map,Tile tile,int w)
        {
            tilemap = map;
            cellTile = tile;
            gameCamera = Camera.main;
            wight = w;
            
            GenerateWorld();
        }
        private void GenerateWorld()
        {
            cellMap = new CellData[wight, wight];
            for (int i = 0; i < wight; i++)
            {
                for (int j = 0; j < wight; j++)
                {
                    Vector3Int pos = new Vector3Int(i, j, 0);
                    tilemap.SetTileFlags(pos, TileFlags.None);
                    tilemap.SetTile(pos, cellTile);
                    tilemap.SetTileFlags(pos, TileFlags.None);
                    tilemap.SetColor(pos,UnityEngine.Random.ColorHSV());
                    cellMap[i, j] = new CellData(10, 100, 0, 0, 5000);
                }
            }
        }
        private void NexTick()
        {
            for(int i =0;i<wight;i++)
            {
                for(int j = 0;j<wight;j++)
                {
                    cellMap[i,j].UpdateProperties();

                }
            }
            PropertyiesCellUpdated?.Invoke();
        }

        public void SelectCell()
        {
            if(!UIExt.IsPointerOverUIElement())
            {
                Vector3 mouseWorldPos = gameCamera.ScreenToWorldPoint(Input.mousePosition);
                Vector3Int tilepos = tilemap.WorldToCell(mouseWorldPos);
                selectedCell = cellMap[tilepos.x,tilepos.y];
                CellSelected?.Invoke(selectedCell);
                
            }
        }

    }
}

