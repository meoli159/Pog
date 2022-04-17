-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Apr 17, 2022 at 03:59 PM
-- Server version: 10.4.22-MariaDB
-- PHP Version: 8.1.2

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `pog`
--

-- --------------------------------------------------------

--
-- Table structure for table `aspnetusers`
--

CREATE TABLE `aspnetusers` (
  `Id` varchar(255) NOT NULL,
  `FirstName` longtext NOT NULL,
  `LastName` longtext NOT NULL,
  `Birthday` datetime(6) DEFAULT NULL,
  `Gender` int(11) NOT NULL,
  `Address` longtext DEFAULT NULL,
  `DepartmentId` int(11) DEFAULT NULL,
  `UserName` varchar(256) DEFAULT NULL,
  `NormalizedUserName` varchar(256) DEFAULT NULL,
  `Email` varchar(256) DEFAULT NULL,
  `NormalizedEmail` varchar(256) DEFAULT NULL,
  `EmailConfirmed` tinyint(1) NOT NULL,
  `PasswordHash` longtext DEFAULT NULL,
  `SecurityStamp` longtext DEFAULT NULL,
  `ConcurrencyStamp` longtext DEFAULT NULL,
  `PhoneNumber` longtext DEFAULT NULL,
  `PhoneNumberConfirmed` tinyint(1) NOT NULL,
  `TwoFactorEnabled` tinyint(1) NOT NULL,
  `LockoutEnd` datetime(6) DEFAULT NULL,
  `LockoutEnabled` tinyint(1) NOT NULL,
  `AccessFailedCount` int(11) NOT NULL,
  `Role` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `aspnetusers`
--

INSERT INTO `aspnetusers` (`Id`, `FirstName`, `LastName`, `Birthday`, `Gender`, `Address`, `DepartmentId`, `UserName`, `NormalizedUserName`, `Email`, `NormalizedEmail`, `EmailConfirmed`, `PasswordHash`, `SecurityStamp`, `ConcurrencyStamp`, `PhoneNumber`, `PhoneNumberConfirmed`, `TwoFactorEnabled`, `LockoutEnd`, `LockoutEnabled`, `AccessFailedCount`, `Role`) VALUES
('30d71845-a886-4197-8100-da9bf7ea8adc', 'Staff', 'Staff', '1997-05-17 00:00:00.000000', 1, '123/123, Binh Thanh District', 2, 'Staff@gmail.com', 'STAFF@GMAIL.COM', 'Staff@gmail.com', 'STAFF@GMAIL.COM', 1, 'AQAAAAEAACcQAAAAEHhK+YCwrRHRU0aK0tejdIoHu+L7vil67ZH02MTKJ6HMAjLysoE23Xl+BQvcGlNEPA==', '7WDZH6UEQG5JK3A6HJMQV5RAZP3ZS2SY', '035aee98-ee73-4c00-8fd4-ce87bea9c303', NULL, 0, 0, NULL, 1, 0, NULL),
('b74ddd14-6340-4840-95c2-db12554843e5', 'Admin', 'Admin', NULL, 0, NULL, NULL, 'admin@gmail.com', 'ADMIN@GMAIL.COM', 'admin@gmail.com', 'ADMIN@GMAIL.COM', 1, 'AQAAAAEAACcQAAAAEO4VH+iHiqX5vn83W8iNN3b0ICITS+WntFgRJd8j83L+Z+TI3MRoBx8OUJcqT6XqUQ==', '4e6bc8a6-8784-47ea-bbc5-cbbf835aed40', 'e08e079f-3173-4e89-80e2-0384008f6888', '1234567890', 0, 0, NULL, 1, 0, NULL),
('d8450883-27be-4e08-9615-d6365e1a9554', 'QAmanager', 'QAmanager', '1981-05-17 00:00:00.000000', 0, '123/123, Binh Thanh District', 1, 'qamanager@gmail.com', 'QAMANAGER@GMAIL.COM', 'qamanager@gmail.com', 'QAMANAGER@GMAIL.COM', 1, 'AQAAAAEAACcQAAAAEBsMhs894oeivmHRFRZnOCAJhzitCQVWtl9gjtkjLKecTezc6YFu1XDxCUwNk00ZaA==', '6F3VAUW3IYRTRDQZKB4K7R3VDJLDH3JH', '4a18de28-5ca8-4782-b48c-9c6419809b55', NULL, 0, 0, NULL, 1, 0, NULL),
('dff332cd-e350-442e-987a-77c3c8bc794f', 'QAcordinoor', 'QAcordinoor', '2014-06-17 00:00:00.000000', 0, '33/123, Tan Binh District', 1, 'qacordinoor@gmail.com', 'QACORDINOOR@GMAIL.COM', 'qacordinoor@gmail.com', 'QACORDINOOR@GMAIL.COM', 1, 'AQAAAAEAACcQAAAAEI5r+wmmkCMXrpZzizZurbpBWhRZssKBWaaXmScK/c06oTEnQHkVk09WLCx9BH9E0g==', 'OMECKIKCSWUMKY757MI5BTTBJ7RXBN6M', 'd3cd48dd-fa5f-4d45-9d49-121adb36ad2d', NULL, 0, 0, NULL, 1, 0, NULL);

-- --------------------------------------------------------

--
-- Table structure for table `categories`
--

CREATE TABLE `categories` (
  `Id` int(11) NOT NULL,
  `Name` longtext NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `categories`
--

INSERT INTO `categories` (`Id`, `Name`) VALUES
(5, 'IT'),
(6, 'Class'),
(7, 'Library ');

-- --------------------------------------------------------

--
-- Table structure for table `comments`
--

CREATE TABLE `comments` (
  `Id` int(11) NOT NULL,
  `CommentText` longtext NOT NULL,
  `DateCreate` datetime(6) DEFAULT NULL,
  `IsAnonymous` tinyint(1) NOT NULL,
  `UserId` varchar(255) DEFAULT NULL,
  `TopicDueDateId` int(11) NOT NULL,
  `TopicId` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `comments`
--

INSERT INTO `comments` (`Id`, `CommentText`, `DateCreate`, `IsAnonymous`, `UserId`, `TopicDueDateId`, `TopicId`) VALUES
(2, 'aaaa', '2022-04-17 00:28:04.508585', 1, 'b74ddd14-6340-4840-95c2-db12554843e5', 1, NULL),
(3, 'wow', '2022-04-17 16:39:53.702054', 0, '30d71845-a886-4197-8100-da9bf7ea8adc', 1, NULL),
(5, 'asfdsdfsad', '2022-04-17 17:34:39.428750', 1, 'b74ddd14-6340-4840-95c2-db12554843e5', 1, NULL),
(6, 'tesst', '2022-04-17 20:05:39.834189', 0, 'b74ddd14-6340-4840-95c2-db12554843e5', 1, NULL),
(7, 'test2', '2022-04-17 20:05:50.454873', 1, 'b74ddd14-6340-4840-95c2-db12554843e5', 1, NULL),
(8, 'aaa', '2022-04-17 20:06:23.282842', 0, 'b74ddd14-6340-4840-95c2-db12554843e5', 1, NULL);

-- --------------------------------------------------------

--
-- Table structure for table `departments`
--

CREATE TABLE `departments` (
  `Id` int(11) NOT NULL,
  `DepartmentName` longtext NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `departments`
--

INSERT INTO `departments` (`Id`, `DepartmentName`) VALUES
(1, 'IT'),
(2, 'Business'),
(3, 'Graphic'),
(4, 'Library');

-- --------------------------------------------------------

--
-- Table structure for table `qa`
--

CREATE TABLE `qa` (
  `Id` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `role`
--

CREATE TABLE `role` (
  `Id` varchar(255) NOT NULL,
  `Name` varchar(256) DEFAULT NULL,
  `NormalizedName` varchar(256) DEFAULT NULL,
  `ConcurrencyStamp` longtext DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `role`
--

INSERT INTO `role` (`Id`, `Name`, `NormalizedName`, `ConcurrencyStamp`) VALUES
('ADMIN', 'ADMIN', NULL, 'b8c201ea-40bf-4e92-ac00-c827db964ce2'),
('QACOORDINATOR', 'QACOORDINATOR', NULL, 'a248f0a4-8e8f-4c37-b150-8a262836eef6'),
('QAMANAGER', 'QAMANAGER', NULL, '5ee73e27-2151-4807-a897-bed6338bb0d0'),
('STAFF', 'STAFF', NULL, 'cad70ce3-9981-433a-b4a1-4f1c23594bcc');

-- --------------------------------------------------------

--
-- Table structure for table `roleclaims`
--

CREATE TABLE `roleclaims` (
  `Id` int(11) NOT NULL,
  `RoleId` varchar(255) NOT NULL,
  `ClaimType` longtext DEFAULT NULL,
  `ClaimValue` longtext DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `staff`
--

CREATE TABLE `staff` (
  `Id` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `topicduedates`
--

CREATE TABLE `topicduedates` (
  `Id` int(11) NOT NULL,
  `CreateDate` datetime(6) NOT NULL,
  `DueDate` datetime(6) NOT NULL,
  `FinalDate` datetime(6) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `topicduedates`
--

INSERT INTO `topicduedates` (`Id`, `CreateDate`, `DueDate`, `FinalDate`) VALUES
(1, '0001-01-01 00:00:00.000000', '2022-04-20 00:25:00.000000', '2022-04-20 00:25:00.000000'),
(5, '0001-01-01 00:00:00.000000', '2022-04-13 20:02:00.000000', '2022-04-15 20:03:00.000000');

-- --------------------------------------------------------

--
-- Table structure for table `topics`
--

CREATE TABLE `topics` (
  `Id` int(11) NOT NULL,
  `Name` longtext NOT NULL,
  `Description` longtext NOT NULL,
  `IsAnonymous` tinyint(1) NOT NULL,
  `DateCreate` datetime(6) NOT NULL,
  `UserId` varchar(255) DEFAULT NULL,
  `CategoryId` int(11) NOT NULL,
  `TopicAttachments` longtext DEFAULT NULL,
  `TopicAttachmentName` longtext DEFAULT NULL,
  `TermAndCondition` tinyint(1) NOT NULL,
  `TopicDueDateId` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `userclaims`
--

CREATE TABLE `userclaims` (
  `Id` int(11) NOT NULL,
  `UserId` varchar(255) NOT NULL,
  `ClaimType` longtext DEFAULT NULL,
  `ClaimValue` longtext DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `userlogins`
--

CREATE TABLE `userlogins` (
  `LoginProvider` varchar(255) NOT NULL,
  `ProviderKey` varchar(255) NOT NULL,
  `ProviderDisplayName` longtext DEFAULT NULL,
  `UserId` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `userroles`
--

CREATE TABLE `userroles` (
  `UserId` varchar(255) NOT NULL,
  `RoleId` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `userroles`
--

INSERT INTO `userroles` (`UserId`, `RoleId`) VALUES
('30d71845-a886-4197-8100-da9bf7ea8adc', 'STAFF'),
('b74ddd14-6340-4840-95c2-db12554843e5', 'ADMIN'),
('d8450883-27be-4e08-9615-d6365e1a9554', 'QAMANAGER'),
('dff332cd-e350-442e-987a-77c3c8bc794f', 'QACOORDINATOR');

-- --------------------------------------------------------

--
-- Table structure for table `usertokens`
--

CREATE TABLE `usertokens` (
  `UserId` varchar(255) NOT NULL,
  `LoginProvider` varchar(255) NOT NULL,
  `Name` varchar(255) NOT NULL,
  `Value` longtext DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `__efmigrationshistory`
--

CREATE TABLE `__efmigrationshistory` (
  `MigrationId` varchar(150) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `__efmigrationshistory`
--

INSERT INTO `__efmigrationshistory` (`MigrationId`, `ProductVersion`) VALUES
('20220415062619_dtb8', '6.0.3'),
('20220415185000_abc1', '6.0.3');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `aspnetusers`
--
ALTER TABLE `aspnetusers`
  ADD PRIMARY KEY (`Id`),
  ADD UNIQUE KEY `UserNameIndex` (`NormalizedUserName`),
  ADD KEY `EmailIndex` (`NormalizedEmail`),
  ADD KEY `IX_AspNetUsers_DepartmentId` (`DepartmentId`);

--
-- Indexes for table `categories`
--
ALTER TABLE `categories`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `comments`
--
ALTER TABLE `comments`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IX_Comments_TopicDueDateId` (`TopicDueDateId`),
  ADD KEY `IX_Comments_TopicId` (`TopicId`),
  ADD KEY `IX_Comments_UserId` (`UserId`);

--
-- Indexes for table `departments`
--
ALTER TABLE `departments`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `qa`
--
ALTER TABLE `qa`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `role`
--
ALTER TABLE `role`
  ADD PRIMARY KEY (`Id`),
  ADD UNIQUE KEY `RoleNameIndex` (`NormalizedName`);

--
-- Indexes for table `roleclaims`
--
ALTER TABLE `roleclaims`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IX_RoleClaims_RoleId` (`RoleId`);

--
-- Indexes for table `staff`
--
ALTER TABLE `staff`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `topicduedates`
--
ALTER TABLE `topicduedates`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `topics`
--
ALTER TABLE `topics`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IX_Topics_CategoryId` (`CategoryId`),
  ADD KEY `IX_Topics_TopicDueDateId` (`TopicDueDateId`),
  ADD KEY `IX_Topics_UserId` (`UserId`);

--
-- Indexes for table `userclaims`
--
ALTER TABLE `userclaims`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IX_UserClaims_UserId` (`UserId`);

--
-- Indexes for table `userlogins`
--
ALTER TABLE `userlogins`
  ADD PRIMARY KEY (`LoginProvider`,`ProviderKey`),
  ADD KEY `IX_UserLogins_UserId` (`UserId`);

--
-- Indexes for table `userroles`
--
ALTER TABLE `userroles`
  ADD PRIMARY KEY (`UserId`,`RoleId`),
  ADD KEY `IX_UserRoles_RoleId` (`RoleId`);

--
-- Indexes for table `usertokens`
--
ALTER TABLE `usertokens`
  ADD PRIMARY KEY (`UserId`,`LoginProvider`,`Name`);

--
-- Indexes for table `__efmigrationshistory`
--
ALTER TABLE `__efmigrationshistory`
  ADD PRIMARY KEY (`MigrationId`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `categories`
--
ALTER TABLE `categories`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- AUTO_INCREMENT for table `comments`
--
ALTER TABLE `comments`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT for table `departments`
--
ALTER TABLE `departments`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT for table `roleclaims`
--
ALTER TABLE `roleclaims`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `topicduedates`
--
ALTER TABLE `topicduedates`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT for table `topics`
--
ALTER TABLE `topics`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=19;

--
-- AUTO_INCREMENT for table `userclaims`
--
ALTER TABLE `userclaims`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `aspnetusers`
--
ALTER TABLE `aspnetusers`
  ADD CONSTRAINT `FK_AspNetUsers_Departments_DepartmentId` FOREIGN KEY (`DepartmentId`) REFERENCES `departments` (`Id`);

--
-- Constraints for table `comments`
--
ALTER TABLE `comments`
  ADD CONSTRAINT `FK_Comments_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`),
  ADD CONSTRAINT `FK_Comments_TopicDueDates_TopicDueDateId` FOREIGN KEY (`TopicDueDateId`) REFERENCES `topicduedates` (`Id`) ON DELETE CASCADE,
  ADD CONSTRAINT `FK_Comments_Topics_TopicId` FOREIGN KEY (`TopicId`) REFERENCES `topics` (`Id`);

--
-- Constraints for table `qa`
--
ALTER TABLE `qa`
  ADD CONSTRAINT `FK_QA_AspNetUsers_Id` FOREIGN KEY (`Id`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE;

--
-- Constraints for table `roleclaims`
--
ALTER TABLE `roleclaims`
  ADD CONSTRAINT `FK_RoleClaims_Role_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `role` (`Id`) ON DELETE CASCADE;

--
-- Constraints for table `staff`
--
ALTER TABLE `staff`
  ADD CONSTRAINT `FK_Staff_AspNetUsers_Id` FOREIGN KEY (`Id`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE;

--
-- Constraints for table `topics`
--
ALTER TABLE `topics`
  ADD CONSTRAINT `FK_Topics_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`),
  ADD CONSTRAINT `FK_Topics_Categories_CategoryId` FOREIGN KEY (`CategoryId`) REFERENCES `categories` (`Id`) ON DELETE CASCADE,
  ADD CONSTRAINT `FK_Topics_TopicDueDates_TopicDueDateId` FOREIGN KEY (`TopicDueDateId`) REFERENCES `topicduedates` (`Id`) ON DELETE CASCADE;

--
-- Constraints for table `userclaims`
--
ALTER TABLE `userclaims`
  ADD CONSTRAINT `FK_UserClaims_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE;

--
-- Constraints for table `userlogins`
--
ALTER TABLE `userlogins`
  ADD CONSTRAINT `FK_UserLogins_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE;

--
-- Constraints for table `userroles`
--
ALTER TABLE `userroles`
  ADD CONSTRAINT `FK_UserRoles_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE,
  ADD CONSTRAINT `FK_UserRoles_Role_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `role` (`Id`) ON DELETE CASCADE;

--
-- Constraints for table `usertokens`
--
ALTER TABLE `usertokens`
  ADD CONSTRAINT `FK_UserTokens_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
