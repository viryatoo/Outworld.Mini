using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OutworldMini
{
    public interface IWCountryActions
    {
        void AttackRandomNeighbourCell();
        void AttackCountry();
        void CreateArmyInRandomCell(int count);
        void CreateArmyInCell(int x,int y,int count);
        void MoveArmy();
    }
}