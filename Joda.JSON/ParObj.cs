using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Joda.JSON
{
    public class ParObj : ParBase
    {
        public new ParBase[] Valor;
        public ParObj() { }
        public ParObj(string nome, int tipo)
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
            int aninhamento = 0;
            List<ParBase> minhaLista = new List<ParBase>();
            String compNome = "";
            String compValor = "";
            eCompondo compondo = eCompondo.Nada;
            foreach (Char c in argJSON)
            {
                if (c == '{' | c == '[')
                {
                    switch (compondo)
                    {
                        case eCompondo.Nada:
                            aninhamento++;
                            continue;
                        case eCompondo.Nome:
                            continue;
                        case eCompondo.Valor:
                            compValor += c.ToString();
                            aninhamento++;
                            continue;
                    }
                }
                if (c == '\"')
                {
                    switch (compondo)
                    {
                        case eCompondo.Nada:
                            compondo = eCompondo.Nome;
                            continue;
                        case eCompondo.Nome:
                            compondo = eCompondo.Nada;
                            continue;
                        case eCompondo.Valor:
                            compValor += c.ToString();
                            continue;
                    }
                }
                if (c == ',')
                {
                    switch (compondo)
                    {
                        case eCompondo.Nada:
                            continue;
                        case eCompondo.Nome:
                            continue;
                        case eCompondo.Valor:
                            if (aninhamento == 1)
                            {
                                minhaLista.Add(new ParBase(compNome, compValor, 0));
                                compondo = eCompondo.Nada;
                                compNome = "";
                                compValor = "";
                            }
                            else
                            {
                                compValor += c.ToString();
                            }
                            continue;
                    }
                }
                if (c == '}' | c == ']')
                {
                    switch (compondo)
                    {
                        case eCompondo.Nada:
                            aninhamento--;
                            continue;
                        case eCompondo.Nome:
                            continue;
                        case eCompondo.Valor:
                            if (aninhamento == 1)
                            {
                                minhaLista.Add(new ParBase(compNome, compValor, 0));
                                compondo = eCompondo.Nada;
                                compNome = "";
                                compValor = "";
                            }
                            else
                            {
                                compValor += c.ToString();
                            }
                            aninhamento--;
                            continue;
                    }
                }
                if (c == ':')
                {
                    switch (compondo)
                    {
                        case eCompondo.Nada:
                            compondo = eCompondo.Valor;
                            continue;
                        case eCompondo.Nome:
                            continue;
                        case eCompondo.Valor:
                            compValor += c.ToString();
                            continue;
                    }
                }
                switch (compondo)
                {
                    case eCompondo.Nada:
                        continue;
                    case eCompondo.Nome:
                        compNome += c.ToString();
                        continue;
                    case eCompondo.Valor:
                        compValor += c.ToString();
                        continue;
                }
            }
            this.Valor = minhaLista.ToArray();
        }
        private enum eCompondo
        {
            Nada, Nome, Valor
        }
    }

}
