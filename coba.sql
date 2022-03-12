-- phpMyAdmin SQL Dump
-- version 4.7.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: 12 Mar 2022 pada 01.41
-- Versi Server: 10.1.22-MariaDB
-- PHP Version: 7.1.4

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `coba`
--
CREATE DATABASE IF NOT EXISTS `coba` DEFAULT CHARACTER SET latin1 COLLATE latin1_general_ci;
USE `coba`;

-- --------------------------------------------------------

--
-- Struktur dari tabel `tb_coba`
--

DROP TABLE IF EXISTS `tb_coba`;
CREATE TABLE `tb_coba` (
  `kode` varchar(25) COLLATE latin1_general_ci NOT NULL,
  `nama` varchar(50) COLLATE latin1_general_ci DEFAULT NULL,
  `jenis_kelamin` enum('Laki-Laki','Perempuan') COLLATE latin1_general_ci DEFAULT NULL,
  `tgl_lahir` date DEFAULT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1 COLLATE=latin1_general_ci;

--
-- Dumping data untuk tabel `tb_coba`
--

INSERT INTO `tb_coba` (`kode`, `nama`, `jenis_kelamin`, `tgl_lahir`) VALUES
('A-1', 'Peter Parker', 'Laki-Laki', '2000-03-10'),
('A-2', 'John Cena', 'Laki-Laki', '1983-03-10'),
('A-3', 'Undertaker', 'Laki-Laki', '1978-03-12'),
('A-4', 'Lara Croft', 'Perempuan', '1983-03-10'),
('A-5', 'Emma Watson', 'Perempuan', '1983-03-10');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `tb_coba`
--
ALTER TABLE `tb_coba`
  ADD PRIMARY KEY (`kode`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
