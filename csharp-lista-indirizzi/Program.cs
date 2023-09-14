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
                string[] stringSplits = line.Split(',');

                if (stringSplits.Length != 6)
                {
                    Console.WriteLine($"L'indirizzo ({line}) non è leggibile!");
                }
                else
                {
                    //definisco una variabile che ad ogni elemento valido aumenterà
                    int counter = 1;
                    // definisco una variabile booleana che se il counter arrivera a 6 indicherà che la linea letta è valida all'inserimento dati
                    bool lineaValida = false;
                    for (int i = 0; i < stringSplits.Length; i++)
                    {
                        if (stringSplits[i].Length > 0)
                        {
                            counter++;
                        }
                        if(counter == 6)
                        {
                            lineaValida = true;
                        }
                    }
                    if (lineaValida)
                    {
                        string nome = stringSplits[0];
                        string cognome = stringSplits[1];
                        string via = stringSplits[2];
                        string citta = stringSplits[3];
                        string provincia = stringSplits[4];
                        int zip = int.Parse(stringSplits[5]);

                        Console.WriteLine($"Indirizzo di {nome} {cognome}: {via}, {citta}, {provincia}, {zip};");

                        Indirizzo nuovoIndirizzo = new Indirizzo(nome, cognome, via, citta, provincia, zip);
                        listaIndirizzi.Add(nuovoIndirizzo);
                    } else
                    {
                        Console.WriteLine($"L'indirizzo ({line}) contiene valori non validi!");
                    }
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
    // ogni volta bisogna chiudere il file dopo l'utilizzo
    fileIndirizzi.Close();
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