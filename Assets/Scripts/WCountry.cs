using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OutworldMini
{
    public class WCountry
    {
        public int ID => id;
        public Color CountryColor => countryColor;
        public event Action BordersChanged;
        public List<CellData> Cells =>cells;

        private List<CellData> cells;
        private Color countryColor;
        private int id;

        public WCountry(int idCountry,Color color)
        {
            id = idCountry;
            countryColor = color;
            cells = new List<CellData>();
        }

        public void AddCellToCountry(CellData cell)
        {
            cells.Add(cell);
        }
        public void RemoveCellToCountry(CellData cell)
        {
            cells.Remove(cell);
        }

        public bool HasCell(CellData cell)
        {
            return cells.Contains(cell);
        }
    }
}