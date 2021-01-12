using System.Collections.Generic;
using System.IO;

namespace EPlayers_AspNetCore.Models
{
    public class EplayersBase
    {
        

        public void CreateFolderAndFile (string _path)
        {
            // Database/Equipe.csv
            string folder = _path.Split("/")[0];
            //string file = _path.Split("/")[1];

            if(!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }

            if(!File.Exists(_path))      
            {
                File.Create (_path);
            }

        }
        
        public List<string> ReadAllLinesCSV(string path)
        {
            
            List<string> linhas = new List<string>();

            //Using - > responsável por abrir e fecha o arquivo automaticamente
            //StreamRaader - > Ler dqados de um arquivo
            using(StreamReader file = new StreamReader(path))
            {
                string linha;

                // Percorrer as linhas com um laço while
                while((linha = file.ReadLine()) != null)
                {
                    linhas.Add(linha);
                }
            }

            return linhas;



        }

        public void RewriteCSV(string path, List<string> linhas)
        {

            // StreamWriter -> Escrever dafps em um arquivo
            using (StreamWriter output = new StreamWriter(path))
            {

                foreach ( var item in linhas)
                {
                    output.Write(item + '\n');
                }


            }

        }


    }
}