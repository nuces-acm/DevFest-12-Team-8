CREATE DATABASE  IF NOT EXISTS `hpdb` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `hpdb`;
-- MySQL dump 10.13  Distrib 5.5.16, for Win32 (x86)
--
-- Host: localhost    Database: hpdb
-- ------------------------------------------------------
-- Server version	5.5.22

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `patient_diagnosis`
--

DROP TABLE IF EXISTS `patient_diagnosis`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `patient_diagnosis` (
  `did` bigint(20) NOT NULL,
  `pid` bigint(20) NOT NULL,
  `aid` bigint(20) NOT NULL,
  `diagnoses` varchar(45) NOT NULL,
  PRIMARY KEY (`did`),
  KEY `fk_diag_pid` (`pid`),
  KEY `fk_diag_aid` (`aid`),
  CONSTRAINT `fk_diag_aid` FOREIGN KEY (`aid`) REFERENCES `appointments` (`aid`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_diag_pid` FOREIGN KEY (`pid`) REFERENCES `patients` (`pid`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `users`
--

DROP TABLE IF EXISTS `users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `users` (
  `uid` bigint(20) NOT NULL,
  `username` varchar(25) NOT NULL,
  `password` varchar(25) NOT NULL,
  `user_type` tinyint(4) NOT NULL COMMENT '.',
  PRIMARY KEY (`uid`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `appointments`
--

DROP TABLE IF EXISTS `appointments`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `appointments` (
  `aid` bigint(20) NOT NULL,
  `pid` bigint(20) NOT NULL,
  `dept_id` bigint(20) NOT NULL,
  `appointment_time` bigint(20) NOT NULL,
  `status` tinyint(4) NOT NULL COMMENT 'Status: 0=Pending; 1=Done; 2=Cancel',
  `status_change_time` bigint(20) NOT NULL,
  `dr_id` bigint(20) DEFAULT NULL,
  PRIMARY KEY (`aid`),
  KEY `fk_app_pid` (`pid`),
  KEY `fk_app_dept_id` (`dept_id`),
  KEY `fk_app_dr_id` (`dr_id`),
  CONSTRAINT `fk_app_dept_id` FOREIGN KEY (`dept_id`) REFERENCES `hospital_departments` (`did`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_app_dr_id` FOREIGN KEY (`dr_id`) REFERENCES `doctors` (`dr_id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_app_pid` FOREIGN KEY (`pid`) REFERENCES `patients` (`pid`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `hospital_departments`
--

DROP TABLE IF EXISTS `hospital_departments`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `hospital_departments` (
  `did` bigint(20) NOT NULL,
  `hid` int(11) NOT NULL,
  `department_name` varchar(45) NOT NULL,
  PRIMARY KEY (`did`),
  KEY `fk_hd_hid` (`hid`),
  CONSTRAINT `fk_hd_hid` FOREIGN KEY (`hid`) REFERENCES `hospitals` (`hid`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `hospital_admins`
--

DROP TABLE IF EXISTS `hospital_admins`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `hospital_admins` (
  `uid` bigint(20) NOT NULL,
  `hid` int(11) NOT NULL,
  PRIMARY KEY (`uid`,`hid`),
  KEY `fk_ha_uid` (`uid`),
  KEY `fk_ha_hid` (`hid`),
  CONSTRAINT `fk_ha_hid` FOREIGN KEY (`hid`) REFERENCES `hospitals` (`hid`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_ha_uid` FOREIGN KEY (`uid`) REFERENCES `generic_user_profiles` (`uid`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `doctors`
--

DROP TABLE IF EXISTS `doctors`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `doctors` (
  `dr_id` bigint(20) NOT NULL,
  `dept_id` bigint(20) NOT NULL,
  `qualification` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`dr_id`),
  KEY `fk_doc_did` (`dr_id`),
  KEY `fk_dept_id` (`dept_id`),
  CONSTRAINT `fk_dept_id` FOREIGN KEY (`dept_id`) REFERENCES `hospital_departments` (`did`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_doc_did` FOREIGN KEY (`dr_id`) REFERENCES `generic_user_profiles` (`uid`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `generic_user_profiles`
--

DROP TABLE IF EXISTS `generic_user_profiles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `generic_user_profiles` (
  `uid` bigint(20) NOT NULL,
  `full_name` varchar(80) DEFAULT NULL,
  `dob` bigint(20) DEFAULT NULL,
  `email` varchar(45) DEFAULT NULL,
  `home_address` varchar(150) DEFAULT NULL,
  `contact_number` varchar(20) DEFAULT NULL,
  `gender` tinyint(4) DEFAULT NULL COMMENT '0 = Male; 1 = Female; 2 = SheMale',
  PRIMARY KEY (`uid`),
  KEY `fk_gup_uid` (`uid`),
  CONSTRAINT `fk_gup_uid` FOREIGN KEY (`uid`) REFERENCES `users` (`uid`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `hospitals`
--

DROP TABLE IF EXISTS `hospitals`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `hospitals` (
  `hid` int(11) NOT NULL,
  `hospital_name` varchar(40) NOT NULL,
  `Region` varchar(45) NOT NULL,
  `District` varchar(45) NOT NULL,
  `Province` varchar(45) NOT NULL,
  PRIMARY KEY (`hid`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `patients`
--

DROP TABLE IF EXISTS `patients`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `patients` (
  `pid` bigint(20) NOT NULL,
  `bloodGroup` tinyint(4) NOT NULL,
  KEY `fk_pt_pid` (`pid`),
  CONSTRAINT `fk_pt_pid` FOREIGN KEY (`pid`) REFERENCES `generic_user_profiles` (`uid`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `patient_treatment`
--

DROP TABLE IF EXISTS `patient_treatment`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `patient_treatment` (
  `did` bigint(20) NOT NULL,
  `treatement` varchar(500) NOT NULL,
  KEY `fk_pt_pd` (`did`),
  CONSTRAINT `fk_pt_pd` FOREIGN KEY (`did`) REFERENCES `patient_diagnosis` (`did`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2012-04-01 12:36:16
