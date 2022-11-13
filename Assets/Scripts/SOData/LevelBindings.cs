using UnityEngine;

namespace OutworldMini.SOdata
{
    [CreateAssetMenu(fileName = "new LevelBindings", menuName = "Outworld.Mini/LevelBindings", order = 0)]
    public class LevelBindings : ScriptableObject
    {
        private IBindingView views;
    }
    public interface IBindingView
    {
        
    }
}