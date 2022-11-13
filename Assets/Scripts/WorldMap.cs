using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace OutworldMini
{
    public class WorldMap
    {

        public event Action<CellData> CellSelected;
        public event Action PropertyiesCellUpdated;
        public CellData[,] CellMap =>cellMap;
        

        private Tile cellTile;
        private Tilemap tilemap;
        private Camera gameCamera;
        private int wight;
        private CellData[,] cellMap;
        private CellData selectedCell;
        private List<WCountry> countryies;
        /*
        TODO: 
        - Доделать апдеётеров. Чтобы каждый апдейтер отвечал за определённый слой абстракции.
        - Придумать как инитить WorldData в ячейки (Может что то в иде провайдера бахнуть)
        */
        private List<IMapUpdater> mapUpdaters;



        public WorldMap(Tilemap map, Tile tile, int w)
        {
            tilemap = map;
            cellTile = tile;
            gameCamera = Camera.main;
            wight = w;
            countryies = new List<WCountry>();
            mapUpdaters = new List<IMapUpdater>();
            GenerateWorld(12);
        }
        public void AddUpdater(IMapUpdater updater)
        {
            mapUpdaters.Add(updater);
        }
        public void RemoveUpdater(IMapUpdater updater)
        {
            mapUpdaters.Remove(updater);
        }
        public void NexTick()
        {
            foreach(var updater in mapUpdaters)
            {
                updater.UpdateLayer();
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

        public void CalculateCountryBorders(BordersBuilder builder)
        {
            for(int i = 0 ; i<countryies.Count;i++)
            {
                var currentCountry = countryies[i];
                for(int j = 0;j<currentCountry.Cells.Count;j++)
                {
                    var cell = currentCountry.Cells[j];
                    int x = cell.WorldPosition.x;
                    int y = cell.WorldPosition.y;
                    Vector3Int pos = cell.WorldPosition;
                    BordersNeighbour bordersNeighbour = new BordersNeighbour();
                    bordersNeighbour.Left = CheckOutOfRangeArray(x-1,y) && !IsCurrentCountry(pos + Vector3Int.left,currentCountry);
                    bordersNeighbour.Right = CheckOutOfRangeArray(x+1,y) && !IsCurrentCountry(pos + Vector3Int.right,currentCountry);
                    bordersNeighbour.Up = CheckOutOfRangeArray(x,y+1) && !IsCurrentCountry(pos + Vector3Int.up,currentCountry);
                    bordersNeighbour.Down = CheckOutOfRangeArray(x,y-1) && !IsCurrentCountry(pos + Vector3Int.down,currentCountry);
                    builder.CalcualateBordersForCell(x,y,bordersNeighbour);



                }
            }
        }
       
        private void InitCell(int x, int y)
        {
            tilemap.SetTileFlags(new Vector3Int(x, y, 0), TileFlags.None);
            tilemap.SetTile(new Vector3Int(x, y, 0), cellTile);
            cellMap[x, y] = new CellData(new Vector3Int(x, y, 0),
                                         UnityEngine.Random.Range(0, 10),
                                         UnityEngine.Random.Range(10, 5000),
                                         UnityEngine.Random.Range(0, 100),
                                         UnityEngine.Random.Range(1, 6),
                                         UnityEngine.Random.Range(100, 50000)
                                         );
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
                WCountry country = GenerateCountry(UnityEngine.Random.Range(0,wight), UnityEngine.Random.Range(0,wight));
                countryies.Add(country);
            }

        }
        private WCountry GenerateCountry(int x, int y)
        {
            int totalIter = 8;
            WCountry country = new WCountry(UnityEngine.Random.Range(0,100000000),UnityEngine.Random.ColorHSV());
            Color color = UnityEngine.Random.ColorHSV();
            GenerateRecursiveCountry(x, y, totalIter, country);
            return country;
        }

        private void GenerateRecursiveCountry(int x, int y, int iterations, WCountry country)
        {
            if (iterations == 0) { return; }
            int it = iterations - 1;
            Vector3Int pos = new Vector3Int(x, y, 0);
            tilemap.SetTileFlags(pos, TileFlags.None);
            tilemap.SetColor(pos, country.CountryColor);
            country.AddCellToCountry(cellMap[x,y]);
            for (int i = 0; i < 4; i++)
            {
                int xOffset = (int)UnityEngine.Random.Range(-1, 2);
                int yOffset = (int)UnityEngine.Random.Range(-1, 2);
                if (CheckOutOfRangeArray(x + xOffset, y + yOffset) &&
                IsCurrentCountry(new Vector3Int(x + xOffset, y + yOffset, 0), country) == false)
                {
                    GenerateRecursiveCountry(x + xOffset, y + yOffset, it, country);
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

        private bool IsCurrentCountry(Vector3Int pos,WCountry country)
        {
            if (country.HasCell(cellMap[pos.x,pos.y]))
            {
                return true;
            }
            return false;
        }


    }
}

