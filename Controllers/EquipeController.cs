using System;
using EPlayers_AspNetCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EPlayers_AspNetCore.Interfaces
{

    [Route("Equipe")]
    //http://localhost:5000/Equipe
    public class EquipeController : Controller
    {
        //Criamos uma intância de equipeModel
        Equipe equipeModel = new Equipe ();
        
        [Route("Listar")]
        public IActionResult index()
        {
            //Listamos todas as equipe e enviamos para a View, através da ViewBag
            ViewBag.Equipes = equipeModel.ReadAll();
            return View();
        }


        [Route("Cadastrar")]
        public IActionResult Cadastrar(IFormCollection form)
        {
            Equipe novaEquipe = new Equipe ();
            novaEquipe.IdEquipe =Int32.Parse( form["IdEquipe"] );
            novaEquipe.Nome = form["Nome"];
            novaEquipe.Nome = form["Imagem"];

            //Chamamos o método Create para salvar a novaEquipe no csv
            equipeModel.Create(novaEquipe);
            //Atualiza a lista de equipes na View
            ViewBag.Equipes = equipeModel.ReadAll();

            return LocalRedirect("~/Equipe/Listar");
        }


    }
}