using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Assets.Script
{
    public class Questions
    {
        public List<string> tabBukhari=new List<string>();
        public List<string> tabOmarAlMoukhtar = new List<string>();
        public List<string> tabIbnKhaldoun = new List<string>();
        public List<string> tabRandom = new List<string>();
        public List<string> tabNameOfCharacters = new List<string>();
        public List<string> tabListOfAnswers = new List<string>();

        ////////Tab content : split = question,proposition1,proposition2,proposition3,proposition4,response,timer,point/////////////////
        //Tab of imam Al bukhari//
        public List<string> Bukhari()
        {
            tabBukhari.Add("Question 1 Imam Al Boukhari ?,Réponse 1,Réponse 2,Réponse 3,Réponse 4,Réponse 1,15,1");
            tabBukhari.Add("Question 2 Imam Al Boukhari  ?,Réponse 1,Réponse 2,Réponse 3,Réponse 4,Réponse 1,10,1");
            tabBukhari.Add("Question 3 Imam Al Boukhari ?,Réponse 1,Réponse 2,Réponse 3,Réponse 4,Réponse 1,10,1");
            tabBukhari.Add("Question 5 Imam Al Boukhari ?,Réponse 1,Réponse 2,Réponse 3,Réponse 4,Réponse 1,10,1");
            tabBukhari.Add("Question 5 Imam Al Boukhari ?,Réponse 1,Réponse 2,Réponse 3,Réponse 4,Réponse 1,10,1");
            tabBukhari.Add("Question 6 Imam Al Boukhari ?,Réponse 1,Réponse 2,Réponse 3,Réponse 4,Réponse 1,10,1");
            return tabBukhari;
        }

        //Tab of OmarAlMoukhtar//
        public List<string> OmarAlMoukhtar()
        {
            tabOmarAlMoukhtar.Add("Dans quel pays vivait 'Omar al moukhtar ?,La Libye,L'Ethiopie,Le Maroc,Le Mali,La Libye,20,1");
            tabOmarAlMoukhtar.Add("Que faisait l'imam durant les nuits ?,Dormir,Etudier,Prier,Manger,Prier,20,1");
            tabOmarAlMoukhtar.Add("Quel était son statut au sein de son village ?,Ministre,Gouverneur,Conseiller,Messager,Gouverneur,20,1");
            tabOmarAlMoukhtar.Add("Quelle est la caractéristique qui s'est confirmée chez l'imam en grandissant ?,La peur,La crainte,L'anxiété,Le courage,Le courage,20,1");
            tabOmarAlMoukhtar.Add("Quel animal l'imam utilisa pour combattre la bête féroce ? ,Un Âne,Un cheval,Une panthère,Un éléphant,Un cheval,20,1");
            tabOmarAlMoukhtar.Add("Quel était la nationalité de l'armée qui dominait le pays de l'imam ?,Italienne,Allemande,Americaine,Chinoise,Italienne,20,1");
            //tabOmarAlMoukhtar.Add("Quelle était l'une des méthodes que l'armée utilisait contre le peuple de l'imam ?,La torture,Le meurtre,La douceur,Aucune,La torture,10,1");
            tabOmarAlMoukhtar.Add("Quel était le nom du commandant de l'armée occupant le pays de l'imam ?,Maréchal Grizi,Maréchal bougliani,Maréchal Griaziani,Maréchal Panzani,Maréchal Griaziani,20,1");
            tabOmarAlMoukhtar.Add("En quelle année l'imam fut-il jugé par le tribunal Italien ?,1951,1921,1971,1931,1931,20,1");
            //tabOmarAlMoukhtar.Add("Quels sont les mots qui caractérisent le plus l'imam ?,Peur/Lache,Sacrifice/Perseverance,Anxieux/Individuel,Faible/Traitre,Sacrifice/Perseverance,10,1");
            //////10/10///////
            tabOmarAlMoukhtar.Add("Quel est le savant qui s'est occupé de l'éducation de l'imam ?,Muhammad Al Ghiryani,Yussuf Al Ghiryani,Hussein Al Ghiryani,'Omar Al Ghiryani,Hussein Al Ghiryani,20,1");
            tabOmarAlMoukhtar.Add("Combien de temps mettait-il pour réciter tout le coran ?,Une semaine,Moins d'une semaine,Plus de deux semaine,Plus d'une semaine,Moins d'une semaine,20,1");
            tabOmarAlMoukhtar.Add("Quel rôle avait-il au sein de son peuple ?,Enseignant,Aucun,Commercant,Agriculteur,Enseignant,20,1");
            tabOmarAlMoukhtar.Add("Quel animal est parti affronter l'imam ?,Un loup,Un ours,Un tigre,Un lion,Un lion,20,1");
            //tabOmarAlMoukhtar.Add("Quelle est l'action qu'il fit après avoir combattu la bête féroce ?,Il l'a mangé,Il l'a brulé,Il cuisit sa peau,Il accrocha sa peau,Il accrocha sa peau,10,1");
            //tabOmarAlMoukhtar.Add("Que fit L'imam contre l'armée qui dominait son pays ?,Quitter le pays,Combattre,Capituler,Il désespera,Combattre,10,1");
            //tabOmarAlMoukhtar.Add("Face à la cruauté de l'armée occupante; qu'a fait l'imam ?,Rien,Abandonner,Insulter,Resister,Resister,10,1");
            //tabOmarAlMoukhtar.Add("Quel stratagème les ennemies ont utilisés contre l'imam ?,L'acheter,L'attaquer par surpise,Le prendre en allié,Le faire abandonner,L'acheter,10,1");
            tabOmarAlMoukhtar.Add("Quel âge l'imam avait-il à sa mort ?,64 ans,52 ans,83 ans,74 ans,74 ans,20,1");
            tabOmarAlMoukhtar.Add("Vers qui l'imam plaçait toute sa confiance ?,Son peuple,Allah,Sa famille,Lui même,Allah,20,1");
            return tabOmarAlMoukhtar;
        }

        //Tab of Ibn khladoun//
        public List<string> IbnKhaldoun()
        {
            tabIbnKhaldoun.Add("Question 1 Ibn khladoun ?,Réponse 1,Réponse 2,Réponse 3,Réponse 4,Réponse 1,10,1");
            tabIbnKhaldoun.Add("Question 2 Ibn khladoun ?,Réponse 1,Réponse 2,Réponse 3,Réponse 4,Réponse 1,10,1");
            tabIbnKhaldoun.Add("Question 3 Ibn khladoun?,Réponse 1,Réponse 2,Réponse 3,Réponse 4,Réponse 1,10,1");
            tabIbnKhaldoun.Add("Question 4 Ibn khladoun?,Réponse 1,Réponse 2,Réponse 3,Réponse 4,Réponse 1,10,1");
            tabIbnKhaldoun.Add("Question 5 Ibn khladoun?,Réponse 1,Réponse 2,Réponse 3,Réponse 4,Réponse 1,10,1");
            return tabIbnKhaldoun;
        }

        //Tab of random questions//
        public List<string> RandomCharacter()
        {
            tabRandom.Add("Question 1 Ibn khladoun Ibn khladoun ?,Réponse 1,Réponse 2,Réponse 3,Réponse 4,Réponse 1,10,1");
            tabRandom.Add("Question 2 Omar Al moukhar ?,Réponse 1,Réponse 2,Réponse 3,Réponse 4,Réponse 1,10,1");
            tabRandom.Add("Question 3 Imam Al Boukhari?,Réponse 1,Réponse 2,Réponse 3,Réponse 4,Réponse 1,10,1");
            tabRandom.Add("Question 4 Ibn khladoun Ibn khladoun ?,Réponse 1,Réponse 2,Réponse 3,Réponse 4,Réponse 1,10,1");
            tabRandom.Add("Question 5 Imam Al Boukhari?,Réponse 1,Réponse 2,Réponse 3,Réponse 4,Réponse 1,10,1");
            return tabRandom;
        }

        //Tab of names of Characters//
        public List<string> NameOFCharacters()
        {
            tabNameOfCharacters.Add("Bukhari");
            tabNameOfCharacters.Add("OmarAlMoukhtar");
            tabNameOfCharacters.Add("IbnKhaldoun");
            tabNameOfCharacters.Add("RandomCharacter");
            return tabNameOfCharacters;
        }

        public List<string> ListOfAnswers()
        {
            tabListOfAnswers.Add("LeftButton");
            tabListOfAnswers.Add("RightButton");
            tabListOfAnswers.Add("BottomLeftButton");
            tabListOfAnswers.Add("BottomRightButton");
            return tabListOfAnswers;
        }

        //Calcul du total de point par personnage
        public int TotalPoint(List<string> list)
        {
            int totalPoint = 0;
            string[] splitString;

            for (int i = 0; i <SizeQuestionsTable(list); i++)
            {
                splitString = list[i].Split(',');
                totalPoint += int.Parse(splitString[5]);
            }
            return totalPoint;
        }

        public int SizeQuestionsTable(List<string> list)
        {
            return list.Count;
        }
    }
}

