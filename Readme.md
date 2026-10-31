📄 CvGeneratorAvalonia

CvGeneratorAvalonia to wieloplatformowa, desktopowa aplikacja przeznaczona do szybkiego generowania eleganckich dokumentów CV w formacie PDF na podstawie danych w formacie JSON.

Aplikacja została zbudowana przy użyciu nowoczesnych technologii .NET, Avalonia UI (interfejs użytkownika) oraz silnika QuestPDF (precyzyjne generowanie dokumentów PDF).

🚀 Jak pobrać i uruchomić program?

Nie musisz instalować środowiska .NET ani kompilować kodu źródłowego – program dystrybuowany jest w gotowych wersjach dla systemów Windows oraz macOS.

🪟 Instrukcja dla Windows (64-bit)

Pobierz archiwum ZIP dedykowane dla systemu Windows (np. CvGeneratorAvalonia-win-x64.zip).

Rozpakuj zawartość archiwum w dowolnym folderze (np. na Pulpicie).

Upewnij się, że plik cv_data.json znajduje się w tym samym folderze co plik wykonywalny.

Uruchom plik CvGeneratorAvalonia.exe klikając go dwukrotnie.

Program uruchomi się jako czysta aplikacja okienkowa.

💡 Uwaga: Jeśli Windows Defender lub filtr SmartScreen wyświetli komunikat o nieznanym wydawcy, kliknij Więcej informacji (More info), a następnie Uruchom mimo to (Run anyway).

🍎 Instrukcja dla macOS (Apple Silicon M1/M2/M3/M4)

Pobierz archiwum ZIP dedykowane dla systemu macOS (np. CvGeneratorAvalonia-osx-arm64.zip).

Rozpakuj zawartość archiwum w wybranym miejscu.

W wyciągniętym folderze znajdują się pliki wykonywalne oraz biblioteka natywna CvGeneratorAvalonia.dylib – nie usuwaj ani nie przenoś tej biblioteki, musi leżeć bezpośrednio obok głównego pliku!

Upewnij się, że plik cv_data.json znajduje się w tym samym folderze.

Nadanie uprawnień uruchamiania (Gatekeeper)

Ponieważ aplikacja pobrana jest z zewnętrznego źródła, system macOS domyślnie blokuje pliki wykonywalne pochodzące z innych systemów. Aby nadać uprawnienia:

Otwórz Terminal na swoim Macu.

Przejdź do folderu z rozpakowaną aplikacją za pomocą komendy cd:

cd /ścieżka/do/rozpakowanego/folderu


Nadaj uprawnienie do wykonywania pliku:

chmod +x CvGeneratorAvalonia


Uruchom aplikację klikając dwukrotnie plik CvGeneratorAvalonia lub wywołując go w Terminalu:

./CvGeneratorAvalonia


💡 Rozwiązywanie problemów z blokadą macOS: Jeśli system wyświetli komunikat "Aplikacja od nieznanego dewelopera" lub "Nie można otworzyć programu", wejdź w Ustawienia systemowe -> Prywatność i bezpieczeństwo (Privacy & Security), przewiń na sam dół i kliknij przycisk Otwórz mimo to (Open Anyway).

📋 Przykładowy format pliku cv_data.json

Aplikacja oczekuje pliku cv_data.json w głównym katalogu programu. Poniżej znajduje się wzorcowa struktura danych, którą możesz dostosować do własnych potrzeb:

{
  "FullName": "Jan Kowalski",
  "JobTitle": "Senior C# / .NET Developer",
  "Contact": {
    "Email": "jan.kowalski@example.com",
    "Phone": "+48 123 456 789",
    "City": "Warszawa",
    "LinkedIn": "linkedin.com/in/jankowalski",
    "GitHub": "github.com/jankowalski"
  },
  "Summary": "Doświadczony programista .NET z ponad 5-letnim stażem w tworzeniu aplikacji desktopowych i chmurowych. Pasjonat czystego kodu oraz wydajnych architektur oprogramowania.",
  "Skills": [
    "C# / .NET 10",
    "Avalonia UI / WPF",
    "QuestPDF",
    "REST API / ASP.NET Core",
    "Git / CI/CD"
  ],
  "Experience": [
    {
      "Company": "Tech Solutions Sp. z o.o.",
      "Position": "Senior .NET Developer",
      "Period": "2021 - obecnie",
      "Description": "Projektowanie i rozwój architektury aplikacji desktopowych z użyciem Avalonia UI. Integracja z systemami zewnętrznymi oraz optymalizacja procesów generowania raportów."
    },
    {
      "Company": "Software House Inc.",
      "Position": "C# Developer",
      "Period": "2019 - 2021",
      "Description": "Tworzenie mikroserwisów w ASP.NET Core oraz rozbudowa aplikacji klienckich w technologii WPF."
    }
  ],
  "Education": [
    {
      "Institution": "Politechnika Warszawska",
      "Degree": "Inżynier Informatyki",
      "Period": "2015 - 2019"
    }
  ],
  "Languages": [
    "Polski (Oczojczysty)",
    "Angielski (C1 - Zaawansowany)"
  ]
}


🛠️ Jak korzystać z aplikacji?

Umieść poprawnie sformatowany plik cv_data.json w folderze aplikacji.

Po uruchomieniu program automatycznie wczytuje dane z pliku cv_data.json.

Po wygenerowaniu pliku PDF, gotowy plik moje_cv.pdf zostanie zapisany w folderze roboczym aplikacji.

⚙️ Wymagania i technologie

Framework: .NET 10.0 (Aplikacja typu Self-Contained – nie wymaga wcześniejszej instalacji runtime .NET).

UI Framework: Avalonia UI (silnik SkiaSharp).

PDF Engine: QuestPDF.

Architektury: Windows x64, macOS ARM64 (Apple Silicon).