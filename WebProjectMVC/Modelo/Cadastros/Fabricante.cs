using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebProjectMVC.Modelo.Cadastros
{
    [Table("Fabricante")]
    public class Fabricante
    {
        [Key]
        public long IdFabricante { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<Produto> Produtos { get; set; }
    }
}