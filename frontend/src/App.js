import logo from './logo.svg';
import './App.css';
import { Link } from 'react-router-dom';

function App() {
    const bgImage = '';
    return (
        <div
            className="d-flex flex-column justify-content-end align-items-center"
            style={{
                backgroundImage: `url(${'/real-estate-agent.png'})`,
                backgroundSize: 'cover',
                backgroundPosition: 'center',
                height: '100vh',
            }}
        >
            <div className="d-flex w-100 justify-content-around mb-5">
                <Link to={'/offers'}>
                    <button className="btn btn-primary">Nézze meg a kínálatunka!</button>
                </Link>
                <Link to={'/addnew'}>
                    <button
                        className="btn btn-primary
                "
                    >
                        Hirdessen nálunk
                    </button>
                </Link>
            </div>
        </div>
    );
}

export default App;
