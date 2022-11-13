using System;
using System.Collections;
using System.Collections.Generic;
using OutworldMini.MainLevel.Views;
using UnityEngine;

namespace OutworldMini
{
    public class WorldMap
    {

        public event Action<CellData> CellSelected;
        public event Action PropertiesCellUpdated;
        public CellData[,] CellMap { get; private set; }

       
        private readonly MapView view;
        private readonly int wight;
        private readonly List<WCountry> countries;
        
        private CellData selectedCell;

        /*
        TODO: 
        - Доделать апдеётеров. Чтобы каждый апдейтер отвечал за определённый слой абстракции.
        - Придумать как инитить WorldData в ячейки (Может что то в иде провайдера бахнуть)
        - Вынести реализацию генерацию стран в отдельные классы.
        */
        private readonly List<IMapUpdater> mapUpdaters;



        public WorldMap(MapView mapView, int w)
        {
            view = mapView;
            wight = w;
            countries = new List<WCountry>();
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
            PropertiesCellUpdated?.Invoke();
        }

        public void SelectCell()
        {
            if (!UIExt.IsPointerOverUIElement())
            {

                Vector3Int position = view.GetTilePositionFromMousePosition();
                selectedCell = CellMap[position.x, position.y];
                CellSelected?.Invoke(selectedCell);

            }
        }

        public void CalculateCountryBorders(BordersBuilder builder)
        {
            foreach (var currentCountry in countries)
            {
                foreach (var cell in currentCountry.Cells)
                {
                    int x = cell.WorldPosition.x;
                    int y = cell.WorldPosition.y;
                    Vector3Int pos = cell.WorldPosition;
                    BordersNeighbour bordersNeighbour = new BordersNeighbour
                    {
                        Left = CheckOutOfRangeArray(x-1,y) && !IsCurrentCountry(pos + Vector3Int.left,currentCountry),
                        Right = CheckOutOfRangeArray(x+1,y) && !IsCurrentCountry(pos + Vector3Int.right,currentCountry),
                        Up = CheckOutOfRangeArray(x,y+1) && !IsCurrentCountry(pos + Vector3Int.up,currentCountry),
                        Down = CheckOutOfRangeArray(x,y-1) && !IsCurrentCountry(pos + Vector3Int.down,currentCountry)
                    };
                    builder.CalculateBordersForCell(x,y,bordersNeighbour);
                }
            }
        }
       
        private void InitCell(int x, int y)
        {
            view.AddTile(new Vector3Int(x,y));
            CellMap[x, y] = new CellData(new Vector3Int(x, y, 0),
                                         UnityEngine.Random.Range(0, 10),
                                         UnityEngine.Random.Range(10, 5000),
                                         UnityEngine.Random.Range(0, 100),
                                         UnityEngine.Random.Range(1, 6),
                                         UnityEngine.Random.Range(100, 50000)
                                         );
        }
        private void GenerateWorld(int totalCountries)
        {
            CellMap = new CellData[wight, wight];
            for (int i = 0; i < wight; i++)
            {
                for (int j = 0; j < wight; j++)
                {
                    InitCell(i, j);
                }
            }
            for(int i = 0 ; i<totalCountries;i++)
            {
                WCountry country = GenerateCountry(UnityEngine.Random.Range(0,wight), UnityEngine.Random.Range(0,wight));
                countries.Add(country);
            }

        }
        private WCountry GenerateCountry(int x, int y)
        {
            const int totalIter = 8;
            WCountry country = new WCountry(UnityEngine.Random.Range(0, 100000000), UnityEngine.Random.ColorHSV());
            GenerateRecursiveCountry(x, y, totalIter, country);
            return country;
        }

        private void GenerateRecursiveCountry(int x, int y, int iterations, WCountry country)
        {
            if (iterations == 0) { return; }
            int it = iterations - 1;
            Vector3Int pos = new Vector3Int(x, y, 0);
            view.SetTileColor(pos, country.CountryColor);
            country.AddCellToCountry(CellMap[x,y]);
            for (int i = 0; i < 4; i++)
            {
                int xOffset = UnityEngine.Random.Range(-1, 2);
                int yOffset = UnityEngine.Random.Range(-1, 2);
                if (CheckOutOfRangeArray(x + xOffset, y + yOffset) &&
                IsCurrentCountry(new Vector3Int(x + xOffset, y + yOffset, 0), country) == false)
                {
                    GenerateRecursiveCountry(x + xOffset, y + yOffset, it, country);
                }

            }
        }
      
        private bool CheckOutOfRangeArray(int x, int y)
        {
            return x >= 0 && x < wight && y >= 0 && y < wight;
        }

        private bool IsCurrentCountry(Vector3Int pos,WCountry country)
        {
            return country.HasCell(CellMap[pos.x,pos.y]);
        }


    }
}

