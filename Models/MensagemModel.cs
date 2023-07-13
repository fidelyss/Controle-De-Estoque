using Newtonsoft.Json;

namespace Estoque.Models
{
    public enum TipoMensagem
    {
        Informacao,
        Erro
    }

    public class MensagemModel
    {
        public TipoMensagem Tipo { get; set; }
        public string Texto { get; set; }
        public MensagemModel(string mensagem, TipoMensagem tipo = TipoMensagem.Informacao)
        {
            this.Tipo = tipo;
            this.Texto = mensagem;
        }

        public static string Serializar(string mensagem, TipoMensagem tipo = TipoMensagem.Informacao) => JsonConvert.SerializeObject(new MensagemModel(mensagem, tipo));

        public static MensagemModel Desserializar(string mensagemString) =>
        JsonConvert.DeserializeObject<MensagemModel>(mensagemString) ?? new MensagemModel("",TipoMensagem.Erro);
    }
}