using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using OutworldMini.SOdata;

namespace OutworldMini
{
    public class WorldMapUpdater : IMapUpdater
    {
        private readonly CellData[,] gameCells;
        private readonly int mapWight;
        private readonly WorldData wordlData;

        private const int NEGATIVE = -1;

        public WorldMapUpdater(CellData[,] cells, int wight, WorldData data)
        {
            gameCells = cells;
            mapWight = wight;
            wordlData = data;
        }

        public void UpdateLayer()
        {
            for (int i = 0; i < mapWight; i++)
            {
                for (int j = 0; j < mapWight; j++)
                {
                    CellData cell = gameCells[i, j];
                    float deltaPopulation;
                    float deltaFood;
                    float deltaResources;
                    deltaFood = cell.Population * wordlData.mFoodPerPerson * NEGATIVE;
                    deltaPopulation = (cell.Population * wordlData.mAccelerationPopulation) - cell.Population;
                    deltaResources = cell.Population * wordlData.mResourcesPerPerson * NEGATIVE;
                    gameCells[i, j].ChangePopulation((int)deltaPopulation);
                    gameCells[i, j].ChangeFood((int)deltaFood);
                    gameCells[i, j].ChangeResoucres((int)deltaResources);
                }
            }
        }
    }
}