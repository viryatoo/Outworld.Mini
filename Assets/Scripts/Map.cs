using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace OutworldMini
{
    public class Map : MonoBehaviour
    {

        [SerializeField] private Tilemap tilemap;
        [SerializeField] private Tile tilecell;
        [SerializeField] private int wight;
        [HideInInspector] public int Wight => wight;
        private WorldMap worldMap;
        public void Init()
        {
            worldMap = new WorldMap(tilemap,tilecell,wight);
        }

        // Update is called once per frame
        void Update()
        {
            if(Input.GetMouseButtonDown(0))
            {
                worldMap.MouseInMap();
            }
        }
    }
}
