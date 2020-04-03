using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Assets.Script
{
    [System.Serializable]
    public class GameDatas {

        public int Score;
        public string CharacterName;

        public GameDatas(string characterName, int score)
        {
            this.Score = score;
            this.CharacterName = characterName;
        }
    }
}
