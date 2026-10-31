# 📄 CvGeneratorAvalonia

**CvGeneratorAvalonia** to wieloplatformowa, desktopowa aplikacja przeznaczona do szybkiego generowania eleganckich dokumentów CV w formacie PDF na podstawie danych w formacie JSON. 

Aplikacja została zbudowana przy użyciu nowoczenych technologii **.NET**, **Avalonia UI** (interfejs użytkownika) oraz silnika **QuestPDF** (precyzyjne generowanie dokumentów PDF).

---

## 🚀 Jak pobrać i uruchomić program?

Nie musisz instalować środowiska .NET ani kompilować kodu źródłowego – program dystrybuowany jest w gotowych wersjach dla systemów **Windows** oraz **macOS**.

---

### 🪟 Instrukcja dla Windows (64-bit)

1. Pobierz archiwum ZIP dedykowane dla systemu Windows (np. `CvGeneratorAvalonia-win-x64.zip`).
2. Rozpakuj zawartość archiwum w dowolnym folderze (np. na Pulpicie).
3. Uruchom plik **`CvGeneratorAvalonia.exe`** klikając go dwukrotnie.
4. Program uruchomi się jako czysta aplikacja okienkowa.

> 💡 **Uwaga:** Jeśli Windows Defender lub filtr SmartScreen wyświetli komunikat o nieznanym wydawcy, kliknij **Więcej informacji** (More info), a następnie **Uruchom mimo to** (Run anyway).

---

### 🍎 Instrukcja dla macOS (Apple Silicon M1/M2/M3/M4)

1. Pobierz archiwum ZIP dedykowane dla systemu macOS (np. `CvGeneratorAvalonia-osx-arm64.zip`).
2. Rozpakuj zawartość archiwum w wybranym miejscu.
3. W wyciągniętym folderze znajdują się pliki wykonywalne oraz biblioteka natywna `CvGeneratorAvalonia.dylib` – **nie usuwaj ani nie przenoś tej biblioteki**, musi leżeć bezpośrednio obok głównego pliku!

#### Nadanie uprawnień uruchamiania (Gatekeeper)
Ponieważ aplikacja pobrana jest z zewnętrznego źródła, system macOS domyślnie blokuje pliki wykonywalne pochodzące z innych systemów. Aby nadać uprawnienia:

1. Otwórz **Terminal** na swoim Macu.
2. Przejdź do folderu z rozpakowaną aplikacją za pomocą komendy `cd`:
   ```bash
   cd /ścieżka/do/rozpakowanego/folderu