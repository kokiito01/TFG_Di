-- ----------------------------------------------------------------------------
-- MySQL Workbench Migration
-- Migrated Schemata: pruebapepaCopy
-- Source Schemata: pruebapepa
-- Created: Tue Jan 23 12:26:31 2024
-- Workbench Version: 8.0.13
-- ----------------------------------------------------------------------------

SET FOREIGN_KEY_CHECKS = 0;

-- ----------------------------------------------------------------------------
-- Schema pruebapepaCopy
-- ----------------------------------------------------------------------------
DROP SCHEMA IF EXISTS `pruebapepaCopy` ;
CREATE SCHEMA IF NOT EXISTS `pruebapepaCopy` ;

-- ----------------------------------------------------------------------------
-- Table pruebapepaCopy.city
-- ----------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS `pruebapepaCopy`.`city` (
  `idCity` INT(11) NOT NULL AUTO_INCREMENT,
  `countryCode` VARCHAR(2) NOT NULL,
  `cityName` VARCHAR(100) NOT NULL,
  `fkcountry` VARCHAR(2) NOT NULL,
  PRIMARY KEY (`idCity`),
  INDEX `Ciudad` (`cityName` ASC) VISIBLE,
  INDEX `fkcountry_idx` (`fkcountry` ASC) VISIBLE)
ENGINE = InnoDB
AUTO_INCREMENT = 269413
DEFAULT CHARACTER SET = utf8;

-- ----------------------------------------------------------------------------
-- Table pruebapepaCopy.country
-- ----------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS `pruebapepaCopy`.`country` (
  `idCountry` VARCHAR(2) NOT NULL,
  `CountryName` VARCHAR(100) NOT NULL,
  PRIMARY KEY (`idCountry`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

-- ----------------------------------------------------------------------------
-- Table pruebapepaCopy.goals
-- ----------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS `pruebapepaCopy`.`goals` (
  `idgoals` INT(11) NOT NULL,
  `moneyGoal` DECIMAL(9,2) NOT NULL,
  `reason` VARCHAR(45) NOT NULL,
  `dateGoal` DATETIME NOT NULL,
  `recordDate` DATETIME NULL DEFAULT NULL,
  PRIMARY KEY (`idgoals`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;

-- ----------------------------------------------------------------------------
-- Table pruebapepaCopy.income
-- ----------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS `pruebapepaCopy`.`income` (
  `idincome` INT(11) NOT NULL AUTO_INCREMENT,
  `reason` VARCHAR(20) NOT NULL,
  `amount` DECIMAL(9,3) NOT NULL,
  `description` VARCHAR(45) NULL DEFAULT NULL,
  `date` DATETIME NOT NULL,
  `fkicategory` INT(11) NOT NULL,
  PRIMARY KEY (`idincome`),
  INDEX `fkicategory_idx` (`fkicategory` ASC) VISIBLE,
  CONSTRAINT `fkicategory`
    FOREIGN KEY (`fkicategory`)
    REFERENCES `pruebapepaCopy`.`incomecategory` (`idincomeCategory`))
ENGINE = InnoDB
AUTO_INCREMENT = 2
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;

-- ----------------------------------------------------------------------------
-- Table pruebapepaCopy.incomecategory
-- ----------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS `pruebapepaCopy`.`incomecategory` (
  `idincomeCategory` INT(11) NOT NULL AUTO_INCREMENT,
  `icName` VARCHAR(20) NOT NULL,
  PRIMARY KEY (`idincomeCategory`))
ENGINE = InnoDB
AUTO_INCREMENT = 2
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;

-- ----------------------------------------------------------------------------
-- Table pruebapepaCopy.savingsplans
-- ----------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS `pruebapepaCopy`.`savingsplans` (
  `idsavingsPlans` INT(11) NOT NULL,
  `spName` VARCHAR(45) NOT NULL,
  `spBudget` DECIMAL(9,2) NOT NULL,
  PRIMARY KEY (`idsavingsPlans`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;

-- ----------------------------------------------------------------------------
-- Table pruebapepaCopy.spent
-- ----------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS `pruebapepaCopy`.`spent` (
  `idspent` INT(11) NOT NULL AUTO_INCREMENT,
  `reason` VARCHAR(20) CHARACTER SET 'utf8mb4' NOT NULL,
  `amount` DECIMAL(9,3) NOT NULL,
  `description` VARCHAR(45) CHARACTER SET 'utf8mb4' NULL DEFAULT NULL,
  `date` DATETIME NOT NULL,
  `fkscategory` INT(11) NOT NULL,
  PRIMARY KEY (`idspent`),
  INDEX `fkcategory_idx` (`fkscategory` ASC) VISIBLE,
  INDEX `fksccategory_idx` (`fkscategory` ASC) VISIBLE,
  INDEX `fkscategory_idx` (`fkscategory` ASC) VISIBLE,
  CONSTRAINT `fkscategory`
    FOREIGN KEY (`fkscategory`)
    REFERENCES `pruebapepaCopy`.`spentcategory` (`idspentCategory`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

-- ----------------------------------------------------------------------------
-- Table pruebapepaCopy.spentcategory
-- ----------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS `pruebapepaCopy`.`spentcategory` (
  `idspentCategory` INT(11) NOT NULL AUTO_INCREMENT,
  `scName` VARCHAR(20) NOT NULL,
  PRIMARY KEY (`idspentCategory`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;

-- ----------------------------------------------------------------------------
-- Table pruebapepaCopy.themes
-- ----------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS `pruebapepaCopy`.`themes` (
  `idthemes` INT(11) NOT NULL,
  `color` VARCHAR(20) NOT NULL,
  `date` DATETIME NULL DEFAULT NULL,
  `fkuser` INT(11) NULL DEFAULT NULL,
  INDEX `_idx` (`fkuser` ASC) VISIBLE,
  CONSTRAINT `fkuser`
    FOREIGN KEY (`fkuser`)
    REFERENCES `pruebapepaCopy`.`users` (`iduser`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;

-- ----------------------------------------------------------------------------
-- Table pruebapepaCopy.users
-- ----------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS `pruebapepaCopy`.`users` (
  `iduser` INT(11) NOT NULL AUTO_INCREMENT,
  `userName` VARCHAR(45) NOT NULL,
  `surname1` VARCHAR(45) NOT NULL,
  `surname2` VARCHAR(45) NOT NULL,
  `email` VARCHAR(255) NOT NULL,
  `password` VARCHAR(100) NOT NULL,
  `birthday` DATE NOT NULL,
  `fkcountry` INT(11) NOT NULL,
  `gender` ENUM('femenine', 'masculine', 'undefined') NOT NULL,
  `profilImage` TEXT NULL DEFAULT NULL,
  `capital` DECIMAL(9,3) NOT NULL,
  `fkcity` INT(11) NOT NULL,
  `fkgoals` INT(11) NULL DEFAULT NULL,
  `fksplans` INT(11) NULL DEFAULT NULL,
  PRIMARY KEY (`iduser`),
  INDEX `fkgoals_idx` (`fkgoals` ASC) VISIBLE,
  INDEX `fksplans_idx` (`fksplans` ASC) VISIBLE,
  INDEX `fkcity_idx` (`fkcity` ASC) VISIBLE,
  CONSTRAINT `fkcity`
    FOREIGN KEY (`fkcity`)
    REFERENCES `pruebapepaCopy`.`city` (`idCity`),
  CONSTRAINT `fkgoals`
    FOREIGN KEY (`fkgoals`)
    REFERENCES `pruebapepaCopy`.`goals` (`idgoals`),
  CONSTRAINT `fksplans`
    FOREIGN KEY (`fksplans`)
    REFERENCES `pruebapepaCopy`.`savingsplans` (`idsavingsPlans`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;
SET FOREIGN_KEY_CHECKS = 1;