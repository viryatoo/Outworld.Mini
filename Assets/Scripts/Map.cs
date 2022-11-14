using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using OutworldMini.MainLevel.Views;
using UnityEngine;
using UnityEngine.Tilemaps;
using OutworldMini.SOdata;

namespace OutworldMini
{
    public class Map : MonoBehaviour
    {
        public int WorldWight => worldData.worldWight;
        public WorldMap WorldMap { get; private set; }
        
        [SerializeField] private MapView mapView;
        [SerializeField] private BordersBuilder bordersBuilder;
        [SerializeField] private WorldData worldData;
        
        public void Init()
        {
            mapView.Init();
            WorldMap = new WorldMap(mapView,worldData.worldWight);
            IMapUpdater worldMapUpdater = new WorldMapUpdater(WorldMap.CellMap,worldData.worldWight,worldData);
            WorldMap.AddUpdater(worldMapUpdater);
            bordersBuilder.Init(worldData.worldWight);
            WorldMap.CalculateCountryBorders(bordersBuilder);
        }

        public void UpdateWorld()
        {
            WorldMap.NexTick();
        }
        // Update is called once per frame
        void Update()
        {
            if(Input.GetMouseButtonDown(0))
            {
                WorldMap.SelectCell();
            }
        }
        
    }
}
