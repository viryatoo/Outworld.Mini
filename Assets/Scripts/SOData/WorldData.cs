using UnityEngine;

namespace OutworldMini.SOdata
{
    [CreateAssetMenu(fileName = "WorldData", menuName = "Outworld.Mini/WorldData", order = 0)]
    public class WorldData : ScriptableObject
    {
        [Header("Constants")]
        public float MAccelerationPopulation;
        [Range(0,1)]
        public float MAccelerationResources = 0.9999f ;
        public float MFoodPerPerson;
        public float MResourcesPerPerson;
        public CountryParameters CountryParameters;
    }

    [System.Serializable]
    public class CountryParameters
    {
        [Header("Population")]
        public float MInfluenceArmyToPopulation = 1;
        public float MInfluenceHappinessToPopulation = 1;
        [Header("Technology")]
        public float MInfluenceFactoryiesToTechnology = 1;
        public float MInfluencePopulationToTechnology = 1.01f;
    }
}