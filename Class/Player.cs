using System;
using System.Collections.Generic;
using System.Data;

namespace Pen_and_Paper_Visualator.Class
{
    public class Player
    {
        public static string Name { get; set; }
        public static string ShortName { get; set; }
        public static Global.Template Template { get; set; }
        public static string PlayerName { get; set; }
        public static int Experience { get; set; }
        public static string Concept { get; set; }
        public static string Clan { get; set; }
        public static string Virtue { get; set; }
        public static string Covenant { get; set; }
        public static string Chronicle { get; set; }
        public static Global.Gender Gender { get; set; }
        public static string Vice { get; set; }
        public static string Coterie { get; set; }
        public static string Form { get; set; }
        public static int Intelligence { get; set; }
        public static int Wits { get; set; }
        public static int Resolve { get; set; }
        public static int Strength { get; set; }
        public static int Dexterity { get; set; }
        public static int Stamina { get; set; }
        public static int Presence { get; set; }
        public static int Manipulation { get; set; }
        public static int Composure { get; set; }
        public static int Academics { get; set; }
        public static int Computer { get; set; }
        public static int Investigation { get; set; }
        public static int Medicine { get; set; }
        public static int Occult { get; set; }
        public static int Politics { get; set; }
        public static int Science { get; set; }
        public static int Athletics { get; set; }
        public static int Brawl { get; set; }
        public static int Drive { get; set; }
        public static int Firearms { get; set; }
        public static int Stealth { get; set; }
        public static int Survival { get; set; }
        public static int Weaponry { get; set; }
        public static int AnimalKen { get; set; }
        public static int Empathy { get; set; }
        public static int Intimidation { get; set; }
        public static int Persuasion { get; set; }
        public static int Socialize { get; set; }
        public static int Streetwise { get; set; }
        public static int Subterfuge { get; set; }
        public static int Expression { get; set; }
        public static int Larceny { get; set; }
        public static int Crafts { get; set; }
        public static int WillpowerMax { get; set; }
        public static int WillpowerCurrent { get; set; }
        public static int Humanity { get; set; }
        public static int Health { get; set; }
        public static int Bash { get; set; }
        public static int Lethal { get; set; }
        public static int Aggravated { get; set; }
        public static int Potency { get; set; }
        public static int Vitae { get; set; }
        public static int Size { get; set; }
        public static int Defense { get; set; }
        public static int Initiative { get; set; }
        public static int Speed { get; set; }
        public static int RenownPurity { get; set; }
        public static int RenownGlory { get; set; }
        public static int RenownHonor { get; set; }
        public static int RenownWisdom { get; set; }
        public static int RenownCunning { get; set; }
        public static List<string> Armor { get; set; }
        public static Dictionary<string, int> Merit { get; set; }
        public static List<string> Flaw { get; set; }
        public static List<string> Equipment { get; set; }
        public static List<string> Weapon { get; set; }
        public static Dictionary<string, int> Discipline { get; set; }
        public static List<string> Devotion { get; set; }
        public static List<string> Gift { get; set; }
        public static List<string> Rite { get; set; }
        public static Dictionary<string, int> Arcana { get; set; }
        public static Dictionary<string, string> Rote { get; set; }
        public static Dictionary<string, string> Specialize_Skill { get; set; }
        public static int Cash { get; set; }
        public static List<Guid> Vehicle { get; set; }
        public static List<Cargo> Vehicle_Cargo { get; set; }
        public static string Image { get; set; }
        public static int Armor_General { get; set; }
        public static int Armor_Ballistic { get; set; }
        public static int Damage { get; set; }
        public static string Damage_Type { get; set; }
        public static string Status { get; set; }

        public object this[string propertyName]
        {
            get
            {
                var myType = typeof (Player);
                var myPropInfo = myType.GetProperty(propertyName);
                return myPropInfo.GetValue(this, null);
            }
            set
            {
                var myType = typeof (Player);
                var myPropInfo = myType.GetProperty(propertyName);
                myPropInfo.SetValue(this, value, null);
            }
        }
    }
}