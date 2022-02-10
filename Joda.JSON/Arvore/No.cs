using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Joda.JSON
{
    public class No
    {
        public string Nome { get; set; }
        public List<No> Filhos { get; set; }
        public No Pai { get; set; }
        public Joda.JSON.ParBase NoJSON { get; set; }
        public No(Joda.JSON.ParBase argNoJSON, No argPai)
        {
            Nome = argNoJSON.Nome;
            NoJSON = argNoJSON;
            Pai = argPai;
            Filhos = new List<No>();
        }
        public No()
        {
            //Pai = new No();
            Filhos = new List<No>();
        }
        public void AddFilho(No argNo)
        {
            Filhos.Add(argNo);
        }
        public void LimparFilhos()
        {
            Filhos.Clear();
        }public void PovoarFilhos()
        {
            string meuJSON = NoJSON.Valor.Trim();
            if (meuJSON.StartsWith("{"))
            {
                Joda.JSON.ParObj meuNoJSON = new Joda.JSON.ParObj();
                meuNoJSON.Nome = NoJSON.Nome;
                meuNoJSON.Deserealizar(meuJSON);
                foreach(Joda.JSON.ParBase noLido in meuNoJSON.Valor)
                {
                    No novoNo = new No(noLido, this);
                    this.AddFilho(novoNo);
                    novoNo.PovoarFilhos();
                }
            }
            if (meuJSON.StartsWith("["))
            {
                Joda.JSON.ParArr meuNoJSON = new Joda.JSON.ParArr();
                meuNoJSON.Nome = NoJSON.Nome;
                meuNoJSON.Deserealizar(meuJSON);
                foreach (Joda.JSON.ParBase noLido in meuNoJSON.Valor)
                {
                    No novoNo = new No(noLido, this);
                    this.AddFilho(novoNo);
                    novoNo.PovoarFilhos();
                }
            }
            if (meuJSON.StartsWith("\""))
            {
                Joda.JSON.ParStr meuNoJSON = new Joda.JSON.ParStr();
                meuNoJSON.Nome = NoJSON.Nome;
                meuNoJSON.Deserealizar(meuJSON);
                this.NoJSON = meuNoJSON;
            }
            if (IsNumeric(meuJSON))
            {
                Joda.JSON.ParNro meuNoJSON = new Joda.JSON.ParNro();
                meuNoJSON.Nome = NoJSON.Nome;
                meuNoJSON.Deserealizar(meuJSON);
                this.NoJSON = meuNoJSON;
            }
            if(meuJSON == "true" | meuJSON == "fase")
            {
                Joda.JSON.ParBln meuNoJSON = new Joda.JSON.ParBln();
                meuNoJSON.Nome = NoJSON.Nome;
                meuNoJSON.Deserealizar(meuJSON);
                this.NoJSON = meuNoJSON;
            }
            if (meuJSON == "null" )
            {
                Joda.JSON.ParNul meuNoJSON = new Joda.JSON.ParNul();
                meuNoJSON.Nome = NoJSON.Nome;
                meuNoJSON.Deserealizar(meuJSON);
                this.NoJSON = meuNoJSON;
            }
        }

        public bool IsNumeric(string value)
        {
            return value.All(char.IsNumber);
        }
    }
}
