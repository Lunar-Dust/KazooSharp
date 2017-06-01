using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace KazooQuestCS
{
    public class Stats
    {
        private int level = -1;
        private int hp;
        private int maxHP;
        private int mp;
        private int maxMP;
        private int stamina;
        private int maxStamina;
        private int str;
        private int def;
        private int res;
        private int spd;

        private bool statsSet = false;

        public Stats()
        {

        }

        public void Set(int _level, int _maxHP, int _maxMP,
            int _maxStamina, int _str, int _def, int _res)
        {
            if (statsSet) return;
            level = _level;
            maxHP = _maxHP;
            maxMP = _maxMP;
            maxStamina = _maxStamina;
            str = _str;
            def = _def;
            res = _res;
            statsSet = true;
        }

        public void FromXml(XmlNode node)
        {
            for(int x=0; x < node.ChildNodes.Count; ++x)
            {
                switch(node.ChildNodes[x].Name)
                {
                    case "level":
                        level = int.Parse(node.ChildNodes[x].InnerText);
                        break;
                    case "hp":
                        maxHP = int.Parse(node.ChildNodes[x].InnerText);
                        hp = maxHP;
                        break;
                    case "mana":
                        maxMP = int.Parse(node.ChildNodes[x].InnerText);
                        mp = maxMP;
                        break;
                    case "stamina":
                        maxStamina = int.Parse(node.ChildNodes[x].InnerText);
                        stamina = MaxStamina;
                        break;
                    case "str":
                        str = int.Parse(node.ChildNodes[x].InnerText);
                        break;
                    case "def":
                        def = int.Parse(node.ChildNodes[x].InnerText);
                        break;
                    case "res":
                        res = int.Parse(node.ChildNodes[x].InnerText);
                        break;
                    case "spd":
                        spd = int.Parse(node.ChildNodes[x].InnerText);
                        break;
                }
            }
        }

        public int Level
        {
            get
            {
                return level;
            }
        }

        public int HP
        {
            get
            {
                return hp;
            }

            set
            {
                hp = value;
            }
        }

        public int MaxHP
        {
            get
            {
                return maxHP;
            }
        }

        public int MP
        {
            get
            {
                return mp;
            }

            set
            {
                mp = value;
            }
        }

        public int MaxMP
        {
            get
            {
                return maxMP;
            }
        }

        public int Stamina
        {
            get
            {
                return stamina;
            }

            set
            {
                stamina = value;
            }
        }

        public int MaxStamina
        {
            get
            {
                return maxStamina;
            }
        }

        public int Str
        {
            get
            {
                return str;
            }

            set
            {
                str = value;
            }
        }

        public int Def
        {
            get
            {
                return def;
            }

            set
            {
                def = value;
            }
        }

        public int Res
        {
            get
            {
                return res;
            }

            set
            {
                res = value;
            }
        }

        public int Spd
        {
            get
            {
                return spd;
            }

            set
            {
                spd = value;
            }
        }
    }
}
