# WinForms és MySQL adatbázis alkalmazás

Ez a WinForms alkalmazás MySQL adatbázishoz kapcsolódik, és ingatlanhirdetésekkel kapcsolatos adatokat kezel. A program beolvassa az `ingatlanok` adatbázisból az `sellers` (eladók) táblát, megjeleníti a neveket egy listában, majd az adott eladó kiválasztása után részletes információt jelenít meg, valamint lekérdezi, hány ingatlanhirdetés kapcsolódik az eladóhoz.

---

## Szükséges NuGet csomagok

A projekt futtatásához telepíteni kell a következő NuGet csomagot:

```bash 
Visual Studio-ban:

Jobb klikk a projekt nevére > "Manage NuGet Packages"

Keresés: MySqlConnector
```

---
## Adatbázis kapcsolat
Az alkalmazás a MySqlConnectionStringBuilder osztállyal hoz létre kapcsolatot a helyi MySQL szerverrel.

```bash
var builde = new MySqlConnectionStringBuilder
{
    Server = "127.0.0.1",
    UserID = "root",
    Password = "",
    Database = "ingatlanok"
};

connection = new MySqlConnection(builde.ConnectionString); 
connection.Open();
```

Server: az adatbázis szerver címe (pl. 127.0.0.1 a helyi gépen).

- UserID / Password: az adatbázishoz tartozó felhasználónév és jelszó.

- Database: a használt adatbázis neve, jelen esetben: ingatlanok.

- Ezután az Open() metódussal megnyitja a kapcsolatot.

---

## Adatbázis

Az adatbázis neve **ingatlanok**,  sql kódja:
```bash
CREATE TABLE categories (
  id bigint(20) NOT NULL AUTO_INCREMENT,
  name varchar(100) NOT NULL,
  PRIMARY KEY (id)
)
ENGINE = INNODB,
CHARACTER SET utf8,
COLLATE utf8_hungarian_ci;

CREATE TABLE sellers (
  id bigint(20) NOT NULL AUTO_INCREMENT,
  name varchar(50) DEFAULT NULL,
  phone varchar(255) DEFAULT NULL,
  PRIMARY KEY (id)
)
ENGINE = INNODB,
CHARACTER SET utf8,
COLLATE utf8_hungarian_ci;

CREATE TABLE realestates (
  id bigint(20) NOT NULL AUTO_INCREMENT,
  categoryId bigint(20) NOT NULL,
  sellerId bigint(20) NOT NULL,
  description text DEFAULT "",
  createAt date NOT NULL,
  freeofcharge tinyint(1) NOT NULL,
  imageUrl varchar(200) NOT NULL,
  area int(11) DEFAULT NULL,
  rooms int(11) DEFAULT 1,
  floors int(11) DEFAULT 0,
  latlong varchar(50) DEFAULT NULL,
  PRIMARY KEY (id)
)
ENGINE = INNODB,
CHARACTER SET utf8,
COLLATE utf8_hungarian_ci;

ALTER TABLE realestates
ADD CONSTRAINT FK_realestates_categoryId FOREIGN KEY (categoryId)
REFERENCES categories (id) ON DELETE NO ACTION;

ALTER TABLE realestates
ADD CONSTRAINT FK_realestates_sellerId FOREIGN KEY (sellerId)
REFERENCES sellers (id) ON DELETE NO ACTION;
```