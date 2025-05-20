#  Ingatlan API

Egy egyszerű REST API Node.js + Express környezetben, amely ingatlanok kezelésére szolgál MySQL adatbázissal.

---

## Könyvtárak telepítése és futtatás

```bash
npm init -y
npm install express mysql2
```
```bash
node main.js
```
---

## Végpopntok
GET 
```bash
 http://localhost:3000/api/ingatlan
```
POST 
```bash
http://localhost:3000/api/ujingatlan
```

```bash
{
  "kategoria": 1,
  "elado": 1,
  "leiras": "Eladó tágas ház a hegyvidéken.",
  "hirdetesDatuma": "2025-05-16",
  "tehermentes": true,
  "kepUrl": "https://pictures.com/haz.jpg",
  "terulet": 120,
  "szobak": 4,
  "emeletek": 2,
  "koordinatak": "47.1234,19.5678"
}
```

DELETE 
```bash
 http://localhost:3000/api/ingatlan/71
```
