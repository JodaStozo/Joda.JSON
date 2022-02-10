﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Joda.JSON
{
    public class ParArr : ParBase
    {
        public new ParBase[] Valor;
        public ParArr() { }
        public ParArr(string nome, int tipo)
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
            String compItem = "";
            eCompondo compondo = eCompondo.Nada;
            foreach (Char c in argJSON)
            {
                if (c == '[')
                {
                    switch (compondo)
                    {
                        case eCompondo.Nada:
                            aninhamento++;
                            compondo = eCompondo.Item;
                            continue;
                        case eCompondo.Item:
                            aninhamento++;
                            continue;
                    }
                }
                if (c == '\"')
                {
                    switch (compondo)
                    {
                        case eCompondo.Nada:
                            continue;
                        case eCompondo.Item:
                            compItem += c.ToString();
                            continue;
                    }
                }
                if (c == ',')
                {
                    switch (compondo)
                    {
                        case eCompondo.Nada:
                            continue;
                        case eCompondo.Item:
                            if (aninhamento == 1)
                            {
                                minhaLista.Add(new Joda.JSON.ParBase(string.Format("#{0}", minhaLista.Count), compItem, 0));
                                compItem = "";
                            }
                            else
                            {
                                compItem += c.ToString();
                            }
                            continue;
                    }
                }
                if (c == ']')
                {
                    switch (compondo)
                    {
                        case eCompondo.Nada:
                            aninhamento--;
                            continue;
                        case eCompondo.Item:
                            if (aninhamento == 1)
                            {
                                minhaLista.Add(new Joda.JSON.ParBase(string.Format("#{0}", minhaLista.Count), compItem, 0));
                                compItem = "";
                            }
                            else
                            {
                                compItem += c.ToString();
                            }
                            aninhamento--;
                            continue;
                    }
                }
                if (c == '{')
                {
                    switch (compondo)
                    {
                        case eCompondo.Nada:
                            continue;
                        case eCompondo.Item:
                            compItem += c.ToString();
                            aninhamento++;
                            continue;
                    }
                }
                if (c == '}')
                {
                    switch (compondo)
                    {
                        case eCompondo.Nada:
                            continue;
                        case eCompondo.Item:
                            compItem += c.ToString();
                            aninhamento--;
                            continue;
                    }
                }
                switch (compondo)
                {
                    case eCompondo.Nada:
                        continue;
                    case eCompondo.Item:
                        compItem += c.ToString();
                        continue;
                }
            }
            this.Valor = minhaLista.ToArray();
        }
        private enum eCompondo
        {
            Nada, Item
        }
    }

}