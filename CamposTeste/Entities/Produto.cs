using Flunt.Validations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CamposTeste.Entities
{
    public class Produto : Entity
    {
        public string DscProduto { get; set; }
        public float VlrUnitario { get; set; }
    }
}

