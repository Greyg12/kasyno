# Projekt: Kasyno (ConsoleApp12)

Projekt jest prostą aplikacją typu konsolowego, która symuluje kasyno z różnymi grami losowymi. Użytkownik może wpłacać i wypłacać monety na swoje konto, a także grać w gry takie jak: crash, lotto, ruletka oraz rzut monetą.

## Spis treści

1. [Opis projektu](#opis-projektu)
2. [Jak uruchomić](#jak-uruchomić)
3. [Funkcje](#funkcje)
   - [Wplata i wypłata](#wplata-i-wypłata)
   - [Gry](#gry)
     - [Crash](#crash)
     - [Lotto](#lotto)
     - [Ruletka](#ruletka)
     - [Rzut monetą](#rzut-monetą)
4. [Struktura plików](#struktura-plików)
5. [Wymagania](#wymagania)
6. [Licencja](#licencja)

## Opis projektu

Aplikacja kasyna umożliwia użytkownikowi interakcję z różnymi grami losowymi. Program przechowuje dane o stanie konta użytkownika w pliku tekstowym i pozwala na przeprowadzanie gier z obstawianiem monet. W zależności od wyników gier, stan konta jest odpowiednio zmieniany i zapisywany.

### Główne funkcje:
- **Wplata i wypłata monet**: Użytkownik może wpłacać lub wypłacać monety z konta.
- **Gry losowe**: Użytkownik może wybierać gry takie jak crash, lotto, ruletka i rzut monetą.
- **Zarządzanie stanem konta**: Stan konta jest zapisywany i odczytywany z pliku.

## Jak uruchomić

Aby uruchomić projekt:
1. Pobierz lub sklonuj repozytorium.
2. Otwórz projekt w IDE obsługującym C# (np. Visual Studio).
3. Zbuduj i uruchom aplikację.
4. Aplikacja uruchomi się w terminalu/konsoli. Postępuj zgodnie z instrukcjami wyświetlanymi na ekranie.

## Funkcje

### Wplata i wypłata
- **Wplata monet**: Użytkownik może dodać monety do swojego konta.
- **Wypłata monet**: Użytkownik może wypłacić monety z konta, pod warunkiem, że ma wystarczającą ilość na koncie.

### Gry

#### Crash
Gra polega na obstawianiu monet, a celem jest "wyjście" z gry przed upadkiem mnożnika. Użytkownik może nacisnąć Enter, aby zakończyć rozgrywkę, a jeśli to zrobi przed zakończeniem, wygrywa mnożnik pomnożony przez jego stawkę.

#### Lotto
W grze lotto użytkownik obstawia 6 liczb. Jeśli trafi 3 lub więcej liczb, wygrywa. Nagroda zależy od liczby trafionych liczb:
- 3 trafione liczby: 3x stawka
- 4 trafione liczby: 40x stawka
- 5 trafionych liczb: 1500x stawka
- 6 trafionych liczb: 1 000 000x stawka

#### Ruletka
W grze ruletka użytkownik może obstawiać na różne sposoby:
- **Cyfry (0-36)**: Wygrywa, jeśli trafi wylosowaną cyfrę.
- **Kolory**: Użytkownik może obstawić na czarne lub czerwone pole.
- **Zakresy cyfr**: Obstawianie na zakresy: 1-12, 13-24, 25-36, 1-18, 19-36.

#### Rzut monetą
W tej grze użytkownik obstawia, czy padnie orzeł czy reszka. Jeśli jego przewidywanie jest trafne, podwaja stawkę.

## Struktura plików

Projekt posiada następujące struktury i pliki:
- `kasyno.txt` - plik, w którym przechowywany jest stan konta użytkownika.

## Wymagania

Aby uruchomić projekt, musisz mieć zainstalowane:
- Środowisko programistyczne obsługujące C# (np. Visual Studio).
- .NET SDK w wersji 5.0 lub wyższej.

## Licencja

Projekt jest dostępny na licencji MIT.

