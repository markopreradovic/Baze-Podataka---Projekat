CREATE DATABASE  IF NOT EXISTS `autobuskastanica1` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci */;
USE `autobuskastanica1`;
-- MySQL dump 10.13  Distrib 8.0.34, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: autobuskastanica1
-- ------------------------------------------------------
-- Server version	5.5.5-10.4.32-MariaDB

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Dumping data for table `autobus`
--

LOCK TABLES `autobus` WRITE;
/*!40000 ALTER TABLE `autobus` DISABLE KEYS */;
INSERT INTO `autobus` VALUES (1,'Autobuska Express','Mercedes','Tourismo',50,'BG123AB',1,1,1);
/*!40000 ALTER TABLE `autobus` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `autobuskastanica`
--

LOCK TABLES `autobuskastanica` WRITE;
/*!40000 ALTER TABLE `autobuskastanica` DISABLE KEYS */;
INSERT INTO `autobuskastanica` VALUES (1,'AS BL','Banja Luka',10,'Adresa Stanice 1','051657000'),(2,'Stanica Lasta','Bijeljina',5,'Adresa Stanice 2','051325000'),(3,'S Tours','Prnjavor',5,'Adresa Stanice 3','051643000');
/*!40000 ALTER TABLE `autobuskastanica` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `autoprevoznik`
--

LOCK TABLES `autoprevoznik` WRITE;
/*!40000 ALTER TABLE `autoprevoznik` DISABLE KEYS */;
INSERT INTO `autoprevoznik` VALUES ('Lasta','Novi Sad','Trg Republike 2','035/444-989'),('Milinovic','Beograd','Ulica Voždovac 15','034/212-515');
/*!40000 ALTER TABLE `autoprevoznik` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `garaza`
--

LOCK TABLES `garaza` WRITE;
/*!40000 ALTER TABLE `garaza` DISABLE KEYS */;
INSERT INTO `garaza` VALUES (1,1,'Beograd',1);
/*!40000 ALTER TABLE `garaza` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `karta`
--

LOCK TABLES `karta` WRITE;
/*!40000 ALTER TABLE `karta` DISABLE KEYS */;
INSERT INTO `karta` VALUES (5,1,1,1,'Povratna','2024-01-15','08:00:00','Banja Luka','Prijedor','12:51:54',1,58,1,1,32,'Milinovic'),(7,1,1,1,'Povratna','2024-01-04','08:00:00','Banja Luka','Prijedor','16:14:54',1,60,2,1,36,'Milinovic'),(8,1,1,4,'Povratna','2024-01-06','11:00:00','Bijeljina','Beograd','16:52:06',4,61,3,2,50,'Milinovic'),(10,1,1,1,'Jednosmjerna','2024-01-19','08:00:00','Banja Luka','Prijedor','17:18:37',1,63,1,1,20,'Milinovic');
/*!40000 ALTER TABLE `karta` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `kondukter`
--

LOCK TABLES `kondukter` WRITE;
/*!40000 ALTER TABLE `kondukter` DISABLE KEYS */;
INSERT INTO `kondukter` VALUES (1,'Milan','Vidic','1234567890123','1980-02-02','065123654','Adresa 1','Milinovic',2,1);
/*!40000 ALTER TABLE `kondukter` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `putnik`
--

LOCK TABLES `putnik` WRITE;
/*!40000 ALTER TABLE `putnik` DISABLE KEYS */;
INSERT INTO `putnik` VALUES (1,'Marko','Marković','789-123'),(55,'Milan','Nikolic','065789345'),(58,'Milan','Mitric','065783923'),(60,'Tamara','Nikolic','066-545-323'),(61,'Dalibor','Kovacevic','065-232-333'),(63,'Milan','Simic','065-787-656');
/*!40000 ALTER TABLE `putnik` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `radnik`
--

LOCK TABLES `radnik` WRITE;
/*!40000 ALTER TABLE `radnik` DISABLE KEYS */;
INSERT INTO `radnik` VALUES (1,'Marko','Mitrovic','1990-05-15','1234567890123','111-222','Adresa 2',1),(2,'Anja','Panic','1985-10-20','9876543210123','333-444','Adresa 3',1),(3,'Ivan','Kitic','1992-02-28','5432109870123','555-666','Adresa 4',2),(4,'Ema','Simic','1988-12-10','1357924680123','777-888','Adresa 5',2),(5,'Milan','Mitrovic','2024-01-12','6578976545349','065786432','Adresa 7A',2);
/*!40000 ALTER TABLE `radnik` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `ruta`
--

LOCK TABLES `ruta` WRITE;
/*!40000 ALTER TABLE `ruta` DISABLE KEYS */;
INSERT INTO `ruta` VALUES (1,'Bijeljina - Prijedor','08:00:00','Banja Luka','Prijedor',5,1,1,1,10,25,'Milinovic',1),(2,'BanjaLuka - Bijeljina','10:00:00','Banja Luka','Bijeljina',4,2,2,1,11,30,'Milinovic',1),(3,'Bijeljina - Beograd','09:00:00','Bijeljina','Novi Sad',6,1,1,2,12,28.5,'Lasta',1),(4,'BanjaLuka - Beograd','11:00:00','Bijeljina','Beograd',7,2,2,2,13,33,'Milinovic',1),(5,'Beograd - Prijedor','06:30:00','Banja Luka','Prijedor',2,1,1,1,4,20,'Lasta',1),(6,'Modrica - Drvar','19:30:00','Banja Luka','Drvar',2,1,1,1,5,15,'Lasta',1),(7,'Banja Luka - Bihac','15:30:00','Prijedor','Bihac',2,1,1,2,7,18,'Lasta',1),(8,'Banja Luka - Zagreb','13:00:00','Prijedor','Zagreb',2,1,1,2,7,14,'Lasta',1);
/*!40000 ALTER TABLE `ruta` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `serviser`
--

LOCK TABLES `serviser` WRITE;
/*!40000 ALTER TABLE `serviser` DISABLE KEYS */;
INSERT INTO `serviser` VALUES ('1','S Servis','Prijedor',0);
/*!40000 ALTER TABLE `serviser` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `vozac`
--

LOCK TABLES `vozac` WRITE;
/*!40000 ALTER TABLE `vozac` DISABLE KEYS */;
INSERT INTO `vozac` VALUES (1,'Milan','Trivic','1234567891111','1970-09-09','065234123','Adresa br. 24','Lasta',1,1);
/*!40000 ALTER TABLE `vozac` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2024-01-15 17:51:28
