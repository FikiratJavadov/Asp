using FinalProjectasp.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectasp.ViewModels
{
    public class EventVm
    {

        [Required]
        public string Image { get; set; }
        [Required]
        public DateTime Day { get; set; }
        [Required]
        public DateTime StartTime { get; set; }
        [Required]
        public DateTime Endtime { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public string EventName { get; set; }


        [Required]

        public bool IsDeleted { get; set; }
        [Required]



        public string Description { get; set; }



        public IFormFile Photo { get; set; }
    }
}

