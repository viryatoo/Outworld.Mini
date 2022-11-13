using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OutworldMini
{
    public class CountryiesUpdater : IMapUpdater
    {
        private List<WCountry> countryies;

        public CountryiesUpdater(List<WCountry> wCountries)
        {
            countryies = wCountries;
        }

        public void UpdateLayer()
        {

        }
    }
}