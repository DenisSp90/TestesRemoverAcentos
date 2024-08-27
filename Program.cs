using System;
using System.Text;
using System.Globalization;

class Program
{
    static void Main()
    {
        bool continuar = true;

        do
        {
            Console.WriteLine("Digite um texto:");
            string texto = Console.ReadLine();

            Console.WriteLine("Escolha o método para remover acentos:");
            Console.WriteLine("1 - Método RemoverAcentos");
            Console.WriteLine("2 - Método RemoverAcentosV2");
            string escolha = Console.ReadLine();

            string textoSemAcentos = "";

            switch (escolha)
            {
                case "1":
                    textoSemAcentos = RemoverAcentos(texto);
                    break;
                case "2":
                    textoSemAcentos = RemoverAcentosV2(texto);
                    break;
                default:
                    Console.WriteLine("Opção inválida.");
                    continue;
            }

            Console.WriteLine("Texto sem acentos: " + textoSemAcentos);

            Console.WriteLine("Deseja testar outra palavra ou encerrar?");
            Console.WriteLine("1 - Testar outra palavra");
            Console.WriteLine("2 - Encerrar");
            string opcao = Console.ReadLine();

            if (opcao == "2")
            {
                continuar = false;
            }

        } while (continuar);

        Console.WriteLine("Programa encerrado.");
    }

    static string RemoverAcentos(string texto)
    {
        StringBuilder sb = new StringBuilder();
        foreach (char c in texto.Normalize(NormalizationForm.FormD))
        {
            UnicodeCategory uc = CharUnicodeInfo.GetUnicodeCategory(c);
            if (uc != UnicodeCategory.NonSpacingMark)
            {
                sb.Append(c);
            }
        }
        return sb.ToString().Normalize(NormalizationForm.FormC);
    }

    static string RemoverAcentosV2(string texto)
    {
        string rtext = "";
        string acent = "áàâãäéèêëíìîïóòôõöúùûüÁÀÂÃÄÉÈÊËÍÌÎÏÓÒÔÕÖÚÙÛÜçÇ";
        string sacen1 = "aaaaaeeeeiiiiooooouuuuAAAAAEEEEIIIIOOOOOUUUUcC";

        for (int i = 0; i < texto.Length; i++)
        {
            char currentChar = texto[i];
            int index = acent.IndexOf(currentChar);

            if (index != -1)
            {
                rtext += sacen1[index];
            }
            else
            {
                rtext += currentChar;
            }
        }

        return rtext;
    }


}
