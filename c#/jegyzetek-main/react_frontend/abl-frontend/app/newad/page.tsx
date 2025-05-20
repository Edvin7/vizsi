'use client';

import { useEffect, useState } from 'react';
import { useRouter } from 'next/navigation';
import 'bootstrap/dist/css/bootstrap.min.css';

export default function NewAdPage() {
  const router = useRouter();
  const [kategoriak, setKategoriak] = useState<{ id: number; name: string }[]>([]);
  const [form, setForm] = useState({
    kategoria: '',
    elado: '',
    leiras: '',
    hirdetesDatuma: new Date().toISOString().split('T')[0],
    tehermentes: true,
    kepUrl: '',
    terulet: '',
    szobak: '',
    emeletek: '',
    koordinatak: ''
  });
  const [error, setError] = useState('');

  useEffect(() => {
    fetch('http://localhost:3000/api/kategoriak')
      .then(res => res.json())
      .then(data => setKategoriak(data))
      .catch(err => setError('Nem sikerült betölteni a kategóriákat.'));
  }, []);

  const handleChange = (
  e: React.ChangeEvent<
    HTMLInputElement | HTMLTextAreaElement | HTMLSelectElement
  >
) => {
  const { name, type, value } = e.target;
  let newValue: string | boolean = value;

  if (type === 'checkbox') {
    // TypeScript biztonságosan szűrve:
    const target = e.target as HTMLInputElement;
    newValue = target.checked;
  }

  setForm(prev => ({
    ...prev,
    [name]: newValue,
  }));
};


  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    setError('');

    try {
      const response = await fetch('http://localhost:3000/api/ujingatlan', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(form)
      });

      if (response.ok) {
        router.push('/offers');
      } else {
        const errorText = await response.text();
        setError(`Hiba: ${errorText}`);
      }
    } catch (err) {
      setError('Hálózati hiba történt.');
    }
  };

  return (
    <div className="container mt-5">
      <h2 className="mb-4 text-center">Új hirdetés elküldése</h2>
      <form onSubmit={handleSubmit}>
        <div className="row">
          <div className="offset-lg-3 offset-md-2 col-lg-6 col-md-8 col-12">
            <div className="mb-3">
              <label className="form-label">Ingatlan kategóriája</label>
              <select className="form-select" name="kategoria" value={form.kategoria} onChange={handleChange} required>
                <option value="">Kérem válasszon</option>
                {kategoriak.map(kat => (
                  <option key={kat.id} value={kat.id}>{kat.name}</option>
                ))}
              </select>
            </div>

            <div className="mb-3">
              <label className="form-label">Eladó neve</label>
              <input type="text" className="form-control" name="elado" value={form.elado} onChange={handleChange} required />
            </div>

            <div className="mb-3">
              <label className="form-label">Hirdetés dátuma</label>
              <input type="date" className="form-control" name="hirdetesDatuma" value={form.hirdetesDatuma} readOnly />
            </div>

            <div className="mb-3">
              <label className="form-label">Ingatlan leírása</label>
              <textarea className="form-control" name="leiras" rows={3} value={form.leiras} onChange={handleChange} required />
            </div>

            <div className="form-check mb-3">
              <input className="form-check-input" type="checkbox" name="tehermentes" checked={form.tehermentes} onChange={handleChange} />
              <label className="form-check-label">Tehermentes ingatlan</label>
            </div>

            <div className="mb-3">
              <label className="form-label">Fénykép az ingatlanról (URL)</label>
              <input type="url" className="form-control" name="kepUrl" value={form.kepUrl} onChange={handleChange} required />
            </div>

            <div className="mb-3">
              <label className="form-label">Terület (m²)</label>
              <input type="number" className="form-control" name="terulet" value={form.terulet} onChange={handleChange} required />
            </div>

            <div className="mb-3">
              <label className="form-label">Szobák száma</label>
              <input type="number" className="form-control" name="szobak" value={form.szobak} onChange={handleChange} required />
            </div>

            <div className="mb-3">
              <label className="form-label">Emeletek száma</label>
              <input type="number" className="form-control" name="emeletek" value={form.emeletek} onChange={handleChange} required />
            </div>

            <div className="mb-3">
              <label className="form-label">Koordináták (pl.: 47.4979, 19.0402)</label>
              <input type="text" className="form-control" name="koordinatak" value={form.koordinatak} onChange={handleChange} required />
            </div>

            <div className="mb-3 text-center">
              <button type="submit" className="btn btn-primary px-5">Küldés</button>
            </div>

            {error && (
              <div className="alert alert-danger alert-dismissible" role="alert">
                <strong>{error}</strong>
                <button type="button" className="btn-close" onClick={() => setError('')}></button>
              </div>
            )}
          </div>
        </div>
      </form>
    </div>
  );
}
