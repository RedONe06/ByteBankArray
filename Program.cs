Console.WriteLine("Boas Vindas ao ByteBank, Atendimento.");

int[] idades = { 30, 40, 17, 21, 18 };
int acumulador = 0;

// Array de int
// TestaArrayInt();

int media = acumulador / idades.Length;
Console.WriteLine($"Média de idades = {media}");

// Array de string
// TestaBuscarPalavra();

// Arrays
Array amostra = Array.CreateInstance(typeof(double), 5);
amostra.SetValue(5.9, 0);
amostra.SetValue(1.8, 1);
amostra.SetValue(7.1, 2);
amostra.SetValue(10, 3);
amostra.SetValue(6.9, 4);

// TestaMediana(amostra);

// Métodos
void TestaArrayInt()
{
    
    Console.WriteLine($"Tamanho do Array = {idades.Length}");

    int index = 0;
    foreach (int idade in idades)
    {
        Console.WriteLine($"índice [{index}] = {idade}");
        index++;
        acumulador += idade;
    }

}

void TestaBuscarPalavra()
{
    string[] arrayDePalavras = new string[5];

    for (int i = 0; i < arrayDePalavras.Length; i++)
    {
        Console.Write($"Digite {i + 1}ª Palavra: ");
        arrayDePalavras[i] = Console.ReadLine();
    }

    Console.Write("Digite palavra a ser encontrada: ");
    var busca = Console.ReadLine();

    foreach (string palavra in arrayDePalavras)
    {
        if (palavra.Equals(busca))
        {
            Console.WriteLine($"Palavra encontrada = {busca}.");
        } else
        {
            Console.WriteLine($"Palavra não encontrada.");
        }
    }
}

void TestaMediana(Array array)
{
    if ((array == null) || (array.Length == 0))
        Console.WriteLine("Array para cálculo da mediana está vazio ou nulo.");
    

    double[] numerosOrdenados = (double [])array.Clone();
    Array.Sort(numerosOrdenados);

    int tamanho = numerosOrdenados.Length;
    int meio = tamanho / 2;
    double mediana = (tamanho % 2 != 0) ?
        numerosOrdenados[meio] : (numerosOrdenados[meio] + numerosOrdenados[meio - 1]) / 2;

    Console.WriteLine($"Com base na amostra a mediana = {mediana}");
}