using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OutworldMini
{
    public class BordersBuilder : MonoBehaviour
    {
        [SerializeField] private BorderCell prefab;
        private BorderCell[,] borderCells;

        public void Init(int Wight)
        {
            borderCells = new BorderCell[Wight, Wight];
            for (int i = 0; i < Wight; i++)
            {
                for (int j = 0; j < Wight; j++)
                {
                    BorderCell border = Instantiate(prefab, new Vector3(i, j, 0), Quaternion.identity, transform);
                    border.Init();
                    borderCells[i, j] = border;
                }
            }
        }



        public void CalcualateBordersForCell(int x, int y, BordersNeighbour neighbour)
        {
            borderCells[x, y].SetBorderCell(neighbour);
        }

    }
}
