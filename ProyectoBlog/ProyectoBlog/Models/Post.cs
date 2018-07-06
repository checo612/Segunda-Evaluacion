using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace ProyectoBlog.Models
{
    public class Post
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El titulo es requerido")]
        [Display(Name = "Titulo")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Se requiere contenido")]
        [Display(Name = "Contenido")]
        public string Content { get; set; }


        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        public DateTime Fecha { get; set; }

    }
}