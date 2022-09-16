using System.ComponentModel.DataAnnotations;

namespace APICotacao.Models
{
    public class CotacaoItem
    {
        public int Id { get; set; }
        [Required]
        public string Descricao { get; set; }
        [Required]
        public int NumeroItem { get; set; }
        public double Preco { get; set; }
        [Required]
        public int Quantidade { get; set; }
        public string Marca { get; set; }
        public int Unidade { get; set; }


    }
}
