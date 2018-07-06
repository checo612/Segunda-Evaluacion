using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ProyectoBlog.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        //public string Date { get; set; }
        public int PostId { get; set; }

    }
}