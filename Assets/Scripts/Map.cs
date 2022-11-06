using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace OutworldMini
{
    public class Map : MonoBehaviour
    {

        [SerializeField] private Tilemap tilemap;
        [SerializeField] private Tile tilecell;

        [SerializeField] BordersBuilder bordersBuilder;
        [SerializeField] private int wight;
        public int Wight => wight;
        private WorldMap worldMap;
        public WorldMap WorldMap => worldMap;
        
        public void Init()
        {
            worldMap = new WorldMap(tilemap,tilecell,wight);
            bordersBuilder.Init(wight);
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            worldMap.CalculateCountryBorders(bordersBuilder);
            stopwatch.Stop();
            UnityEngine.Debug.Log("Время на расчёет границы:" + stopwatch.ElapsedMilliseconds.ToString());

        }

        public void UpdateWorld()
        {
            worldMap.NexTick();
        }
        // Update is called once per frame
        void Update()
        {
            if(Input.GetMouseButtonDown(0))
            {
                worldMap.SelectCell();
            }
        }

        
    }
}
