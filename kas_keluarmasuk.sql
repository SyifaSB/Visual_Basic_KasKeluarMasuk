-- phpMyAdmin SQL Dump
-- version 4.9.0.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Dec 04, 2019 at 07:38 AM
-- Server version: 10.4.6-MariaDB
-- PHP Version: 7.1.32

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `kas_keluarmasuk`
--

-- --------------------------------------------------------

--
-- Table structure for table `tbl_kaskeluarmasuk`
--

CREATE TABLE `tbl_kaskeluarmasuk` (
  `id` varchar(10) NOT NULL,
  `nama` varchar(100) NOT NULL,
  `tanggal` varchar(50) NOT NULL,
  `jenis` varchar(10) NOT NULL,
  `jumlah` int(100) NOT NULL,
  `saldo_sekarang` int(100) NOT NULL,
  `keterangan` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tbl_kaskeluarmasuk`
--

INSERT INTO `tbl_kaskeluarmasuk` (`id`, `nama`, `tanggal`, `jenis`, `jumlah`, `saldo_sekarang`, `keterangan`) VALUES
('T001', 'Syifa', '13 November 2019', 'Masuk', 300000, 300000, 'Menabung'),
('T002', 'rtbtyh', '04 Desember 2019', 'Masuk', 500, 500, 'parkir');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `tbl_kaskeluarmasuk`
--
ALTER TABLE `tbl_kaskeluarmasuk`
  ADD PRIMARY KEY (`id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
