# AscomSWEngineerTest2

# Descrizione

il progetto prevede una pagina di login iniziale che gestisce l'autenticazione degli utenti attraverso un form, per poi atterrare, una volta autorizzati, ad una schermata con la lista dei pazienti, cliccabili singolarmente.

# Tecnologie

Il progetto è stato realizzato in C# utilizzando il pattern architetturale MVC e .Net 6, includento EntityFramework.
Come Database è stato scelto di usare SQLite con la versione In-Memory, in modo tale da mantenere il DB in locale (file: "LocalDatabase.db" nella root).

# Pacchetti NuGet

I pacchetti NuGet utilizzati sono i seguenti:

- Grid.Mvc - per l'implementazione della griglia filtrabile
- Hangfire, Hangfire.MemoryStorage - per la schedulazione dei processi di inserimento e cancellazione automatica dei pazienti
- Microsoft.AspNetCore.Authentication - per gestire l'autenticazione per effettuare le varie requests
- Sqlite, Microsoft.Data.Sqlite.Core - Database
- Micorsoft.EntityFrameworkCore, Micorsoft.EntityFrameworkCore.Design, Micorsoft.EntityFrameworkCore.Sqlite, Micorsoft.EntityFrameworkCore.Tools - Per utilizzare EntityFramework
- NonFactors.Grid.Mvc6 - Pacchetto aggiuntivo per lo sviluppo delle griglie


