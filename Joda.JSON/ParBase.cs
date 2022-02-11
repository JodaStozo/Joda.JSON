using System;
using System.Collections.Generic;

namespace Joda.JSON
{
    public class ParBase
    {
        public string Nome { get; set; }
        public object Valor { get; set; }
        public int Tipo { get; set; }
        public ParBase() { }
        public ParBase(string nome, string valor, int tipo)
        {
            Nome = nome;
            Valor = valor;
            Tipo = tipo;
        }
        public virtual String Serealizar()
        {
            return string.Format("{0}: {1}", Nome, Valor);
        }
        public virtual void Deserealizar(String argJSON)
        {
        }
    }
}
