"use client";
import React from 'react';
import './OpenPage.css';
import { useNavigate } from 'react-router-dom';
import bgImage from '../assets/real-estate-agent.png'; // ide tedd a képet

const OpenPage = () => {
  const navigate = useNavigate();

  return (
    <div
      className="container-fluid d-flex justify-content-center align-items-center vh-100"
      style={{
        backgroundImage: `url(${bgImage})`,
        backgroundSize: 'cover',
        backgroundPosition: 'center',
      }}
    >
      <div className="text-center bg-white p-4 rounded shadow">
        <h1 className="mb-4">Á.L.B. Ingatlanügynökség</h1>
        <div className="d-flex gap-3 justify-content-center">
          <button className="btn btn-primary" onClick={() => navigate('/offers')}>
            Nézze meg kínálatunkat!
          </button>
          <button className="btn btn-primary" onClick={() => navigate('/newad')}>
            Hirdessen nálunk!
          </button>
        </div>
      </div>
    </div>
  );
};

export default OpenPage;
