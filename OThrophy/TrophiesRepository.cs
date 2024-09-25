using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

    public class TrophiesRepository
    {
        private int NextId = 1;
        private List<Trophy> Trophys = new List<Trophy>();
        private string? sortBy = null;

        public Trophy AddTrophy(Trophy trophy)
        {
            trophy.Validate();
            trophy.Id = NextId++;
            Trophys.Add(trophy);
            return trophy;
        }
        public List<Trophy> Get(int? minYear = null, string? comp = null)
        {
            List<Trophy> result = new List<Trophy>(Trophys);
            if (minYear != null)
            {
                result = result.Where(t => t.Year >= minYear).ToList();
            }
            if (minYear != null)
            {
                result = result.Where(t => t.Competition == comp).ToList();
            }


            return result;
        }
        public Trophy? Get(int id)
        {
            return Trophys.FirstOrDefault(t => t.Id == id);
        }
        public Trophy? Delete(int id)
        {
            Trophy? trophy = Get(id);
            if (trophy == null)
            {
                return null;
            }
            Trophys.Remove(trophy);
            return trophy;
        }
        public Trophy? Update(int id, Trophy trophy)
        {
            trophy.Validate();
            Trophy? exstingTrophy = Get(id);
            if (exstingTrophy == null)
            { return null; }
            exstingTrophy.Competition = trophy.Competition;
            exstingTrophy.Year = trophy.Year;
            return exstingTrophy;
        }
    }
