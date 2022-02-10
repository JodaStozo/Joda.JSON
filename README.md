# Joda.JSON
Interpretação de JSON para C# e VB .NET. Converte o JSON em uma árvore hierárquica, tornando possível consultar os valores pelo seu 'Caminho' (p.e. raiz/noPrimario/.../noFinal)
Exemple de Uso:

        private object Pesquisar(string conteudoJSON, string noCaminho)
        {
            Arvore minhArvore;
            minhArvore = new JSON.Arvore(conteudoJSON);
            JSON.ParBase achei = minhArvore.Pesquisar(noCaminho);
            if (achei != null)
            {
                return achei.Valor;
            } else
            {
                return = "Caminho não localizado!";
            }
        }
