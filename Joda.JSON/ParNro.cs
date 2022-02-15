using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Joda.JSON
{
    public class ParNro : ParBase
    {
        //public new long Valor;
        public ParNro() { }
        public ParNro(string nome, int tipo)
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
            if (IsNumeric(argJSON.Trim()))
            {
                if(argJSON.Trim() != string.Empty)
                {
                    Valor = long.Parse(argJSON.Trim());
                }
            }
            Tipo = 1;
        }
        public bool IsNumeric(string value)
        {
            return value.All(char.IsNumber);
        }
    }

}
