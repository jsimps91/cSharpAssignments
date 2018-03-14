-- MySQL Script generated by MySQL Workbench
-- Tue Jan 23 09:33:04 2018
-- Model: New Model    Version: 1.0
-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL,ALLOW_INVALID_DATES';

-- -----------------------------------------------------
-- Schema demo
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema demo
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `demo` DEFAULT CHARACTER SET utf8 ;
USE `demo` ;

-- -----------------------------------------------------
-- Table `demo`.`cohort`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `demo`.`cohort` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `month` VARCHAR(45) NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `demo`.`students`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `demo`.`students` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(45) NULL,
  `cohort_id` INT NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_students_cohort_idx` (`cohort_id` ASC),
  CONSTRAINT `fk_students_cohort`
    FOREIGN KEY (`cohort_id`)
    REFERENCES `demo`.`cohort` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
