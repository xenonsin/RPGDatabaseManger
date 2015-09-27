﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace RPGDatabaseManager.Models
{
    class Character
    {

        public string Name { get; set; }
        public int ID { get; set; }

        public List<CharacterAttribute> Attributes { get; private set; } = new List<CharacterAttribute>();
        public List<CharacterProperty> Properties { get; private set; } = new List<CharacterProperty>();
        public List<CharacterStats> Stats { get; private set; } = new List<CharacterStats>();
        public List<CharacterPortraits> Portraits { get; private set; } = new List<CharacterPortraits>();
        public string Description { get; set; }

        public Character(string name)
        {
            Name = name;
            Description = "Sample Text";
            ID = -1;
        }
        public Character(string name, int id)
        {
            Name = name;
            Description = "Sample Text";
            ID = id;
        }

        public void Reset()
        {
            Name = "Sample";
            Description = "Sample Text";

            //TODO: Need to change implementation to support dynamic adding of fields.
            Attributes = new List<CharacterAttribute>();
            Properties = new List<CharacterProperty>();
            Stats = new List<CharacterStats>();
            Portraits = new List<CharacterPortraits>();
        }

    }
}
