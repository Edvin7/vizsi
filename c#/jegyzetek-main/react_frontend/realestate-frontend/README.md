#  REACT frontend

Egy **React alapú frontend alkalmazás**, amely az [Ingatlan API](https://github.com/nagygabor123/jegyzetek/tree/main/nodeJsSzerver) végpontjait használja.  
Az alkalmazás képes:

-  Az összes ingatlant megjeleníteni egy táblázatban.
-  Ingatlan törlése egy gombnyomással.
-  Új ingatlan hozzáadása űrlapon keresztül.


## Könyvtárak telepítése és futtatás
```bash

npx create-next-app@latest realestate-frontend
cd realestate-frontend
npx shadcn@latest init
npx shadcn@latest add button
npx shadcn@latest add card
npx shadcn@latest add input
npx shadcn@latest add label
```
```bash
npm run dev
```