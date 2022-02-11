# Joda.JSON

![](https://github.com/JodaStozo/Joda.JSON/blob/7702739635d11989f94df7a321671a6e6098c261/logo114x112.png)

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

Para um conteúdo JSON conforme abaixo, o resultado da pesquisa para o caminho 'statusItem/codigo' é 1. Para o caminho 'codigo' o resultado é 0. E para o caminho 'statusItem/descricao', o resultado é 'Dado obtido com sucesso'.

        {
        	"codigo":0,
        	"statusItem":
        	{
        		"codigo":1,
        		"descricao":"Dado obtido com sucesso"
        	}
        }
        
Para acessar um caminho com conteúdo Array, utilizar índice iniciado por 0, marcado por um síbulo '#'. Assim, para um conteúdo JSON conforme abaixo, o resultado da pesquisa para o caminho 'book/#0/id' será '01'. Para o caminho 'book/#1/language', o resultado será 'C++'.

        {
           "book": [
        
              {
                 "id": "01",
                 "language": "Java",
                 "edition": "third",
                 "author": "Herbert Schildt"
              },
        
              {
                 "id": "07",
                 "language": "C++",
                 "edition": "second",
                 "author": "E.Balagurusamy"
              }
        
           ]
        }
