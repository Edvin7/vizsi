import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';

const Addnew = () => {
    const navigate = useNavigate();
    const [isError, setIsError] = useState(false);
    const [offers, setOffers] = useState({
        kategoria: 1,
        leiras: 'Eladó ...',
        hirdetesDatuma: new Date(),
        tehermentes: true,
        ar: 26990000,
        kepUrl: 'https://pictures.com/apartman.jpg',
    });

    const send = async () => {
        const response = await fetch('https://example.org/post', {
            method: 'POST',
            body: JSON.stringify({ username: 'example' }),
            // …
        });
        if (response.status !== 200) {
            setIsError(true);
            return;
        }
        navigate('/offers');
    };
    console.log(offers);

    return (
        <div class="container">
            <h2 class="mb-4 text-center">Új hirdetés elküldése</h2>
            <div class="row">
                <div class="offset-lg-3 offset-md-2 col-lg-6 col-md-8 col-12">
                    <div class="mb-3">
                        <label for="category" class="form-label">
                            Ingatlan kategóriája
                        </label>
                        <select
                            class="form-select"
                            name="kategoriaId"
                            value={offers.kategoria}
                            onChange={(e) =>
                                setOffers((prev) => ({
                                    ...prev,
                                    kategoria: e.target.value,
                                }))
                            }
                        >
                            <option value="0">Kérem válasszon</option>
                            <option value="1">Ház</option>
                            <option value="2">Lakás</option>
                            <option value="3">Építési telek</option>
                            <option value="4">Garázs</option>
                            <option value="5">Mezőgazdasági terület</option>
                            <option value="6">Ipari ingatlan</option>
                        </select>
                    </div>
                    <div class="mb-3">
                        <label for="date" class="form-label">
                            Hirdetés dátuma
                        </label>
                        <input
                            type="date"
                            class="form-control"
                            name="hirdetesDatuma"
                            value={offers.hirdetesDatuma.toISOString().split('T')[0]}
                            onChange={(e) =>
                                setOffers((prev) => ({
                                    ...prev,
                                    hirdetesDatuma: e.target.value,
                                }))
                            }
                        />
                    </div>
                    <div class="mb-3">
                        <label for="description" class="form-label">
                            Ingatlan leírása
                        </label>
                        <textarea
                            class="form-control"
                            name="leiras"
                            rows="3"
                            value={offers.leiras}
                            onChange={(e) =>
                                setOffers((prev) => ({
                                    ...prev,
                                    leiras: e.target.value,
                                }))
                            }
                        ></textarea>
                    </div>
                    <div class="form-check mb-3">
                        <input class="form-check-input" type="checkbox" name="tehermentes" checked />
                        <label class="form-check-label" for="creditFree">
                            Tehermentes ingatlan
                        </label>
                    </div>
                    <div class="mb-3">
                        <label for="pictureUrl" class="form-label">
                            Fénykép az ingatlanról
                        </label>
                        <input type="url" class="form-control" name="kepUrl" />
                    </div>
                    <div class="mb-3 text-center">
                        <button class="btn btn-primary px-5">Küldés</button>
                    </div>
                    {isError && (
                        <div className="alert alert-danger alert-dismissible" role="alert">
                            <strong>Hiba szövege</strong>
                            <button type="button" className="btn-close"></button>
                        </div>
                    )}
                </div>
            </div>
        </div>
    );
};

export default Addnew;
