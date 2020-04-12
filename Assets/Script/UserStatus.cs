using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;

namespace Assets.Script
{
    [System.Serializable]
    public class UserStatus
    {
        public string UserPseudo;
        public int Status;
        public string Sexe;
        public int Level;
        public bool SoundPref;

        public UserStatus(string userPseudo, int status, string sexe, int level, bool soundPref)
        {
            this.UserPseudo = userPseudo;
            this.Status = status;
            this.Sexe = sexe;
            this.Level = level;
            this.SoundPref = soundPref;

        }
    }
}