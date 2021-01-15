namespace EPlayers_AspNetCore.Models
{
    public class Jogador
    {
        public int IdJogador { get; set;}
        public string Nome { get; set;}
        public int IdEquipe {get; set;}
        //Login
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}