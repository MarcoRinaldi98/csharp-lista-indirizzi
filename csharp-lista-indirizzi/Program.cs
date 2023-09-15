using csharp_lista_indirizzi;

List<Indirizzo> listaIndirizzi = new List<Indirizzo>();

try
{
    // leggo il file che si trova all'indirizzo indicato
    StreamReader fileIndirizzi = File.OpenText("C:\\Users\\Marco\\source\\repos\\csharp-lista-indirizzi\\csharp-lista-indirizzi\\my-addresses.csv");
    
    // variabile per la gestione di ogni riga nel file
    int lineNumber = 0;

    try
    {
        // Se non ha finito di leggere il file
        while (!fileIndirizzi.EndOfStream)
        {
            // leggo riga per riga il file
            string line = fileIndirizzi.ReadLine();
            lineNumber++;

            // inizio a registrare i dati dalla seconda riga
            if (lineNumber > 1)
            {
                try
                {
                    Indirizzo addressReaded = Indirizzo.ParseFromLine(line);
                    listaIndirizzi.Add(addressReaded);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    } catch(Exception ex) 
    {
        Console.WriteLine(ex.Message);
    } finally
    {
        fileIndirizzi.Close();
    }
  
} catch(Exception e)
{
    Console.WriteLine(e.Message);
}

Console.WriteLine(Environment.NewLine);

//creo un nuovo file di nome indirizzi-personalizzati e ci inserisco dentro gli inderizzi modellati
try
{
    StreamWriter fileToWrite = File.CreateText("C:\\Users\\Marco\\source\\repos\\csharp-lista-indirizzi\\csharp-lista-indirizzi\\indirizzi-personalizzati.csv");

    for (int i = 0; i < listaIndirizzi.Count; i++)
    {
        Console.WriteLine($"{i + 1} - {listaIndirizzi[i]}");
        fileToWrite.WriteLine($"{i + 1} - {listaIndirizzi[i]}");
    }
    fileToWrite.Close();
}
catch
{
    Console.WriteLine("C'è stata un'eccezione");
}