// main.js
const express = require('express');
const mysql = require('mysql2/promise');
const cors = require('cors'); // Csak akkor szükséges, ha a frontend és a backend különböző domain-en fut   
const app = express();
app.use(cors());// Csak akkor szükséges, ha a frontend és a backend különböző domain-en fut
app.use(express.json());

const pool = mysql.createPool({
    host: 'localhost',
    user: 'root',
    password: '',
    database: 'ingatlanok',
    waitForConnections: true,
    connectionLimit: 10,
    queueLimit: 0
});


// GET /api/ingatlan
app.get('/api/ingatlan', async (req, res) => {
    try {
        const [rows] = await pool.query(`
      SELECT 
            r.id,
            c.name AS category,
            s.name AS seller,
            r.description,
            r.createAt,
            r.freeofcharge,
            r.imageUrl,
            r.area,
            r.rooms,
            r.floors,
            r.latlong
        FROM realestates r
        JOIN categories c ON r.categoryId = c.id
        JOIN sellers s ON r.sellerId = s.id;
    `);
        res.json(rows);
    } catch (err) {
        console.error(err);
        res.status(500).send('Szerverhiba');
    }
});

app.get('/api/kategoriak', async (req, res) => {
    try {
        const [rows] = await pool.query(`SELECT * FROM categories;`);
        res.json(rows);
    } catch (err) {
        console.error(err);
        res.status(500).send('Szerverhiba');
    }
});

// POST /api/ujingatlan
app.post('/api/ujingatlan', async (req, res) => {
    const { kategoria, elado, leiras, hirdetesDatuma, tehermentes, kepUrl, terulet, szobak, emeletek, koordinatak } = req.body;


    if (!kategoria || !elado || !leiras || !hirdetesDatuma || typeof tehermentes !== 'boolean' || !kepUrl || terulet === undefined || szobak === undefined || emeletek === undefined || !koordinatak) {
        return res.status(400).send('Hiányos adatok.');
    }

    try {
        const [result] = await pool.query(`
            INSERT INTO realestates (
                categoryId,
                sellerId,
                description,
                createAt,
                freeofcharge,
                imageUrl,
                area,
                rooms,
                floors,
                latlong
            ) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?)`,
            [kategoria, elado, leiras, hirdetesDatuma, tehermentes, kepUrl, terulet, szobak, emeletek, koordinatak]
        );
        res.status(201).json({ Id: result.insertId });
    } catch (err) {
        console.error(err);
        res.status(500).send('Szerverhiba');
    }
});



// DELETE /api/ingatlan/:id
app.delete('/api/ingatlan/:id', async (req, res) => {
    const id = req.params.id;

    try {
        const [result] = await pool.query('DELETE FROM realestates WHERE id = ?', [id]);

        if (result.affectedRows === 0) {
            return res.status(404).send('Az ingatlan nem létezik.');
        }

        res.sendStatus(204).send('Az ingatlant töröltem.');
    } catch (err) {
        console.error(err);
        res.status(500).send('Szerverhiba');
    }
});

const PORT = 3000;
app.listen(PORT, () => {
    console.log(`Szerver fut a ${PORT}-as porton`);
});
