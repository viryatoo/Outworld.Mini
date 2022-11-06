using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OutworldMini
{
    public class BorderCell : MonoBehaviour
    {

        [SerializeField] private LineRenderer leftBorder;
        [SerializeField] private LineRenderer rightBorder;
        [SerializeField] private LineRenderer upBorder;
        [SerializeField] private LineRenderer downBorder;

        public void SetBorderCell(BordersNeighbour neighbour)
        {
            leftBorder.enabled = neighbour.Left;
            rightBorder.enabled = neighbour.Right;
            upBorder.enabled = neighbour.Up;
            downBorder.enabled = neighbour.Down;
        }

        public void Init()
        {
            leftBorder.enabled = false;
            rightBorder.enabled = false;
            upBorder.enabled = false;
            downBorder.enabled = false;
        }
    }
}
