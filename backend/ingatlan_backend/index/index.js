const express = require('express');
const mysql = require('mysql');
const cors = require('cors');
const path = require('path');

const app = express();
const port = 3000;

const db = mysql.createPool({
  host: 'localhost',
  user: 'root',
  password: '',
  database: 'ingatlan'
});


app.use(cors());
app.use(express.json()); 
app.use(express.static(path.join(__dirname, 'public')));


// 1. read
app.get('/api/ingatlan', (req, res) => {
    db.query('SELECT * FROM ingatlanok INNER JOIN kategoriak ON ingatlanok.kategoria = kategoriak.id ', (err, results) => {
      if (err) return res.status(500).json({ error: err.message });
      const respons = new Array();
      for (let x of results) {
        let res = {
          id: x.id,
          kategoria: x.nev,
          leiras: x.leiras,
          hirdetesDatuma: x.hirdetesDatuma,
          tehermentes: x.tehermentes,
          ar : x.ar,
          kepUrl: x.kepUrl
          };
          respons.push (res)
      }

      res.json(respons);
    });
  });

// 2. creat
  app.post('/api/ingatlan', (req, res) => {
  const { kategoria, leiras, hirdetesDatuma, tehermentes, ar, kepUrl } = req.body;

  if (!kategoria || !leiras) {
    return res.status(400).json({ error: 'Hiányzó adatok.' });
  }

  const query = `
    INSERT INTO ingatlanok (kategoria, leiras, hirdetesDatuma, tehermentes, ar, kepUrl)
    VALUES (?, ?, ?, ?, ?, ?)
  `;
  const date = hirdetesDatuma || new Date().toISOString().split('T')[0];

  db.query(query, [kategoria, leiras, date, tehermentes ?? false, ar ?? 0, kepUrl ?? ''], (err, result) => {
    if (err) return res.status(500).json({ error: err.message });
    res.status(201).json({ id: result.insertId });
  });
});

// 3. delet
app.delete('/api/ingatlan/:id', (req, res) => {
    const id = req.params.id;

  
    db.query('SELECT * FROM ingatlanok WHERE id = ?', [id], (err, results) => {
      if (err) return res.status(500).json({ error: err.message });
  
      if (results.length === 0) {
        return res.status(404).json({ error: 'Az ingatlan nem létezik.' });
      }
  
      db.query('DELETE FROM ingatlanok WHERE id = ?', [id], (err) => {
        if (err) return res.status(500).json({ error: err.message });
        res.sendStatus(204); 
      });
    });
  });

//4. update

app.put('/api/ingatlan/:id', (req, res) => {
  console.log('helllo');
  const { kategoria, leiras, hirdetesDatuma, tehermentes, ar, kepUrl } = req.body;
  const id = req.params.id;

  const query = `
    UPDATE ingatlanok
    SET kategoria = ?, leiras = ?, hirdetesDatuma = ?, tehermentes = ?, ar = ?, kepUrl = ?
    WHERE id = ?
  `;

  db.query(query, [kategoria, leiras, hirdetesDatuma, tehermentes, ar, kepUrl, id], (err, result) => {
    if (err) {
      console.error('Hiba az ingatlan frissítésekor:', err);
      return res.status(500).send({ error: 'Hiba történt a frissítés során.' });
    }

    if (result.affectedRows === 0) {
      return res.status(404).send({ message: 'Nincs ilyen ID-jű ingatlan.' });
    }

    res.send({ message: 'Ingatlan sikeresen frissítve.' });
  });
});


app.listen(port, () => {
  console.log(`Szerver fut a http://localhost:${port} címen`);
});
