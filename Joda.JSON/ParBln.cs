using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Joda.JSON
{
    public class ParBln : ParBase
    {
        //public new Boolean Valor;
        public ParBln() { }
        public ParBln(string nome, int tipo)
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
            if (argJSON.Trim().ToLower() == "true" | argJSON.Trim().ToLower() == "false")
            {
                Valor = Boolean.Parse(argJSON.Trim());
            }
            Tipo = 3;
        }
    }
}
