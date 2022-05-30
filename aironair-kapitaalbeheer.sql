-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Gegenereerd op: 30 mei 2022 om 20:53
-- Serverversie: 10.4.21-MariaDB
-- PHP-versie: 8.0.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `aironair-kapitaalbeheer`
--

-- --------------------------------------------------------

--
-- Tabelstructuur voor tabel `gebruiker`
--

CREATE TABLE `gebruiker` (
  `GID` int(11) NOT NULL,
  `VolNaam` varchar(255) NOT NULL,
  `Email` varchar(255) NOT NULL,
  `TelNR` int(11) NOT NULL,
  `RekNR` varchar(18) NOT NULL,
  `PinCodeHash` varchar(255) NOT NULL,
  `IsJongerenRekening` tinyint(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Gegevens worden geëxporteerd voor tabel `gebruiker`
--

INSERT INTO `gebruiker` (`GID`, `VolNaam`, `Email`, `TelNR`, `RekNR`, `PinCodeHash`, `IsJongerenRekening`) VALUES
(5, 'bas 1', 'lethalbas@gmail.com', 683322092, 'NL69AIRN4467042953', '12d9634a066ef75f5c94fc8b7cc77250f4fbf254b79fe7252e36dc22d0b6d40c', 0),
(6, 'bas bakker', 'semegabas@gmail.com', 612345678, 'NL69AIRN5274600231', '88367dd16bfd18ba5595a82d9076f8405807ea4df66c0d282de850391349986a', 0),
(7, 'bas 2', 'vyuvguysd@hydfghuys.com', 628916345, 'NL69AIRN2819264114', '71574e147fa152ed7ba1f4464f114d8d2824153b8c04d15d1820508d2d5777a8', 0),
(8, 'bassie', 'ftvysdghyv', 1234, 'NL69AIRN5392816954', '7c5fab57f8c1447f91f98eb3fcea7954e4f704d92686c5fd2e551e34ca88f8a8', 1);

-- --------------------------------------------------------

--
-- Tabelstructuur voor tabel `medewerker`
--

CREATE TABLE `medewerker` (
  `MID` int(11) NOT NULL,
  `VolNaam` varchar(255) NOT NULL,
  `Email` varchar(255) NOT NULL,
  `WachtwoordHash` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Gegevens worden geëxporteerd voor tabel `medewerker`
--

INSERT INTO `medewerker` (`MID`, `VolNaam`, `Email`, `WachtwoordHash`) VALUES
(3, 'bas', 'lethalbas@gmail.com', '7797a2701fdb8aaa9fdc0e4eeff84fbdf3782760cc4ed1c15cf81dd3842d50c1');

-- --------------------------------------------------------

--
-- Tabelstructuur voor tabel `transactie`
--

CREATE TABLE `transactie` (
  `TID` int(11) NOT NULL,
  `GID` int(11) NOT NULL,
  `Saldo` float NOT NULL,
  `Omschrijving` varchar(510) NOT NULL,
  `DatumTijd` datetime NOT NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Gegevens worden geëxporteerd voor tabel `transactie`
--

INSERT INTO `transactie` (`TID`, `GID`, `Saldo`, `Omschrijving`, `DatumTijd`) VALUES
(1, 6, 10, 'Contant geld gestort', '2022-04-14 00:00:36'),
(2, 6, -5, 'Geld overgemaakt naar: NL69AIRN2819264114', '2022-04-14 00:00:52'),
(3, 7, 5, 'Geld ontvangen van: NL69AIRN5274600231', '2022-04-14 00:00:52'),
(4, 6, -5, 'Geld contant opgenomen', '2022-04-14 00:00:58'),
(5, 6, -5, 'Geld contant opgenomen', '2022-04-14 00:05:22'),
(6, 8, -10, 'Geld overgemaakt naar: NL69AIRN2819264114', '2022-04-14 02:00:23'),
(7, 7, 10, 'Geld ontvangen van: NL69AIRN5392816954', '2022-04-14 02:00:23'),
(8, 8, 15, 'Contant geld gestort', '2022-04-14 02:03:00'),
(9, 8, -5, 'Geld contant opgenomen', '2022-04-14 02:03:04');

--
-- Indexen voor geëxporteerde tabellen
--

--
-- Indexen voor tabel `gebruiker`
--
ALTER TABLE `gebruiker`
  ADD PRIMARY KEY (`GID`),
  ADD UNIQUE KEY `RekNR` (`RekNR`);

--
-- Indexen voor tabel `medewerker`
--
ALTER TABLE `medewerker`
  ADD PRIMARY KEY (`MID`),
  ADD UNIQUE KEY `Email` (`Email`);

--
-- Indexen voor tabel `transactie`
--
ALTER TABLE `transactie`
  ADD PRIMARY KEY (`TID`),
  ADD KEY `GIDFK` (`GID`);

--
-- AUTO_INCREMENT voor geëxporteerde tabellen
--

--
-- AUTO_INCREMENT voor een tabel `gebruiker`
--
ALTER TABLE `gebruiker`
  MODIFY `GID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- AUTO_INCREMENT voor een tabel `medewerker`
--
ALTER TABLE `medewerker`
  MODIFY `MID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT voor een tabel `transactie`
--
ALTER TABLE `transactie`
  MODIFY `TID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;

--
-- Beperkingen voor geëxporteerde tabellen
--

--
-- Beperkingen voor tabel `transactie`
--
ALTER TABLE `transactie`
  ADD CONSTRAINT `GIDFK` FOREIGN KEY (`GID`) REFERENCES `gebruiker` (`GID`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
