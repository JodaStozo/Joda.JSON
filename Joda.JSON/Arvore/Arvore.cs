using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Joda.JSON
{
    public class Arvore
    {
        public List<No> Filhos { get; set; }
        public Arvore(string argJSON)
        {
            Filhos = new List<No>();
            string meuJSON = argJSON.Trim();
            if (meuJSON.StartsWith("{"))
            {
                Joda.JSON.ParObj meuNoJSON = new Joda.JSON.ParObj();
                meuNoJSON.Nome = "JSON";
                meuNoJSON.Deserealizar(meuJSON);
                foreach (Joda.JSON.ParBase noLido in meuNoJSON.Valor)
                {
                    No novoNo = new No(noLido, null);
                    this.AddFilho(novoNo);
                    novoNo.PovoarFilhos();
                }
            }
        }
        public void AddFilho(No argNo)
        {
            Filhos.Add(argNo);
        }
        public Joda.JSON.ParBase Pesquisar(string argCaminho)
        {
            JSON.ParBase meuRet = new JSON.ParBase();
            string[] meuSpt = argCaminho.Split('/');
            No noCorrente ;
            List<No> colPesquisa = Filhos;
            foreach (string s in meuSpt)
            {
                noCorrente = NoDeNome(s, colPesquisa);
                if(noCorrente.Filhos.Count > 0)
                {
                    colPesquisa = noCorrente.Filhos;
                }
                meuRet = noCorrente.NoJSON;
            }
            return meuRet;
        }
        private Joda.JSON.No NoDeNome(string argNome, List<JSON.No> argNos)
        {
            No meuRet = new No();
            foreach(No noLido in argNos)
            {
                if(noLido.Nome == argNome)
                {
                    meuRet = noLido;
                    return meuRet;
                }
            }
            return meuRet;
        }
    }
}
