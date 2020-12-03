using EmlakOfisi.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmlakOfisi.WebUI.Models
{
    public class AdvertisementModel
    {
        public int Id { get; set; }

        public int AgentId { get; set; }

        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        public int NumberOfRoom { get; set; }

        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]

        public int AgeOfHouse { get; set; }

        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        public int SquareMeter { get; set; }

        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]

        public string Title { get; set; }

    }



}
