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

-- -----------------------------------------------------
-- Table `autobuskastanica1`.`autoprevoznik`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `autobuskastanica1`.`autoprevoznik` (
  `NazivAutoprevoznika` VARCHAR(100) NOT NULL,
  `Mjesto` VARCHAR(100) NULL DEFAULT NULL,
  `Adresa` VARCHAR(200) NULL DEFAULT NULL,
  `Kontakt` VARCHAR(50) NULL DEFAULT NULL,
  PRIMARY KEY (`NazivAutoprevoznika`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_unicode_ci;


-- -----------------------------------------------------
-- Table `autobuskastanica1`.`garaza`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `autobuskastanica1`.`garaza` (
  `GarazaID` INT(11) NOT NULL,
  `BusID` INT(11) NULL DEFAULT NULL,
  `Lokacija` VARCHAR(200) NULL DEFAULT NULL,
  `BrojMjesta` INT(11) NULL DEFAULT NULL,
  PRIMARY KEY (`GarazaID`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_unicode_ci;


-- -----------------------------------------------------
-- Table `autobuskastanica1`.`ruta`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `autobuskastanica1`.`ruta` (
  `RutaID` INT(11) NOT NULL,
  `Ruta` VARCHAR(200) NULL DEFAULT NULL,
  `VrijemePolaska` TIME NULL DEFAULT NULL,
  `MjestoPolaska` VARCHAR(100) NULL DEFAULT NULL,
  `MjestoDolaska` VARCHAR(100) NULL DEFAULT NULL,
  `BrojStanica` INT(11) NULL DEFAULT NULL,
  `VozacID` INT(11) NULL DEFAULT NULL,
  `KondukterID` INT(11) NULL DEFAULT NULL,
  `StanicaID` INT(11) NULL DEFAULT NULL,
  `Peron` INT(11) NULL DEFAULT NULL,
  `Cijena` FLOAT NULL DEFAULT NULL,
  `NazivAutoprevoznika` VARCHAR(100) NULL DEFAULT NULL,
  `BusID` INT(11) NULL DEFAULT NULL,
  PRIMARY KEY (`RutaID`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_unicode_ci;


-- -----------------------------------------------------
-- Table `autobuskastanica1`.`autobus`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `autobuskastanica1`.`autobus` (
  `BusID` INT(11) NOT NULL AUTO_INCREMENT,
  `NazivAutoprevoznika` VARCHAR(50) NOT NULL,
  `Proizvodjac` VARCHAR(50) NULL DEFAULT NULL,
  `Model` VARCHAR(50) NULL DEFAULT NULL,
  `Kapacitet` INT(11) NULL DEFAULT NULL,
  `RegTablice` VARCHAR(15) NULL DEFAULT NULL,
  `VozacID` INT(11) NULL DEFAULT NULL,
  `GarazaID` INT(11) NOT NULL,
  `RutaID` INT(11) NOT NULL,
  PRIMARY KEY (`BusID`, `RutaID`, `NazivAutoprevoznika`),
  INDEX `Autoprevoznik` (`NazivAutoprevoznika` ASC) VISIBLE,
  INDEX `fk_autobus_garaža1_idx` (`GarazaID` ASC) VISIBLE,
  INDEX `fk_autobus_ruta1_idx` (`RutaID` ASC) VISIBLE,
  CONSTRAINT `autobus_ibfk_1`
    FOREIGN KEY (`NazivAutoprevoznika`)
    REFERENCES `autobuskastanica1`.`autoprevoznik` (`NazivAutoprevoznika`),
  CONSTRAINT `fk_autobus_garaža1`
    FOREIGN KEY (`GarazaID`)
    REFERENCES `autobuskastanica1`.`garaza` (`GarazaID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_autobus_ruta1`
    FOREIGN KEY (`RutaID`)
    REFERENCES `autobuskastanica1`.`ruta` (`RutaID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
AUTO_INCREMENT = 102
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_unicode_ci;


-- -----------------------------------------------------
-- Table `autobuskastanica1`.`autobuskastanica`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `autobuskastanica1`.`autobuskastanica` (
  `StanicaID` INT(11) NOT NULL,
  `NazivStanice` VARCHAR(100) NULL DEFAULT NULL,
  `Mjesto` VARCHAR(100) NULL DEFAULT NULL,
  `BrojPerona` INT(11) NULL DEFAULT NULL,
  `Adresa` VARCHAR(200) NULL DEFAULT NULL,
  `Kontakt` VARCHAR(45) NULL DEFAULT NULL,
  PRIMARY KEY (`StanicaID`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_unicode_ci;


-- -----------------------------------------------------
-- Table `autobuskastanica1`.`radnik`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `autobuskastanica1`.`radnik` (
  `RadnikID` INT(11) NOT NULL,
  `Ime` VARCHAR(50) NULL DEFAULT NULL,
  `Prezime` VARCHAR(50) NULL DEFAULT NULL,
  `DatumRodjenja` DATE NULL DEFAULT NULL,
  `JMBG` CHAR(13) NULL DEFAULT NULL,
  `Kontakt` VARCHAR(50) NULL DEFAULT NULL,
  `Adresa` VARCHAR(200) NULL DEFAULT NULL,
  `StanicaID` INT(11) NOT NULL,
  PRIMARY KEY (`RadnikID`, `StanicaID`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_unicode_ci;


-- -----------------------------------------------------
-- Table `autobuskastanica1`.`putnik`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `autobuskastanica1`.`putnik` (
  `PutnikID` INT(11) NOT NULL AUTO_INCREMENT,
  `Ime` VARCHAR(50) NULL DEFAULT NULL,
  `Prezime` VARCHAR(50) NULL DEFAULT NULL,
  `Kontakt` VARCHAR(50) NULL DEFAULT NULL,
  PRIMARY KEY (`PutnikID`))
ENGINE = InnoDB
AUTO_INCREMENT = 66
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_unicode_ci;


-- -----------------------------------------------------
-- Table `autobuskastanica1`.`karta`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `autobuskastanica1`.`karta` (
  `KartaID` INT(11) NOT NULL AUTO_INCREMENT,
  `Sjediste` INT(11) NULL DEFAULT 1,
  `BusID` INT(11) NULL DEFAULT NULL,
  `Peron` INT(11) NULL DEFAULT NULL,
  `Tip` VARCHAR(50) NULL DEFAULT NULL,
  `DatumPolaska` DATE NULL DEFAULT NULL,
  `VrijemePolaska` TIME NULL DEFAULT NULL,
  `MjestoPolaska` VARCHAR(100) NULL DEFAULT NULL,
  `MjestoDolaska` VARCHAR(100) NULL DEFAULT NULL,
  `VrijemeIzdavanja` TIME NULL DEFAULT NULL,
  `RutaID` INT(11) NOT NULL,
  `PutnikID` INT(11) NOT NULL,
  `RadnikID` INT(11) NOT NULL,
  `StanicaID` INT(11) NOT NULL,
  `Cijena` FLOAT NULL DEFAULT NULL,
  `NazivAutoprevoznika` VARCHAR(100) NOT NULL,
  PRIMARY KEY (`KartaID`, `PutnikID`, `RutaID`, `StanicaID`, `RadnikID`),
  INDEX `RutaID` (`RutaID` ASC) VISIBLE,
  INDEX `PutnikID` (`PutnikID` ASC) VISIBLE,
  INDEX `fk_karta_radnik1_idx` (`RadnikID` ASC, `StanicaID` ASC) VISIBLE,
  INDEX `fk_karta_autoprevoznik1_idx` (`NazivAutoprevoznika` ASC) VISIBLE,
  CONSTRAINT `fk_karta_autoprevoznik1`
    FOREIGN KEY (`NazivAutoprevoznika`)
    REFERENCES `autobuskastanica1`.`autoprevoznik` (`NazivAutoprevoznika`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_karta_radnik1`
    FOREIGN KEY (`RadnikID` , `StanicaID`)
    REFERENCES `autobuskastanica1`.`radnik` (`RadnikID` , `StanicaID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `karta_ibfk_2`
    FOREIGN KEY (`RutaID`)
    REFERENCES `autobuskastanica1`.`ruta` (`RutaID`),
  CONSTRAINT `karta_ibfk_3`
    FOREIGN KEY (`PutnikID`)
    REFERENCES `autobuskastanica1`.`putnik` (`PutnikID`))
ENGINE = InnoDB
AUTO_INCREMENT = 13
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_unicode_ci;


-- -----------------------------------------------------
-- Table `autobuskastanica1`.`kondukter`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `autobuskastanica1`.`kondukter` (
  `KondukterID` INT(11) NOT NULL AUTO_INCREMENT,
  `Ime` VARCHAR(50) NULL DEFAULT NULL,
  `Prezime` VARCHAR(50) NULL DEFAULT NULL,
  `JMBG` VARCHAR(13) NULL DEFAULT NULL,
  `DatumRodjenja` DATE NULL DEFAULT NULL,
  `Kontakt` VARCHAR(50) NULL DEFAULT NULL,
  `Adresa` VARCHAR(200) NULL DEFAULT NULL,
  `NazivAutoprevoznika` VARCHAR(100) NOT NULL,
  `BusID` INT(11) NOT NULL,
  `RutaID` INT(11) NOT NULL,
  PRIMARY KEY (`KondukterID`, `BusID`),
  INDEX `fk_kondukter_autoprevoznik1_idx` (`NazivAutoprevoznika` ASC) VISIBLE,
  INDEX `fk_kondukter_autobus1_idx` (`BusID` ASC) VISIBLE,
  INDEX `fk_kondukter_ruta1_idx` (`RutaID` ASC) VISIBLE,
  CONSTRAINT `fk_kondukter_autobus1`
    FOREIGN KEY (`BusID`)
    REFERENCES `autobuskastanica1`.`autobus` (`BusID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_kondukter_autoprevoznik1`
    FOREIGN KEY (`NazivAutoprevoznika`)
    REFERENCES `autobuskastanica1`.`autoprevoznik` (`NazivAutoprevoznika`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_kondukter_ruta1`
    FOREIGN KEY (`RutaID`)
    REFERENCES `autobuskastanica1`.`ruta` (`RutaID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
AUTO_INCREMENT = 2
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_unicode_ci;


-- -----------------------------------------------------
-- Table `autobuskastanica1`.`serviser`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `autobuskastanica1`.`serviser` (
  `Naziv` VARCHAR(100) NULL DEFAULT NULL,
  `MjestoServisa` VARCHAR(100) NULL DEFAULT NULL,
  `TipServisa` VARCHAR(50) NULL DEFAULT NULL,
  `BusID` INT(11) NOT NULL,
  INDEX `fk_serviser_autobus1_idx` (`BusID` ASC) VISIBLE,
  CONSTRAINT `fk_serviser_autobus1`
    FOREIGN KEY (`BusID`)
    REFERENCES `autobuskastanica1`.`autobus` (`BusID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_unicode_ci;


-- -----------------------------------------------------
-- Table `autobuskastanica1`.`vozac`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `autobuskastanica1`.`vozac` (
  `VozacID` INT(11) NOT NULL AUTO_INCREMENT,
  `Ime` VARCHAR(50) NULL DEFAULT NULL,
  `Prezime` VARCHAR(50) NULL DEFAULT NULL,
  `JMBG` CHAR(13) NULL DEFAULT NULL,
  `DatumRodjenja` DATE NULL DEFAULT NULL,
  `Kontakt` VARCHAR(50) NULL DEFAULT NULL,
  `Adresa` VARCHAR(200) NULL DEFAULT NULL,
  `NazivAutoprevoznika` VARCHAR(100) NOT NULL,
  `BusID` INT(11) NOT NULL,
  `RutaID` INT(11) NOT NULL,
  PRIMARY KEY (`VozacID`, `BusID`),
  INDEX `fk_vozac_autoprevoznik1_idx` (`NazivAutoprevoznika` ASC) VISIBLE,
  INDEX `fk_vozac_autobus1_idx` (`BusID` ASC) VISIBLE,
  INDEX `fk_vozac_ruta1_idx` (`RutaID` ASC) VISIBLE,
  CONSTRAINT `fk_vozac_autobus1`
    FOREIGN KEY (`BusID`)
    REFERENCES `autobuskastanica1`.`autobus` (`BusID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_vozac_autoprevoznik1`
    FOREIGN KEY (`NazivAutoprevoznika`)
    REFERENCES `autobuskastanica1`.`autoprevoznik` (`NazivAutoprevoznika`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_vozac_ruta1`
    FOREIGN KEY (`RutaID`)
    REFERENCES `autobuskastanica1`.`ruta` (`RutaID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
AUTO_INCREMENT = 2
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_unicode_ci;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
