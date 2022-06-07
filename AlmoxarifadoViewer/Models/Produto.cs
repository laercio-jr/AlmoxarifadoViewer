using System;
using System.Collections.Generic;

#nullable disable

namespace AlmoxarifadoViewer.Models
{
    public partial class Produto
    {
        public int ProdutoId { get; set; }
        public long CodigoSap { get; set; }
        public string Nome { get; set; }
        public byte[] Imagem1 { get; set; }
        public byte[] Imagem2 { get; set; }
        public byte[] Imagem3 { get; set; }
        public byte[] Imagem4 { get; set; }
        public int Quantidade { get; set; }
    }
}
