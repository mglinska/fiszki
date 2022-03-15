-- MySQL dump 10.13  Distrib 8.0.27, for Win64 (x86_64)
--
-- Host: localhost    Database: fiszki
-- ------------------------------------------------------
-- Server version	8.0.27

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
-- Table structure for table `kolekcja_uzytkownik`
--

DROP TABLE IF EXISTS `kolekcja_uzytkownik`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `kolekcja_uzytkownik` (
  `id_kolekcja` int NOT NULL,
  `login_uzytkownik` varchar(15) NOT NULL,
  `uprawnienia` varchar(50) NOT NULL,
  `czas_nauki` datetime DEFAULT NULL,
  PRIMARY KEY (`id_kolekcja`,`login_uzytkownik`),
  KEY `kolekcja_uzytkownik_ibfk_2` (`login_uzytkownik`),
  CONSTRAINT `kolekcja_uzytkownik_ibfk_1` FOREIGN KEY (`id_kolekcja`) REFERENCES `kolekcja` (`id_kolekcja`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `kolekcja_uzytkownik_ibfk_2` FOREIGN KEY (`login_uzytkownik`) REFERENCES `uzytkownik` (`login_uzytkownik`) ON DELETE RESTRICT ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `kolekcja_uzytkownik`
--

LOCK TABLES `kolekcja_uzytkownik` WRITE;
/*!40000 ALTER TABLE `kolekcja_uzytkownik` DISABLE KEYS */;
/*!40000 ALTER TABLE `kolekcja_uzytkownik` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2022-03-15 10:16:37
