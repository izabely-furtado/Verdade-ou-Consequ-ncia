using System;
using System.Globalization;

namespace VerdadeConsequencia.Util
{
    public class ApplicationBadRequestException : Exception
    {
        #region Mensagens
        public static readonly string IDENTIFICADOR_INVALIDO = "Identificador inválido.";
        public static readonly string NOME_INVALIDO = "Nome inválido.";
        public static readonly string DESCRICAO_INVALIDO = "Descrição inválido.";
        public static readonly string TIPO_INVALIDO = "Tipo inválido.";
        public static readonly string LETRA_INVALIDO = "Letra inválida.";
        public static readonly string VERDADE_INVALIDO = "Verdade inválida.";
        public static readonly string CONSEQUENCIA_INVALIDO = "Consequência inválida.";
        public static readonly string SEXO_INVALIDO = "Sexo inválido.";
        public static readonly string DESCRICAO_INVALIDA = "Descrição inválida.";
        public static readonly string IDADE_INVALIDA = "Idade inválida.";
        public static readonly string RESULTADO_INVALIDA = "Resultado inválido.";
        public static readonly string NUMERO_INVALIDO = "Número inválido.";
        public static readonly string NUMERO_DUPLICADO = "Número já existe.";
        public static readonly string ESTILO_INVALIDO = "Estilo inválido.";
        public static readonly string STATUS_INVALIDO = "Status inválido.";
        public static readonly string DATA_INICIO_INVALIDA = "Data de início inválida.";
        public static readonly string DATA_TERMINO_INVALIDA = "Data de termino inválida.";
        public static readonly string QUANTIDADE_INVALIDA = "Quantidade Inválida.";
        public static readonly string HORA_INICIO_INVALIDO = "Hora de início inválido.";
        public static readonly string HORA_FIM_INVALIDO = "Hora final inválido.";
        public static readonly string HORA_INICIO_MENOR_HORA_FIM = "Hora inicio menor que a hora fim.";
        public static readonly string ERRO_AO_CADASTRAR_PESSOA = "Erro ao cadastrar pessoa no sistema presença";
        public static readonly string SIGLA_INVALIDA = "Sigla inválida.";
        public static readonly string FILTRO_INVALIDO = "Filtro inválido.";
        public static readonly string ANO_INVALIDO = "Ano inválido.";
        public static readonly string MES_INVALIDO = "Mes inválido.";
        public static readonly string DATA_INVALIDA = "Data inválida.";
        public static readonly string ACAO_NAO_PERMITIDA = "Ação não permitida.";
        public static readonly string PESSOA_INVALIDO = "Pessoa inválida.";
      
        #endregion
        public string ContentType { get; set; } = @"application/json";

        public ApplicationBadRequestException() : base()
        {
        }

        public ApplicationBadRequestException(string message) : base(message) { }

        public ApplicationBadRequestException(string message, params object[] args)
            : base(string.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
        public ApplicationBadRequestException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
