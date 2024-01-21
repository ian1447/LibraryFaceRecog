/*
SQLyog Ultimate v9.62 
MySQL - 5.6.37-log : Database - librarymanagement
*********************************************************************
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
CREATE DATABASE /*!32312 IF NOT EXISTS*/`librarymanagement` /*!40100 DEFAULT CHARACTER SET utf8 */;

USE `librarymanagement`;

/*Table structure for table `users` */

DROP TABLE IF EXISTS `users`;

CREATE TABLE `users` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `username` varchar(255) NOT NULL,
  `password` varchar(255) NOT NULL,
  `is_active` tinyint(1) NOT NULL DEFAULT '1',
  `privilege` enum('Bisu-Admin','Congressional-Admin','super-admin') DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;

/*Data for the table `users` */

insert  into `users`(`id`,`username`,`password`,`is_active`,`privilege`) values (1,'admin','d033e22ae348aeb5660fc2140aec35850c4da997',1,'super-admin'),(2,'test','d033e22ae348aeb5660fc2140aec35850c4da997',0,'super-admin'),(3,'admin-bisu','da39a3ee5e6b4b0d3255bfef95601890afd80709',1,'Bisu-Admin');

/* Procedure structure for procedure `sp_get_all_users` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_get_all_users` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`system_admin`@`%` PROCEDURE `sp_get_all_users`(
	_username varchar (255)
    )
BEGIN
	SELECT * FROM `users` u WHERE u.`username` <> _username;
    END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_users_add` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_users_add` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`system_admin`@`%` PROCEDURE `sp_users_add`(
	_username varchar (255),
	_password VARCHAR (255),
	_privilege varchar (255)
    )
BEGIN
	INSERT INTO `users` (username, `password`, privilege)
	VALUES (_username, SHA1(_password), _privilege); 
    END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_users_edit` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_users_edit` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`system_admin`@`%` PROCEDURE `sp_users_edit`(
	_username varchar (255),
	_password varchar (255),
	_privilege varchar (255),
	_id int (11)
    )
BEGIN
	UPDATE users SET username = _username,  `password` = SHA1(_password), privilege = _privilege
	WHERE id = _id;
    END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_users_login` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_users_login` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`system_admin`@`%` PROCEDURE `sp_users_login`(
	_username varchar (255),
	_password varchar (255)
    )
BEGIN
	SELECT * FROM `users` WHERE username = _username AND `password` = SHA1(_password) AND is_active =1;
    END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_user_update_active_status` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_user_update_active_status` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`system_admin`@`%` PROCEDURE `sp_user_update_active_status`(
	_id int (11),
	_mode tinyint(1)
    )
BEGIN
	UPDATE users SET is_active = _mode WHERE id = _id;
    END */$$
DELIMITER ;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
