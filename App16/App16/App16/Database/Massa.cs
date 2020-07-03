using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Realms;
using App16.Models;

namespace App16.Database
{
    public class Massa
    {
        public static void CriarMassaDados()
        {
            var realm = Realm.GetInstance();

            var count = realm.All<Profissional>().Count();

            if( count == 0) { 

                realm.Write(()=> {
                    for(int i = 0; i < 20; i++)
                    {
                        Profissional prof = new Profissional() { Nome = "Prof "+i, Descricao = "Descri " + i, Especialidade = "Especialidade " + i, Img = "http://designinspirador.com.br/wp-content/uploads/2017/02/imagem-de-perfil-1.jpg" };

                        realm.Add<Profissional>(prof);

                        for (int j = 0; j < 3; j++)
                        {
                            Comentario coment = new Comentario() { profissional = prof, Autor = string.Format("Autor {0} {1}", i, j), Data = DateTimeOffset.Now, Descricao = string.Format("Descricao {0} {1}", i, j) };

                            realm.Add<Comentario>(coment);
                        }
                    }

                });

            }
        }
    }
}
