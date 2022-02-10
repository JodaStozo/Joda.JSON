using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Joda.JSON
{
    public class ParNul : ParBase
    {
        public new String Valor;
        public ParNul() { }
        public ParNul(string nome, int tipo)
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
            if (argJSON.Trim().ToLower() == "null")
            {
                Valor = null;
            }
            Tipo = 8;
        }
    }

}
