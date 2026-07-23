-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Jul 22, 2026 at 09:10 AM
-- Server version: 10.4.32-MariaDB
-- PHP Version: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `hospital`
--

-- --------------------------------------------------------

--
-- Table structure for table `doctors`
--

CREATE TABLE `doctors` (
  `id` int(11) NOT NULL,
  `name` varchar(40) NOT NULL,
  `mail` varchar(100) DEFAULT NULL,
  `city` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `doctors`
--

INSERT INTO `doctors` (`id`, `name`, `mail`, `city`) VALUES
(4, 'ibrahim', 'owais@gmail.com', 'islamabad'),
(5, 'ibrahim', 'farhan@gmail.com', 'islamabad'),
(6, 'Bilal', 'bilal@gmail.com', 'islamabad');

-- --------------------------------------------------------

--
-- Table structure for table `employee`
--

CREATE TABLE `employee` (
  `id` int(11) NOT NULL,
  `name` varchar(100) DEFAULT NULL,
  `mail` varchar(200) DEFAULT NULL,
  `password` varchar(100) DEFAULT NULL,
  `age` int(11) DEFAULT NULL,
  `city` varchar(100) DEFAULT NULL,
  `diseaes` varchar(100) DEFAULT NULL,
  `weight` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `employee`
--

INSERT INTO `employee` (`id`, `name`, `mail`, `password`, `age`, `city`, `diseaes`, `weight`) VALUES
(1, 'ibrahim', 'john.doe@example.com', 'pass123', 28, 'New York', 'Flu', 75),
(2, 'ibrahim', 'jane.smith@example.com', 'secure456', 34, 'Los Angeles', 'Diabetes', 68),
(3, 'ibrahim', 'mike.b@example.com', 'p@ssword1', 45, 'Chicago', 'Hypertension', 82),
(4, 'ibrahim', 'emily.d@example.com', 'emily!90', 22, 'Houston', 'None', 54),
(5, 'ibrahim', 'james.w@example.com', 'wilson2026', 60, 'Phoenix', 'Arthritis', 90),
(6, 'ibrahim', 'robert.m@example.com', 'rob_m12', 31, 'Philadelphia', 'Asthma', 78),
(7, 'ibrahim', 'linda.j@example.com', 'linda@789', 52, 'San Antonio', 'None', 63),
(8, 'ibrahim', 'will.g@example.com', 'garcia#1', 29, 'San Diego', 'Allergies', 80),
(9, 'ibrahim', 'liz.m@example.com', 'liz_mart', 41, 'Dallas', 'Migraine', 70),
(10, 'ibrahim', 'david.a@example.com', 'dav_and9', 37, 'San Jose', 'None', 85),
(11, 'ibrahim', 'susan.t@example.com', 'sue_taylor', 65, 'Austin', 'Arthritis', 61),
(12, 'ibrahim', 'joe.t@example.com', 'joe_t88', 50, 'Jacksonville', 'Hypertension', 95),
(13, 'ibrahim', 'sarah.m@example.com', 'sarah_m!', 26, 'Fort Worth', 'None', 58),
(14, 'ibrahim', 'charles.m@example.com', 'charles_m', 58, 'Columbus', 'Diabetes', 88),
(15, 'ibrahim', 'jess.j@example.com', 'jess_jack', 33, 'Charlotte', 'Asthma', 66),
(16, 'ibrahim', 'chris.t@example.com', 'chris_t1', 47, 'San Francisco', 'None', 83),
(17, 'ibrahim', 'nancy.w@example.com', 'nancy_w2', 71, 'Indianapolis', 'Arthritis', 59),
(18, 'ibrahim', 'matt.l@example.com', 'matt_lop', 24, 'Seattle', 'None', 73),
(19, 'ibrahim', 'barb.l@example.com', 'barb_lee', 63, 'Denver', 'Hypertension', 67),
(20, 'ibrahim', 'dan.g@example.com', 'dan_gonz', 39, 'Washington', 'Migraine', 81),
(21, 'ibrahim', 'mark.h@example.com', 'mark_h99', 42, 'Boston', 'None', 84),
(22, 'ibrahim', 'paul.c@example.com', 'paul_c88', 55, 'El Paso', 'Diabetes', 89),
(23, 'ibrahim', 'steven.l@example.com', 'steven_l', 30, 'Nashville', 'Asthma', 76),
(24, 'ibrahim', 'andrew.r@example.com', 'andrew_r', 48, 'Detroit', 'Hypertension', 91),
(25, 'ibrahim', 'ken.w@example.com', 'ken_walk', 36, 'Oklahoma City', 'None', 79),
(26, 'ibrahim', 'josh.h@example.com', 'josh_hall', 27, 'Las Vegas', 'Allergies', 72),
(27, 'ibrahim', 'kevin.a@example.com', 'kevin_a1', 51, 'Portland', 'Diabetes', 86),
(28, 'ibrahim', 'brian.y@example.com', 'brian_y2', 44, 'Memphis', 'None', 83),
(29, 'ibrahim', 'george.k@example.com', 'george_k', 68, 'Louisville', 'Arthritis', 77),
(30, 'ibrahim', 'ed.w@example.com', 'ed_wright', 59, 'Milwaukee', 'Hypertension', 92),
(31, 'ibrahim', 'ron.s@example.com', 'ron_scott', 32, 'Baltimore', 'Asthma', 74),
(32, 'ibrahim', 'tim.g@example.com', 'tim_green', 40, 'Albuquerque', 'None', 80),
(33, 'ibrahim', 'jason.b@example.com', 'jason_b1', 35, 'Tucson', 'Migraine', 78),
(34, 'ibrahim', 'jeff.a@example.com', 'jeff_adams', 53, 'Fresno', 'Diabetes', 87),
(35, 'ibrahim', 'ryan.n@example.com', 'ryan_nels', 28, 'Sacramento', 'None', 71),
(36, 'ibrahim', 'jacob.h@example.com', 'jacob_h9', 23, 'Mesa', 'Allergies', 69),
(37, 'ibrahim', 'gary.r@example.com', 'gary_ram', 61, 'Kansas City', 'Arthritis', 85),
(38, 'ibrahim', 'nick.c@example.com', 'nick_camp', 46, 'Atlanta', 'Hypertension', 88),
(39, 'ibrahim', 'eric.m@example.com', 'eric_mitch', 38, 'Long Beach', 'None', 82),
(40, 'ibrahim', 'jon.r@example.com', 'jon_rob', 30, 'Omaha', 'Asthma', 75),
(41, 'ibrahim', 'stephen.c@example.com', 'stephen_c', 57, 'Raleigh', 'Diabetes', 90),
(42, 'ibrahim', 'larry.p@example.com', 'larry_phil', 64, 'Colorado Springs', 'Arthritis', 79),
(43, 'ibrahim', 'justin.e@example.com', 'justin_ev', 29, 'Miami', 'None', 73),
(44, 'ibrahim', 'scott.t@example.com', 'scott_turn', 43, 'Virginia Beach', 'Migraine', 81),
(45, 'ibrahim', 'brandon.t@example.com', 'brandon_t', 31, 'Oakland', 'Asthma', 76),
(46, 'ibrahim', 'ben.p@example.com', 'ben_parker', 25, 'Minneapolis', 'None', 68),
(47, 'ibrahim', 'sam.c@example.com', 'sam_coll', 52, 'Tulsa', 'Hypertension', 86),
(48, 'ibrahim', 'greg.e@example.com', 'greg_edw', 49, 'Arlington', 'Diabetes', 93),
(49, 'ibrahim', 'frank.s@example.com', 'frank_st', 66, 'New Orleans', 'Arthritis', 74),
(50, 'ibrahim', 'alex.f@example.com', 'alex_flor', 34, 'Wichita', 'None', 77),
(51, 'ibrahim', 'ray.m@example.com', 'ray_morris', 56, 'Cleveland', 'Hypertension', 89),
(52, 'ibrahim', 'pat.n@example.com', 'pat_nguyen', 27, 'Tampa', 'Allergies', 70),
(53, 'ibrahim', 'jack.m@example.com', 'jack_murph', 62, 'Bakersfield', 'Arthritis', 82),
(54, 'ibrahim', 'dennis.r@example.com', 'dennis_riv', 41, 'Aurora', 'None', 84),
(55, 'ibrahim', 'jerry.c@example.com', 'jerry_cook', 50, 'Anaheim', 'Diabetes', 88),
(56, 'ibrahim', 'tyler.r@example.com', 'tyler_rog', 23, 'Honolulu', 'Asthma', 65),
(57, 'ibrahim', 'aaron.m@example.com', 'aaron_morg', 36, 'Santa Ana', 'None', 78),
(58, 'ibrahim', 'jose.p@example.com', 'jose_pet', 45, 'Riverside', 'Hypertension', 83),
(59, 'ibrahim', 'adam.c@example.com', 'adam_coop', 32, 'Corpus Christi', 'Migraine', 76),
(60, 'ibrahim', 'nathan.r@example.com', 'nathan_reed', 28, 'Lexington', 'None', 72),
(61, 'ibrahim', 'henry.b@example.com', 'henry_bail', 67, 'Henderson', 'Arthritis', 80),
(62, 'ibrahim', 'douglas.b@example.com', 'doug_bell', 54, 'Stockton', 'Diabetes', 91),
(63, 'ibrahim', 'peter.g@example.com', 'peter_g', 39, 'Saint Paul', 'None', 84),
(64, 'ibrahim', 'kyle.k@example.com', 'kyle_kelly', 26, 'Cincinnati', 'Asthma', 71),
(65, 'ibrahim', 'walter.h@example.com', 'walter_h', 70, 'St. Louis', 'Hypertension', 76),
(66, 'ibrahim', 'harold.w@example.com', 'harold_ward', 58, 'Pittsburgh', 'Diabetes', 85),
(67, 'ibrahim', 'jeremy.c@example.com', 'jeremy_cox', 33, 'Greensboro', 'None', 79),
(68, 'ibrahim', 'ethan.d@example.com', 'ethan_diaz', 24, 'Lincoln', 'Allergies', 68),
(69, 'ibrahim', 'carl.r@example.com', 'carl_rich', 61, 'Orlando', 'Arthritis', 83),
(70, 'ibrahim', 'keith.w@example.com', 'keith_wood', 48, 'Plano', 'Hypertension', 90),
(71, 'ibrahim', 'roger.w@example.com', 'roger_wat', 53, 'Newark', 'None', 87),
(72, 'ibrahim', 'gerald.b@example.com', 'gerald_b', 65, 'Chula Vista', 'Diabetes', 79),
(73, 'ibrahim', 'chris.b@example.com', 'chris_ben', 29, 'Durham', 'Asthma', 74),
(74, 'ibrahim', 'albert.g@example.com', 'albert_gray', 69, 'Irvine', 'Arthritis', 75),
(75, 'ibrahim', 'jon.j@example.com', 'jon_james', 35, 'Fort Wayne', 'None', 82),
(76, 'ibrahim', 'terry.r@example.com', 'terry_reyes', 46, 'Jersey City', 'Hypertension', 88),
(77, 'ibrahim', 'lawrence.c@example.com', 'law_cruz', 51, 'Laredo', 'Diabetes', 86),
(78, 'ibrahim', 'sean.h@example.com', 'sean_hughes', 31, 'Madison', 'None', 77),
(79, 'ibrahim', 'chris.p@example.com', 'chris_price', 27, 'Chandler', 'Migraine', 73),
(80, 'ibrahim', 'austin.m@example.com', 'austin_my', 22, 'Buffalo', 'Asthma', 66),
(81, 'ibrahim', 'joe.l@example.com', 'joe_long1', 55, 'Lubbock', 'None', 89),
(82, 'ibrahim', 'noah.f@example.com', 'noah_foster', 26, 'Scottsdale', 'Allergies', 70),
(83, 'ibrahim', 'jesse.s@example.com', 'jesse_sand', 42, 'Reno', 'Hypertension', 84),
(84, 'ibrahim', 'albert.r@example.com', 'albert_ross', 63, 'Glendale', 'Arthritis', 81),
(85, 'ibrahim', 'bryan.m@example.com', 'bryan_mo', 37, 'Gilbert', 'None', 80),
(86, 'ibrahim', 'billy.p@example.com', 'billy_pow', 50, 'Winston-Salem', 'Diabetes', 92),
(87, 'ibrahim', 'bruce.s@example.com', 'bruce_sull', 58, 'North Las Vegas', 'Asthma', 86),
(88, 'ibrahim', 'willie.r@example.com', 'willie_russ', 64, 'Norfolk', 'None', 78),
(89, 'ibrahim', 'jordan.o@example.com', 'jordan_ort', 25, 'Chesapeake', 'Migraine', 69),
(90, 'ibrahim', 'alan.j@example.com', 'alan_jenk', 47, 'Garland', 'Hypertension', 85),
(91, 'ibrahim', 'ralph.g@example.com', 'ralph_gut', 52, 'Irving', 'Diabetes', 88),
(92, 'ibrahim', 'roy.p@example.com', 'roy_perry', 60, 'Hialeah', 'Arthritis', 76),
(93, 'ibrahim', 'wayne.f@example.com', 'wayne_f', 34, 'Fremont', 'None', 81),
(94, 'ibrahim', 'eugene.r@example.com', 'eugene_rey', 43, 'Boise', 'Asthma', 83),
(95, 'ibrahim', 'gabriel.g@example.com', 'gab_grif', 28, 'Richmond', 'None', 74),
(96, 'ibrahim', 'louis.p@example.com', 'louis_port', 66, 'Batton Rouge', 'Hypertension', 89),
(97, 'ibrahim', 'russell.d@example.com', 'russ_diaz', 39, 'Spokane', 'Diabetes', 82),
(98, 'ibrahim', 'harry.h@example.com', 'harry_hayes', 56, 'Des Moines', 'None', 87),
(99, 'ibrahim', 'philip.m@example.com', 'phil_myers', 30, 'Tacoma', 'Allergies', 75),
(100, 'ibrahim', 'bobby.c@example.com', 'bobby_cas', 41, 'Modesto', 'Arthritis', 80);

-- --------------------------------------------------------

--
-- Table structure for table `products`
--

CREATE TABLE `products` (
  `id` int(11) NOT NULL,
  `name` varchar(50) DEFAULT NULL,
  `price` int(11) DEFAULT NULL,
  `quantity` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `products`
--

INSERT INTO `products` (`id`, `name`, `price`, `quantity`) VALUES
(1, 'soap', 120, 56),
(2, 'tea bag', 300, 40),
(3, 'rice', 50, 500),
(4, 'cold drink', 256, 90);

-- --------------------------------------------------------

--
-- Table structure for table `staff`
--

CREATE TABLE `staff` (
  `id` int(11) NOT NULL,
  `Employee_Name` varchar(100) DEFAULT NULL,
  `Address` varchar(255) DEFAULT NULL,
  `age` int(11) DEFAULT 18
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `staff`
--

INSERT INTO `staff` (`id`, `Employee_Name`, `Address`, `age`) VALUES
(1, 'brahim', 'karachi', 18),
(2, 'khizer', 'lahore', 18),
(3, 'usman', 'panjab', 18),
(4, 'umer', 'karachi', 34),
(5, 'bilal', 'karachi', 18),
(6, 'fazal', 'karachi', 18),
(7, 'awish', 'panjab', 18),
(8, 'quddos', 'lahore', 18),
(9, 'owais', 'lahore', 18),
(10, 'noor', 'multan', 18),
(11, 'pankaj', 'islamabad', 18),
(12, 'chitroly', 'karachi', 18),
(13, 'muniba', 'panjab', 18),
(14, 'anees', 'karachi', 18);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `doctors`
--
ALTER TABLE `doctors`
  ADD UNIQUE KEY `id` (`id`);

--
-- Indexes for table `employee`
--
ALTER TABLE `employee`
  ADD UNIQUE KEY `id` (`id`);

--
-- Indexes for table `products`
--
ALTER TABLE `products`
  ADD UNIQUE KEY `id` (`id`);

--
-- Indexes for table `staff`
--
ALTER TABLE `staff`
  ADD UNIQUE KEY `id` (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `doctors`
--
ALTER TABLE `doctors`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT for table `employee`
--
ALTER TABLE `employee`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=101;

--
-- AUTO_INCREMENT for table `products`
--
ALTER TABLE `products`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT for table `staff`
--
ALTER TABLE `staff`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=15;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
