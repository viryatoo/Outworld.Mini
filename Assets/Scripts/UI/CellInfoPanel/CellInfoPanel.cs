using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace OutworldMini
{
    public class CellInfoPanel : MonoBehaviour
    {
        [SerializeField] private TMP_Text population;
        [SerializeField] private TMP_Text factoryies;
        [SerializeField] private TMP_Text resources;
        [SerializeField] private TMP_Text countfood;

        [SerializeField] private TMP_Text army;
        private Map map;

        public void Init(Map gameMap)
        {
            map = gameMap;
            map.WorldMap.CellSelected+=CellSelected;
            map.WorldMap.PropertyiesCellUpdated+=UpdateText;
        }

        private CellData currentdata;
        private void OnEnable() 
        {
            if(map!=null)
            {
            map.WorldMap.CellSelected+=CellSelected;
            map.WorldMap.PropertyiesCellUpdated+=UpdateText;
            }

        }
        private void OnDisable()
        {
            if(map!=null)
            {
            map.WorldMap.CellSelected-=CellSelected;
            map.WorldMap.PropertyiesCellUpdated-=UpdateText;
            }
        }

        private void CellSelected(CellData data)
        {
            currentdata = data;
            UpdateText(data);
        }
        private void UpdateText()
        {
            UpdateText(currentdata);
        }

        private void UpdateText(CellData data)
        {
            population.text = data.Population.ToString();
            factoryies.text = data.Factories.ToString();
            resources.text = data.Resources.ToString();
            countfood.text = data.CountFood.ToString();
            army.text =  data.Army.ToString();
        }
    }
}