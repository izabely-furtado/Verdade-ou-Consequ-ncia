using System;
using System.Collections.Generic;
namespace ApiCliente.Models.Request
{
    public class OpcaoRequest
    {
	    public string descricao { get; set; }
        public int letra { get; set; } ///A, B, C, D, E
        public VerdadeRequest Verdade { get; set; }
    }
}
