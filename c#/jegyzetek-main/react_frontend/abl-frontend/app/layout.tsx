import type { Metadata } from "next";
import { ReactNode } from "react";

import { Geist, Geist_Mono } from "next/font/google";
import "./globals.css";

const geistSans = Geist({
  variable: "--font-geist-sans",
  subsets: ["latin"],
});

const geistMono = Geist_Mono({
  variable: "--font-geist-mono",
  subsets: ["latin"],
});

export const metadata = {
  title: "ÁLB Ingatlanügynökség",
  description: "Fedezze fel kínálatunkat vagy adja fel hirdetését!",
};

export default function RootLayout({ children }: { children: React.ReactNode }) {
  return (
    <html lang="hu">
      <head>
        <link rel="stylesheet" href="/bootstrap.min.css" />
        <link rel="stylesheet" href="/openpage.css" />
      </head>
      <body>{children}</body>
    </html>
  );
}


