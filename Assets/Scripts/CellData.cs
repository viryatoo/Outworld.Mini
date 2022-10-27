using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace OutworldMini
{
    /*
    TODO: Что нужно сделать
    Основная характеристика частицы мира

    */
    public class CellData
    {

        public int Factories => factories;
        public int Population =>population;
        public int Army => army;
        public int IncomeWallet => incomeWallet;
        public int Resources => resources;
        public int CountFood =>countFood;
        
        private int factories;
        private int population;
        private int army;
        private int incomeWallet;
        private int resources;
        private int countFood;

        private IFuncPropertyDependecion factoriesDependecion;
        private IFuncPropertyDependecion populationDependecion;
        private IFuncPropertyDependecion armyDependecion;

        public CellData(int fact, int pop, int arm, int wallet, int res)
        {
            factories = fact;
            population = pop;
            army = arm;
            incomeWallet = wallet;
            resources = res;
        }

        public void SetArmyDependecion(IFuncPropertyDependecion Dependecion)
        {
            armyDependecion = Dependecion;
        }
        public void SetFactoriesDependecion(IFuncPropertyDependecion Dependecion)
        {
            factoriesDependecion = Dependecion;
        }
        public void SetPopulationDependecion(IFuncPropertyDependecion Dependecion)
        {
            populationDependecion = Dependecion;
        }
        
        public void ChangeArmy(int value)
        {
            if(army+value>=0)
            {
                army+=value;
            }
        }
        public void ChangePopulation(int value)
        {
            if(population+value>=0)
            {
                population+=value;
            }
        }
        public void ChangeFactories(int value)
        {
            if(factories+value>=0)
            {
                factories+=value;
            }
        }
        public void ChangeFood(int value)
        {
            if(countFood+value>=0)
            {
                countFood+=value;
            }
        }
        public void UpdateProperties()
        {
            if (populationDependecion != null)
            {
                population = populationDependecion.NextValue(population);
            }
            if (factoriesDependecion != null)
            {
                factories = factoriesDependecion.NextValue(factories);
            }
            if (armyDependecion!=null)
            {
                army = armyDependecion.NextValue(army);
            }
        }

    }
}