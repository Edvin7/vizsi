import Image from "next/image";


export default function Home() {
  return (
    <div className="container">
      <div className="start w-100">
        <h1 className="text-center pt-2 pt-lg-4">Á.L.B. Ingatlanügynöség</h1>
        <div className="row">
          <div className="col-12 col-sm-6 text-center mb-3">
            <a className="btn btn-primary" href="/offers">
              Nézze meg kínálatunkat!
            </a>
          </div>
          <div className="col-12 col-sm-6 text-center mb-3">
            <a className="btn btn-primary" href="/newad"> 
              Hirdessen nálunk!
            </a>
          </div>
        </div>
      </div>
    </div>
  );
}

