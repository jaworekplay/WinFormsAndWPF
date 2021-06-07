using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Role : ObservableObject
    {
        private int id;

        public int ID
        {
            get { return id; }
            set { id = value; OnPropertyChnaged(); }
        }

        private int level;

        public int Level
        {
            get { return level; }
            set { level = value; OnPropertyChnaged(); }
        }

        private string description;
        

        public string Description
        {
            get { return description; }
            set { description = value; OnPropertyChnaged(); }
        }

        private User _user;

        public virtual User User
        {
            get => _user;
            set
            {
                _user = value;
                OnPropertyChnaged();
            }
        }
    }
}
