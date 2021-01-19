using System;
using EPlayers_AspNetCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EPlayers_AspNetCore.Controllers
{
    public class JogadorController : Controller
    {
        
        Jogador jogadorModel = new Jogador();
        Equipe equipeModel = new Equipe();

            [Route("Jogador")]
        public IActionResult Index()
        {
            ViewBag.Equipes     = equipeModel.ReadAll();
            ViewBag.Jogadores   = jogadorModel.ReadAll();
            return View();
        }
        
        [Route("Cadastrar")]
        public IActionResult Cadastrar(IFormCollection form)
        {
            Jogador novoJogador     = new Jogador();
            novoJogador.IdJogador   = Int32.Parse(form["IdJogador"]);
            novoJogador.IdJogador   = Int32.Parse(form["IdEquipe"]);
            novoJogador.Nome        = form["Nome"];
            novoJogador.Email       = form["Email"];
            novoJogador.Senha       = form["Senha"];

            jogadorModel.Create(novoJogador);            
            ViewBag.Jogadores = jogadorModel.ReadAll();

            return LocalRedirect("~/Jogador");
        }
    }
}