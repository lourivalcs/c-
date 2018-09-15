using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using WebProjectMVC.Modelo.Tabelas;

namespace WebProjectMVC.Modelo.Cadastros
{
    [Table("Produto")]
    public class Produto
    {
        [Key]
        [DisplayName("ID")]
        public long IdProduto { get; set; }

        [DisplayName("PRODUTO")]
        [StringLength(100, ErrorMessage = "O nome do produto precisa de no mínimo 5 caracteres", MinimumLength = 5)]
        [Required(ErrorMessage = "Informe o nome do produto")]
        public string Nome { get; set; }

        [DisplayName("DATA CADASTRO")]
        [Required(ErrorMessage = "Informe a data de cadastro do produto")]
        public DateTime DataCadastro { get; set; }

        [DisplayName("CATEGORIA")]
        public long? IdCategoria { get; set; }
        [DisplayName("FABRICANTE")]
        public long? IdFabricante { get; set; }

        public string LogotipoMimeType { get; set; }
        public byte[] Logotipo { get; set; }

        public string NomeArquivo { get; set; }
        public long TamanhoArquivo { get; set; }

        public Categoria Categoria { get; set; }
        public Fabricante Fabricante { get; set; }
    }
}