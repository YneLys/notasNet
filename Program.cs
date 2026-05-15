using System;
using System.Net.Http.Headers;
using System.Security.Cryptography;

class Program
{
    static void Main()
    {
         double [] notas = new double[4];

         PreencherNotas(notas);
         MostrarNotas(notas);

    double media = CalcularMedia(notas);
    
    Console.WriteLine($"Média: {media}");

    VerificarSituacao(media);
     }

static void PreencherNotas(double[] notas)
{
    for (int i = 0; i < notas.Length; i++)
    {
        Console.Write($"Digite a nota {i + 1}: ");
        double.TryParse(Console.ReadLine(), out notas[i]);
    }
}

static void MostrarNotas(double[] notas)
{
    Console.WriteLine("\nNotas do aluno: ");
    for (int i = 0; i < notas.Length; i++)
    {
        Console.WriteLine($"Nota {i + 1}: {notas[i]}");
    }
}

static double CalcularMedia(double[] notas)
{
    double soma = 0;
    for (int i = 0; i < notas.Length; i++)
    {
        soma += notas[i];
    }
    return soma / notas.Length;
}

static void VerificarSituacao(double media)
{
    if (media >= 7)
    {
        Console.WriteLine("Situação: Aprovado");
    }
    else
    {
        Console.WriteLine("Situação: Reprovado");
    }
}
}