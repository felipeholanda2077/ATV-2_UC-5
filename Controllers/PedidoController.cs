using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Atividade2.Models;

namespace Atividade2.Controllers
{
    
    public class PedidoController :Controller
    {
        
        public IActionResult ExibirPedido(int i)
        {
            List<Pedido> pedidos = ListaPedidos.ListarPedidos();
            List<Item> lista = pedidos[i].ListarItens();
            return View("Pedido", pedidos[i]);
        }
        
          
        public IActionResult CadastrarItem(int i)
        {
            Item item = new Item();
            item.itemPedido = i+1;
            return View("AdicionarItem", item);
        }

        
        public IActionResult IncluirItem(Item i)
        {
            int IndexPedido = i.itemPedido - 1;
            List<Pedido> lista = ListaPedidos.ListarPedidos();
            lista[IndexPedido].AdicionarItem(i);
            return View("Pedido", lista[IndexPedido]);
        }

        
        public IActionResult RemoverItem(int p, int i)
        {
            int IndexPedido = p;
            List<Pedido> lista = ListaPedidos.ListarPedidos();
            lista[IndexPedido].DeletarItem(i);
            return View("Pedido", lista[IndexPedido]);
        }

        
        public IActionResult FinalizarPedido(int p)
        {
            int IndexPedido = p;
            List<Pedido> pedidos = ListaPedidos.ListarPedidos();
            return View("FinalizarPedido", pedidos[p]);
        }
    }
}