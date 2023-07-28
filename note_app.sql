/*
 Navicat Premium Data Transfer

 Source Server         : Localhost
 Source Server Type    : MySQL
 Source Server Version : 80027
 Source Host           : localhost:2234
 Source Schema         : note_app

 Target Server Type    : MySQL
 Target Server Version : 80027
 File Encoding         : 65001

 Date: 28/07/2023 09:11:07
*/

SET NAMES utf8mb4;
SET FOREIGN_KEY_CHECKS = 0;

-- ----------------------------
-- Table structure for notes
-- ----------------------------
DROP TABLE IF EXISTS `notes`;
CREATE TABLE `notes`  (
  `ID` int NOT NULL AUTO_INCREMENT COMMENT 'ID OF NOTE',
  `USER_ID` int NOT NULL COMMENT 'USER ID OF NOTE',
  `TITLE` varchar(50) CHARACTER SET utf8 COLLATE utf8_turkish_ci NOT NULL COMMENT 'TITLE OF NOTE',
  `DESCRIPTION` varchar(200) CHARACTER SET utf8 COLLATE utf8_turkish_ci NOT NULL COMMENT 'DESCRIPTION OF NOTE',
  PRIMARY KEY (`ID`) USING BTREE,
  UNIQUE INDEX `PK_NOTES_ID_IDX`(`ID`) USING BTREE,
  INDEX `NOTES_USER_ID_IDX`(`USER_ID`) USING BTREE,
  CONSTRAINT `FK_USER_ON_NOTES` FOREIGN KEY (`USER_ID`) REFERENCES `users` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_turkish_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of notes
-- ----------------------------

-- ----------------------------
-- Table structure for users
-- ----------------------------
DROP TABLE IF EXISTS `users`;
CREATE TABLE `users`  (
  `ID` int NOT NULL AUTO_INCREMENT COMMENT 'USER ID',
  `NAME` varchar(50) CHARACTER SET utf8 COLLATE utf8_turkish_ci NOT NULL COMMENT 'NAME OF USER',
  `SURNAME` varchar(50) CHARACTER SET utf8 COLLATE utf8_turkish_ci NOT NULL COMMENT 'SURNAME OF USER',
  `EMAIL` varchar(320) CHARACTER SET utf8 COLLATE utf8_turkish_ci NOT NULL COMMENT 'EMAIL OF USER',
  `PASSWORD` varchar(25) CHARACTER SET utf8 COLLATE utf8_turkish_ci NOT NULL COMMENT 'PASSWORD OF USER',
  PRIMARY KEY (`ID`) USING BTREE,
  UNIQUE INDEX `PK_USERS_ID_IDX`(`ID`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_turkish_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of users
-- ----------------------------
INSERT INTO `users` VALUES (1, 'Admin', 'Surname', 'test@test.com', 'Test123');
INSERT INTO `users` VALUES (3, 'Test User 3', 'Test Surname', 'test@test.com', 'Adilbaba34!');
INSERT INTO `users` VALUES (4, 'Ahmet', 'Veli', 'test@test3.com', '123456');
INSERT INTO `users` VALUES (5, 'New User', 'Surname', 'test@test4.com', '123456789');

SET FOREIGN_KEY_CHECKS = 1;
