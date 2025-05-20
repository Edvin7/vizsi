import React, { useEffect, useState } from 'react';

const Offers = () => {
    const [offers, setOffers] = useState([1, 2, 3]);

    const fetchOffers = async () => {
        const { res, error } = await fetch('http::/localhost:8080/api/ingatlanok');

        if (error) {
            console.log('error');
        }

        setOffers(res);
    };

    useEffect(() => {}, []);

    return (
        <div className="container">
            {offers.map((link) => (
                <div className="row justift-content-between">
                    <div className="col-3">Nev</div>
                    <div className="col-3">Idk</div>
                    <div className="col-3">Mittuodm</div>
                </div>
            ))}
        </div>
    );
};

export default Offers;
