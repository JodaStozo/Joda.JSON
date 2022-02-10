# Joda.JSON

![](https://github.com/JodaStozo/Joda.JSON/blob/79570f0ecda2f84f649d559ff08945a899aef682/cropped-logo256x256FundoTransp-1.png)

Interpretação de JSON para C# e VB .NET. Converte o JSON em uma árvore hierárquica, tornando possível consultar os valores pelo seu 'Caminho' (p.e. raiz/noPrimario/.../noFinal). 
Exemplo de Uso:

        private object Pesquisar(string conteudoJSON, string noCaminho)
        {
            Joda.JSON.Arvore minhArvore;
            minhArvore = new Joda.JSON.Arvore(conteudoJSON);
            Joda.JSON.ParBase achei = minhArvore.Pesquisar(noCaminho);
            if (achei != null)
            {
                return achei.Valor;
            } else
            {
                return = "Caminho não localizado!";
            }
        }
