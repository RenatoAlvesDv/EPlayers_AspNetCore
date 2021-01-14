using System;
using System.IO;
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
        
            // Upload início
            //Verificamos se o usurário selecinou um arquivo
            if (form.Files.Count > 0)
            {
                //Recebemos o arquivo que o usuário enviou e armazenamos na variável file
                var file = form.Files[0];
                var folder = Path.Combine( Directory.GetCurrentDirectory(), "wwwroot/img/Equipes");

                //Verificamos se o diretório (pasta) já existe
                // se não, a criamos
                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }
                                        // locahost:5001                            Equipes     imagem.jpg
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot//", folder, file.FileName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                
                novaEquipe.Imagem = file.FileName;
            }
            else
            {
                novaEquipe.Imagem = "padrao.png";
            }




            // Upload Final

            // Chamamos o método Create para salvar a mnovaEquipe no csv
            equipeModel.Create(novaEquipe);
            // Atualiza a lista de equipes na View
            ViewBag.Equipes = equipeModel.ReadAll();

            return LocalRedirect("~/Equipe/Listar");
        }

           // http://localhost:5000/Equipe/1
        [Route("{id}")]
        public IActionResult Excluir(int id)
        {
            equipeModel.Delete(id);
	        ViewBag.Equipes = equipeModel.ReadAll();
            return LocalRedirect("~/Equipe/Listar");
        }
          
    }
}