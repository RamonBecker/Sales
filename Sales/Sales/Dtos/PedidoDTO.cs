﻿

namespace Sales.Domain
{
    public class PedidoDTO
    {

        public int IdCliente { get; set; }
        public List<ProdutoPedidoDTO> Produtos { get; set; }
    }
}
