using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CamposTeste.Entities
{
    public class Venda : Entity
    {
        [ForeignKey("Cliente")]
        public int ClienteId { get; set; }
        [ForeignKey("Produto")]
        public int ProdutoId { get; set; }
        public int QtdVenda { get; set; }
        [JsonIgnore]

        public DateTime DthVend { get; set; }
        public float VlrTotalVenda { get; set; }

    }
}
