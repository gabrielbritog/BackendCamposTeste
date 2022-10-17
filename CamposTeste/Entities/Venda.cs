using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CamposTeste.Entities
{
    public class Venda : Entity
    {
        [ForeignKey("Cliente")] 
        public int ClienteId { get; set; } //Referenciada como chave estrangeira via Annotations
        [ForeignKey("Produto")]
        public int ProdutoId { get; set; }//Referenciada como chave estrangeira via Annotations
        public int QtdVenda { get; set; }
        public DateTime DthVend { get; set; }
        public float VlrUnitarioVenda { get; set; }
        public float VlrTotalVenda { get; set; }

    }
}
