using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EmlakOfisi.Entities
{
    public class Advertisement
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int AgentId { get; set; }

        [StringLength(50)]
        public string Title { get; set; }

        public int NumberOfRoom { get; set; }

        public int SquareMeter { get; set; }

        public int AgeOfHouse { get; set; }


    }
}
