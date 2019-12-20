using System.Collections.Generic;

namespace ApiCliente.Models.Response
{
    public class OpcaoResponse
    {
	    public string descricao { get; set; }
        public int letra { get; set; } ///A, B, C, D, E
        public VerdadeResponse Verdade { get; set; }
    }
}
