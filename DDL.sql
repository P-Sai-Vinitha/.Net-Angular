CREATE DATABASE EventDb
go

use EventDb
go

create table UserInfo(
   EmailId varchar(100) primary key,
   UserName varchar(50) NOT NULL CHECK(LEN(UserName) BETWEEN 1 AND 50),
   Role varchar(20) NOT NULL CHECK (Role IN ('Admin','Participant')),
   Password varchar(20) NOT NULL CHECK (LEN(Password) BETWEEN 6 AND 20))

create table EventDetails(
   EventId INT Primary key,
   EventName varchar(50) NOT NULL CHECK (LEN(EventName) BETWEEN 1 AND 50),
   EventCategory varchar(50) NOT NULL CHECK (LEN(EventCategory) BETWEEN 1 AND 50),
   EventDate DATETIME NOT NULL,
   Description VARCHAR(MAX) NULL,
   Status VARCHAR(20) CHECK (Status IN ('Active','In-Active')))

Create table SpeakersDetails(
  SpeakerId INT primary key,
  SpeakerName varchar(50) NOT NULL CHECK (LEN(SpeakerName) BETWEEN 1 AND 50))

CREATE TABLE SessionInfo (
    SessionId INT PRIMARY KEY,
    EventId INT NOT NULL,
    SessionTitle VARCHAR(50) NOT NULL CHECK (LEN(SessionTitle) BETWEEN 1 AND 50),
    SpeakerId INT NOT NULL,
    Description VARCHAR(MAX) NULL,
    SessionStart DATETIME NOT NULL,
    SessionEnd DATETIME NOT NULL,
    SessionUrl VARCHAR(MAX),

    FOREIGN KEY (EventId) REFERENCES EventDetails(EventId),
    FOREIGN KEY (SpeakerId) REFERENCES SpeakersDetails(SpeakerId)
)

CREATE TABLE ParticipantEventDetails (
    Id INT PRIMARY KEY,
    ParticipantEmailId VARCHAR(100) NOT NULL,
    EventId INT NOT NULL,
    SessionId INT NOT NULL,
    IsAttended BIT CHECK (IsAttended IN (0, 1)),

    FOREIGN KEY (ParticipantEmailId) REFERENCES UserInfo(EmailId),
    FOREIGN KEY (EventId) REFERENCES EventDetails(EventId),
    FOREIGN KEY (SessionId) REFERENCES SessionInfo(SessionId)
);
