using UnityEngine;
namespace OutworldMini
{
    [CreateAssetMenu(fileName = "AllScenesSO", menuName = "Outworld.Mini/AllScenesSO", order = 0)]
    public class AllScenesSO : ScriptableObject
    {
        [SerializeField] private string starter;
        [SerializeField] private string coreScene;
        [SerializeField] private string worlSimulation;
        [SerializeField] private string ui;

        public string Starter =>starter;
        public string  CoreScene =>coreScene;
        public string WorlSimulation =>worlSimulation;
        public string UI=>ui;
    }
}


