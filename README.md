### Projektni zadatak iz predmeta Zaštita informacija

Ovaj projekat predstavlja desktop aplikaciju razvijenu u `.NET 10 (Windows Forms)` tehnologiji, namenjenu za enkripciju, dekripciju i prenos fajlova. Aplikacija implementira kriptografske algoritme i omogućava automatizaciju procesa kroz nadgledanje direktorijuma, kao i mrežni prenos podataka putem TCP soketa.

### Ključne funkcionalnosti

1.  **Manuelna enkripcija i dekripcija:**
    *   Korisnik može izabrati bilo koji fajl, definisati ključ (lozinku) i izabrati željeni algoritam za šifrovanje i heširanje.
    *   Sistem automatski generiše zaglavlje sa metapodacima (JSON format) koje je neophodno za kasniju dekripciju.

2.  **File System Watcher (FSW):**
    *   Automatizovana usluga koja nadgleda specifičan ulazni direktorijum.
    *   Čim se detektuje novi fajl, on se automatski enkriptuje korišćenjem unapred definisanih parametara i prebacuje u izlazni direktorijum.

3.  **Mrežni servis (TCP Transfer):**
    *   Omogućava slanje enkriptovanih fajlova direktno drugoj instanci aplikacije preko mreže.
    *   Implementiran je asinhroni `TcpListener` koji može da prima više fajlova istovremeno.
    *   Automatska dekripcija po prijemu fajla na strani primaoca.

4.  **Logovanje:**
    *   Detaljno praćenje svih akcija unutar aplikacije (informacije, upozorenja i greške).
    *   Logovi se prikazuju u realnom vremenu u UI-u i trajno čuvaju u `.log` fajlovima.

### Implementirani algoritmi

*   **Simetrični koderi bloka (Ciphers):**
    *   **TEA** (Tiny Encryption Algorithm)
    *   **LEA** (Lightweight Encryption Algorithm) - varijante od 128, 192 i 256 bita.
    *   **CTR Mode:** Mogućnost korišćenja algoritama u Counter modu, odnosno kao koder toka.
*   **Heš algoritmi (Hashes):**
    *   **SHA-256** (korišćen i za derivaciju ključa iz lozinke)
    *   **SHA-512**

### Struktura projekta

*   `CryptoAlgorithms`: Biblioteka klasa koja sadrži čiste implementacije kriptografskih algoritama.
*   `CryptoFileSystem`: Logika za manipulaciju fajlovima, rad sa `.enc` formatom i upravljanje zaglavljima (headers).
*   `CryptoApp`: Glavna Windows Forms aplikacija koja integriše sve servise i pruža korisnički interfejs.

### Protokol prenosa podataka

Aplikacija koristi specifičan mrežni protokol za slanje fajlova:
1.  **Dužina imena** (4 bajta)
2.  **Ime fajla** (UTF-8 string)
3.  **Veličina sadržaja** (8 bajta)
4.  **Binarni sadržaj** enkriptovanog fajla (uključujući zaglavlje i padding)

### Kako pokrenuti projekat

1.  Otvorite rešenje u **Visual Studio** ili **JetBrains Rider**.
2.  Uverite se da imate instaliran **.NET 10 SDK**.
3.  Pokrenite `CryptoApp` projekat.
4.  Za demonstraciju mrežnog prenosa, pokrenite dve instance aplikacije (može i na istoj mašini koristeći različite portove i `127.0.0.1`).

---
**Autor:** Veljko Tošić
