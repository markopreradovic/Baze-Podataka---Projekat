-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema mydb
-- -----------------------------------------------------
-- -----------------------------------------------------
-- Schema autobuskastanica1
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema autobuskastanica1
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `autobuskastanica1` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci ;
USE `autobuskastanica1` ;
USE `autobuskastanica1` ;

-- -----------------------------------------------------
-- Placeholder table for view `autobuskastanica1`.`izdatekarte`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `autobuskastanica1`.`izdatekarte` (`KartaID` INT, `BusID` INT, `Tip` INT, `DatumPolaska` INT, `VrijemePolaska` INT, `MjestoPolaska` INT, `MjestoDolaska` INT, `VrijemeIzdavanja` INT, `PutnikID` INT, `RadnikID` INT, `StanicaID` INT, `NazivAutoprevoznika` INT, `Cijena` INT);

-- -----------------------------------------------------
-- Placeholder table for view `autobuskastanica1`.`putnici`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `autobuskastanica1`.`putnici` (`PutnikID` INT, `Ime` INT, `Prezime` INT, `Kontakt` INT);

-- -----------------------------------------------------
-- Placeholder table for view `autobuskastanica1`.`radnici`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `autobuskastanica1`.`radnici` (`RadnikID` INT, `Ime` INT, `Prezime` INT, `DatumRodjenja` INT, `JMBG` INT, `Kontakt` INT, `Adresa` INT, `StanicaID` INT);

-- -----------------------------------------------------
-- Placeholder table for view `autobuskastanica1`.`stanice`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `autobuskastanica1`.`stanice` (`StanicaID` INT, `NazivStanice` INT, `Mjesto` INT, `BrojPerona` INT, `Adresa` INT, `Kontakt` INT);

-- -----------------------------------------------------
-- procedure ObrisiKartu
-- -----------------------------------------------------

DELIMITER $$
USE `autobuskastanica1`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `ObrisiKartu`(IN KartaID1 INT)
BEGIN
    DECLARE PutnikID1 INT;
    IF NOT EXISTS (SELECT * FROM Karta WHERE KartaID = KartaID1) THEN
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'KartaID ne postoji.';
    ELSE
        SELECT PutnikID INTO PutnikID1 FROM Karta WHERE KartaID = KartaID1;
        DELETE FROM Karta WHERE KartaID = KartaID1;
        DELETE FROM Putnik WHERE PutnikID = PutnikID1;
        SELECT 'Podaci obrisani' AS Status;
    END IF;
END$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure UnesiKartu
-- -----------------------------------------------------

DELIMITER $$
USE `autobuskastanica1`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `UnesiKartu`(
    IN Sjediste INT,
    IN BusID INT,
    IN Peron INT,
    IN Tip VARCHAR(50),
    IN DatumPolaska DATE,
    IN VrijemePolaska TIME,
    IN MjestoPolaska VARCHAR(100),
    IN MjestoDolaska VARCHAR(100),
    IN VrijemeIzdavanja TIME,
    IN RutaID INT,
    IN PutnikID INT,
    IN Cijena INT,
    IN RadnikID INT,
    IN StanicaID INT,
    IN NazivAutoprevoznika VARCHAR(100)
)
BEGIN
    INSERT INTO karta (
        Sjediste,
        BusID,
        Peron,
        Tip,
        DatumPolaska,
        VrijemePolaska,
        MjestoPolaska,
        MjestoDolaska,
        VrijemeIzdavanja,
        RutaID,
        PutnikID,
        Cijena,
        RadnikID,
        StanicaID,
        NazivAutoprevoznika
    )
    VALUES (
        Sjediste,
        BusID,
        Peron,
        Tip,
        DatumPolaska,
        VrijemePolaska,
        MjestoPolaska,
        MjestoDolaska,
        VrijemeIzdavanja,
        RutaID,
        PutnikID,
        Cijena,
        RadnikID,
        StanicaID,
        NazivAutoprevoznika
    );
END$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure UnesiRadnika
-- -----------------------------------------------------

DELIMITER $$
USE `autobuskastanica1`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `UnesiRadnika`(
    IN RadnikID1 INT,
    IN Ime1 VARCHAR(50),
    IN Prezime1 VARCHAR(50),
    IN DatumRodjenja1 DATE,
    IN JMBG1 CHAR(13),
    IN Kontakt1 VARCHAR(50),
    IN Adresa1 VARCHAR(200),
    IN StanicaID1 INT
)
BEGIN
    INSERT INTO radnik (RadnikID, Ime, Prezime, DatumRodjenja, JMBG, Kontakt, Adresa, StanicaID)
    VALUES (RadnikID1, Ime1, Prezime1, DatumRodjenja1, JMBG1, Kontakt1, Adresa1, StanicaID1);
END$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure UnesiRutu
-- -----------------------------------------------------

DELIMITER $$
USE `autobuskastanica1`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `UnesiRutu`(
    IN RutaID1 INT,
    IN Ruta1 VARCHAR(100),
    IN VrijemePolaska1 TIME,
    IN MjestoPolaska1 VARCHAR(100),
    IN MjestoDolaska1 VARCHAR(100),
    IN BrojStanica1 INT,
    IN VozacID1 INT,
    IN KondukterID1 INT,
    IN BusID1 INT,
    IN StanicaID1 INT,
    IN Cijena1 INT,
    IN NazivAutoprevoznika1 VARCHAR(100),
    IN Peron1 INT
)
BEGIN
    DECLARE brojRedova INT;
    SELECT COUNT(*) INTO brojRedova FROM ruta WHERE RutaID = RutaID1;
    IF brojRedova > 0 THEN
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Ruta sa istim RutaID već postoji.';
    ELSE
        INSERT INTO ruta (
            RutaID,
            Ruta,
            VrijemePolaska,
            MjestoPolaska,
            MjestoDolaska,
            BrojStanica,
            VozacID,
            KondukterID,
            BusID,
            StanicaID,
            Cijena,
            NazivAutoprevoznika,
            Peron
        )
        VALUES (
            RutaID1,
            Ruta1,
            VrijemePolaska1,
            MjestoPolaska1,
            MjestoDolaska1,
            BrojStanica1,
            VozacID1,
            KondukterID1,
            BusID1,
            StanicaID1,
            Cijena1,
            NazivAutoprevoznika1,
            Peron1
        );
    END IF;
END$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure UnesiStanicu
-- -----------------------------------------------------

DELIMITER $$
USE `autobuskastanica1`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `UnesiStanicu`(
    IN StanicaID1 INT,
    IN NazivStanice1 VARCHAR(255),
    IN Mjesto1 VARCHAR(255),
    IN BrojPerona1 INT,
    IN Adresa1 VARCHAR(255),
    IN Kontakt1 VARCHAR(20)
)
BEGIN
    INSERT INTO autobuskastanica (StanicaID,NazivStanice, Mjesto, BrojPerona, Adresa, Kontakt)
    VALUES (StanicaID1,NazivStanice1, Mjesto1, BrojPerona1, Adresa1, Kontakt1);
END$$

DELIMITER ;

-- -----------------------------------------------------
-- View `autobuskastanica1`.`izdatekarte`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `autobuskastanica1`.`izdatekarte`;
USE `autobuskastanica1`;
CREATE  OR REPLACE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `autobuskastanica1`.`izdatekarte` AS select `autobuskastanica1`.`karta`.`KartaID` AS `KartaID`,`autobuskastanica1`.`karta`.`BusID` AS `BusID`,`autobuskastanica1`.`karta`.`Tip` AS `Tip`,`autobuskastanica1`.`karta`.`DatumPolaska` AS `DatumPolaska`,`autobuskastanica1`.`karta`.`VrijemePolaska` AS `VrijemePolaska`,`autobuskastanica1`.`karta`.`MjestoPolaska` AS `MjestoPolaska`,`autobuskastanica1`.`karta`.`MjestoDolaska` AS `MjestoDolaska`,`autobuskastanica1`.`karta`.`VrijemeIzdavanja` AS `VrijemeIzdavanja`,`autobuskastanica1`.`karta`.`PutnikID` AS `PutnikID`,`autobuskastanica1`.`karta`.`RadnikID` AS `RadnikID`,`autobuskastanica1`.`karta`.`StanicaID` AS `StanicaID`,`autobuskastanica1`.`karta`.`NazivAutoprevoznika` AS `NazivAutoprevoznika`,`autobuskastanica1`.`karta`.`Cijena` AS `Cijena` from `autobuskastanica1`.`karta`;

-- -----------------------------------------------------
-- View `autobuskastanica1`.`putnici`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `autobuskastanica1`.`putnici`;
USE `autobuskastanica1`;
CREATE  OR REPLACE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `autobuskastanica1`.`putnici` AS select `autobuskastanica1`.`putnik`.`PutnikID` AS `PutnikID`,`autobuskastanica1`.`putnik`.`Ime` AS `Ime`,`autobuskastanica1`.`putnik`.`Prezime` AS `Prezime`,`autobuskastanica1`.`putnik`.`Kontakt` AS `Kontakt` from `autobuskastanica1`.`putnik`;

-- -----------------------------------------------------
-- View `autobuskastanica1`.`radnici`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `autobuskastanica1`.`radnici`;
USE `autobuskastanica1`;
CREATE  OR REPLACE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `autobuskastanica1`.`radnici` AS select `r`.`RadnikID` AS `RadnikID`,`r`.`Ime` AS `Ime`,`r`.`Prezime` AS `Prezime`,`r`.`DatumRodjenja` AS `DatumRodjenja`,`r`.`JMBG` AS `JMBG`,`r`.`Kontakt` AS `Kontakt`,`r`.`Adresa` AS `Adresa`,`r`.`StanicaID` AS `StanicaID` from `autobuskastanica1`.`radnik` `r`;

-- -----------------------------------------------------
-- View `autobuskastanica1`.`stanice`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `autobuskastanica1`.`stanice`;
USE `autobuskastanica1`;
CREATE  OR REPLACE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `autobuskastanica1`.`stanice` AS select `autobuskastanica1`.`autobuskastanica`.`StanicaID` AS `StanicaID`,`autobuskastanica1`.`autobuskastanica`.`NazivStanice` AS `NazivStanice`,`autobuskastanica1`.`autobuskastanica`.`Mjesto` AS `Mjesto`,`autobuskastanica1`.`autobuskastanica`.`BrojPerona` AS `BrojPerona`,`autobuskastanica1`.`autobuskastanica`.`Adresa` AS `Adresa`,`autobuskastanica1`.`autobuskastanica`.`Kontakt` AS `Kontakt` from `autobuskastanica1`.`autobuskastanica`;
USE `autobuskastanica1`;

DELIMITER $$
USE `autobuskastanica1`$$
CREATE
DEFINER=`root`@`localhost`
TRIGGER `autobuskastanica1`.`ValidacijaRuteTrigger`
BEFORE INSERT ON `autobuskastanica1`.`ruta`
FOR EACH ROW
BEGIN
    DECLARE errorMessage VARCHAR(255);

    IF NEW.RutaID IS NULL OR NEW.Ruta = '' OR NEW.VrijemePolaska IS NULL OR NEW.MjestoPolaska = '' OR NEW.MjestoDolaska = '' 
        OR NEW.BrojStanica IS NULL OR NEW.VozacID IS NULL OR NEW.KondukterID IS NULL OR NEW.BusID IS NULL 
        OR NEW.StanicaID IS NULL OR NEW.Cijena IS NULL OR NEW.NazivAutoprevoznika = '' OR NEW.Peron IS NULL THEN
        SET errorMessage = 'Svi obavezni podaci moraju biti uneti i ispravno popunjeni.';
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = errorMessage;
    END IF;
END$$

USE `autobuskastanica1`$$
CREATE
DEFINER=`root`@`localhost`
TRIGGER `autobuskastanica1`.`ValidacijaStanicaTrigger`
BEFORE INSERT ON `autobuskastanica1`.`autobuskastanica`
FOR EACH ROW
BEGIN
    DECLARE errorMessage VARCHAR(255);
    IF NEW.NazivStanice IS NULL OR NEW.NazivStanice = '' OR NEW.Mjesto IS NULL OR NEW.Mjesto = '' 
        OR NEW.BrojPerona IS NULL OR NEW.Adresa IS NULL OR NEW.Adresa = '' OR NEW.Kontakt IS NULL OR NEW.Kontakt = '' THEN
        SET errorMessage = 'Svi podaci moraju biti uneseni';
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = errorMessage;
    END IF;
END$$

USE `autobuskastanica1`$$
CREATE
DEFINER=`root`@`localhost`
TRIGGER `autobuskastanica1`.`ValidacijaRadnikaTrigger`
BEFORE INSERT ON `autobuskastanica1`.`radnik`
FOR EACH ROW
BEGIN
    DECLARE errorMessage VARCHAR(255);
    IF NEW.RadnikID IS NOT NULL AND EXISTS (SELECT 1 FROM radnik WHERE RadnikID = NEW.RadnikID) THEN
        SET errorMessage = 'Radnik sa datim RadnikID već postoji.';
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = errorMessage;
    END IF;
    IF NEW.Ime IS NULL OR NEW.Prezime IS NULL OR NEW.DatumRodjenja IS NULL OR NEW.JMBG IS NULL 
    OR NEW.Kontakt IS NULL OR NEW.Adresa IS NULL OR NEW.StanicaID IS NULL 
    OR NEW.Ime = '' OR NEW.Prezime = '' OR NEW.DatumRodjenja = '' OR NEW.JMBG = '' OR NEW.Kontakt = '' OR NEW.Adresa = '' THEN
        SET errorMessage = 'Svi podaci moraju biti uneseni.';
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = errorMessage;
    END IF;
END$$


DELIMITER ;

SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
