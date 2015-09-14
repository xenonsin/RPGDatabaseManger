using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGDatabaseManager.Models
{
    class Character
    {

        public string Name { get; set; }
        public int ID { get; set; }

        public List<CharacterAttribute> Attributes { get; } = new List<CharacterAttribute>();
        public List<CharacterProperty> Properties { get;} = new List<CharacterProperty>();
        public List<CharacterStats> Stats { get;}  = new List<CharacterStats>();
        public List<CharacterPortraits> Portraits { get;} = new List<CharacterPortraits>();
        public string Description { get; set; }

        public Character(string name)
        {
            Name = name;
            Description = "Sample Text";
            ID = -1;
        }

    }
}
