using UnityEngine;

namespace OutworldMini.SOdata
{
    [CreateAssetMenu(fileName = "WorldData", menuName = "Outworld.Mini/WorldData", order = 0)]
    public class WorldData : ScriptableObject
    {
        [Header("Generation World")] 
        public int worldWight;
        [Header("Constants")]
        public float mAccelerationPopulation;
        [Range(0,1)]
        public float mAccelerationResources = 0.9999f ;
        public float mFoodPerPerson;
        public float mResourcesPerPerson;
        public CountryParameters countryParameters;
    }

    [System.Serializable]
    public class CountryParameters
    {
        [Header("Population")]
        public float mInfluenceArmyToPopulation = 1;
        public float mInfluenceHappinessToPopulation = 1;
        [Header("Technology")]
        public float MInfluenceFactoryiesToTechnology = 1;
        public float mInfluencePopulationToTechnology = 1.01f;
    }
}