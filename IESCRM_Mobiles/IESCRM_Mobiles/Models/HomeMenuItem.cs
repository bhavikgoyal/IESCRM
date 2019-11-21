using System;
using System.Collections.Generic;
using System.Text;

namespace IESCRM_Mobiles.Models
{
    
        public enum MenuItemType
        {
            Dashboard,
            About
        }
        public class HomeMenuItem
        {
            public MenuItemType Id { get; set; }

            public string Title { get; set; }
        }
    }

