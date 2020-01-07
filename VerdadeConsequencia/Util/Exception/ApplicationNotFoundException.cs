using System.Globalization;
using System;

namespace VerdadeConsequencia.Util
{
    public class ApplicationNotFoundException : Exception
    {
        #region Mensagens
        public static readonly string VERDADE_NAO_ENCONTRADA = "Verdade não encontrada.";
        public static readonly string CONSEQUENCIA_NAO_ENCONTRADA = "Consequência não encontrada.";
        public static readonly string TIPO_NAO_ENCONTRADO = "Tipo não encontrado.";
        public static readonly string ALERTA_NAO_ENCONTRADO = "Alerta não encontrado.";
        public static readonly string OPCAO_NAO_ENCONTRADO = "Opção não encontrado.";
        public static readonly string ENDERECO_NAO_ENCONTRADO = "Endereço não encontrado.";
        public static readonly string PESSOA_NAO_ENCONTRADO = "Pessoa não encontrada.";

        #endregion

        public string ContentType { get; set; } = @"text/plain";

        public ApplicationNotFoundException() : base()
        {
        }

        public ApplicationNotFoundException(string message) : base(message) { }

        public ApplicationNotFoundException(string message, params object[] args)
            : base(string.Format(CultureInfo.CurrentCulture, message, args))
        {
        }

        public ApplicationNotFoundException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
