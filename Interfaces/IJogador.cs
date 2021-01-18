using System.Collections.Generic;
using EPlayers_AspNetCore.Models;

namespace EPlayers_AspNetCore.Interfaces
{
    public interface IJogador
    {
          //Criar
        void Create(Jogador j);
        //Ler
        List<Jogador> ReadAll();
        //Alterar
        void Update(Jogador j);
        //Excluir
        void Delete(int id);  
    }
}