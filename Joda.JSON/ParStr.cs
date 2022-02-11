using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Joda.JSON
{
    public class ParStr : ParBase
    {
        public ParStr() { }
        public ParStr(string nome, int tipo)
        {
            Nome = nome;
            Tipo = tipo;
        }
        public override string Serealizar()
        {
            return base.Serealizar();
        }
        public override void Deserealizar(string argJSON)
        {
            base.Deserealizar(argJSON);
            Valor = argJSON.Trim();
            Valor = Valor.ToString().Substring(1);
            Valor = Valor.ToString().Substring(0, Valor.ToString().Length - 1);
            Tipo = 2;
        }
    }
}
