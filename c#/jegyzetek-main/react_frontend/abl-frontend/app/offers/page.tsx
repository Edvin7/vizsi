// app/offers/page.tsx
"use client";

import { DataGrid, GridColDef ,GridPaginationModel} from "@mui/x-data-grid";
import { useEffect, useState } from "react";

interface RealEstate {
  id: number;
  category: string;
  description: string;
  createAt: string;
  freeofcharge: number;
  imageUrl: number;
}

export default function OffersPage() {
    const [offers, setOffers] = useState<RealEstate[]>([]);
    const [paginationModel, setPaginationModel] = useState<GridPaginationModel>({
    pageSize: 10,
    page: 0,
    });

  useEffect(() => {
    fetch("http://localhost:3000/api/ingatlan")
      .then((res) => res.json())
      .then((data) => setOffers(data))
      .catch((err) => console.error("Hiba az adatok lekérdezésekor:", err));
  }, []);

  const columns: GridColDef[] = [
    { field: "id", headerName: "ID", width: 70 },
    { field: "category", headerName: "Kategória", width: 200 },
    { field: "description", headerName: "Leírás", width: 150 },
    { field: "createAt", headerName: "Hirdetés dátuma", width: 200 },
    { field: "freeofcharge", headerName: "Tehermentes", width: 130 },
    { field: "imageUrl", headerName: "Kép", width: 150 },
  ];

  return (
    <div style={{ height: 500, width: "100%", padding: "1rem" }}>
      <h1 className="text-xl mb-4">Ingatlan ajánlatok</h1>
      <DataGrid
        rows={offers}
        columns={columns}
        paginationModel={paginationModel}
        onPaginationModelChange={setPaginationModel}
        pageSizeOptions={[5, 10, 20]}
        />
    </div>
  );
}
