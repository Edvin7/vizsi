CREATE TABLE kategoriak (
    id INT AUTO_INCREMENT PRIMARY KEY,
    nev VARCHAR(255) NOT NULL
);

CREATE TABLE ingatlanok (
    id INT AUTO_INCREMENT PRIMARY KEY,
    kategoria INT,
    leiras TEXT,
    hirdetesDatuma DATE DEFAULT CURRENT_DATE,
    tehermentes BOOLEAN,
    ar INT,
    kepUrl VARCHAR(255),
    FOREIGN KEY (kategoria) REFERENCES kategoriak(id)
);

INSERT INTO kategoriak (nev) VALUES
('Ház'),
('Lakás'),
('Építési telek'),
('Garázs'),
('Mezőgazdasági terület'),
('Ipari ingatlan');
