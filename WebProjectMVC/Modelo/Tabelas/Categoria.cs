using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using WebProjectMVC.Modelo.Cadastros;

namespace WebProjectMVC.Modelo.Tabelas
{
    [Table ("Categoria")]
    public class Categoria
    {
        [Key]
        public long IdCategoria { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<Produto> Produtos { get; set; }
    }
}