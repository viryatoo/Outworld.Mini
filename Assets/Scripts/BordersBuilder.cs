using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OutworldMini
{
    public class BordersBuilder : MonoBehaviour
    {
        private BorderCell prefab;
        private BorderCell[,] borderCells;

        public void SetCellPrefab(BorderCell bc)
        {
            prefab = bc;
        }
        public void Init(int wight)
        {
            borderCells = new BorderCell[wight, wight];
            for (int i = 0; i < wight; i++)
            {
                for (int j = 0; j < wight; j++)
                {
                    BorderCell border = GameObject.Instantiate(prefab, new Vector3(i, j, 0), Quaternion.identity, transform);
                    border.Init();
                    borderCells[i, j] = border;
                }
            }
        }
        public void CalculateBordersForCell(int x, int y, BordersNeighbour neighbour)
        {
            borderCells[x, y].SetBorderCell(neighbour);
        }

    }
}
