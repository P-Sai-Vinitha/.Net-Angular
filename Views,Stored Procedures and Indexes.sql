use EventDb
go

SELECT * FROM UserInfo;
SELECT * FROM SpeakersDetails;
SELECT * FROM SessionInfo;
SELECT * FROM ParticipantEventDetails;

-- 1. Stored Procedures to Insert Data
-- Insert into UserInfo
CREATE PROCEDURE InsertUserInfo
@EmailId VARCHAR(100),
@UserName VARCHAR(50),
@Role VARCHAR(20),
@Password VARCHAR(20)
AS
BEGIN
	INSERT INTO UserInfo(EmailId, UserName, Role, Password)
	VALUES (@EmailId, @UserName, @Role, @Password)
END;

-- Insert into SpeakersDetails
CREATE PROCEDURE InsertSpeakerDetails
@SpeakerId INT,
@SpeakerName VARCHAR(50)
AS
BEGIN
	INSERT INTO SpeakersDetails(SpeakerId, SpeakerName)
	VALUES (@SpeakerId, @SpeakerName)
END;

-- Insert into EventDetails
CREATE PROCEDURE InsertEventDetails
@EventId INT,
@EventName VARCHAR(50),
@EventCategory VARCHAR(50),
@EventDate DATETIME,
@Description VARCHAR(MAX),
@Status VARCHAR(20)
AS
BEGIN
	INSERT INTO EventDetails(EventId, EventName, EventCategory, EventDate, Description, Status)
	VALUES (@EventId, @EventName, @EventCategory, @EventDate, @Description, @Status)
END;

-- Insert into SessionInfo
CREATE PROCEDURE InsertSessionInfo
@SessionId INT,
@EventId INT,
@SessionTitle VARCHAR(50),
@SpeakerId INT,
@Description VARCHAR(MAX),
@SessionStart DATETIME,
@SessionEnd DATETIME,
@SessionUrl VARCHAR(MAX)
AS
BEGIN
	INSERT INTO SessionInfo(SessionId, EventId, SessionTitle, SpeakerId, Description, SessionStart, SessionEnd, SessionUrl)
	VALUES (@SessionId, @EventId, @SessionTitle, @SpeakerId, @Description, @SessionStart, @SessionEnd, @SessionUrl)
END;

-- Insert into ParticipantEventDetails
CREATE PROCEDURE InsertParticipantEventDetails
@Id INT,
@ParticipantEmailId VARCHAR(100),
@EventId INT,
@SessionId INT,
@IsAttended BIT
AS
BEGIN
	INSERT INTO ParticipantEventDetails(Id, ParticipantEmailId, EventId, SessionId, IsAttended)
	VALUES (@Id, @ParticipantEmailId, @EventId, @SessionId, @IsAttended)
END;

EXEC InsertUserInfo
    @EmailId = 'john.doe@example.com',
    @UserName = 'John Doe',
    @Role = 'Participant',
    @Password = 'pass1234';

EXEC InsertSpeakerDetails
    @SpeakerId = 201,
    @SpeakerName = 'Dr. Anjali Mehra';

EXEC InsertEventDetails
    @EventId = 2,
    @EventName = 'Cybersecurity Summit',
    @EventCategory = 'Security',
    @EventDate = '2025-08-15',
    @Description = 'Talks on data protection, cyber laws, and ethical hacking',
    @Status = 'Active';

EXEC InsertSessionInfo
    @SessionId = 2,
    @EventId = 2,
    @SessionTitle = 'Network Defense Techniques',
    @SpeakerId = 201,
    @Description = 'Explore modern tools and strategies to defend networks',
    @SessionStart = '2025-08-15 09:30',
    @SessionEnd = '2025-08-15 10:45',
    @SessionUrl = 'https://eventsummit.com/session2';

EXEC InsertParticipantEventDetails
    @Id = 2,
    @ParticipantEmailId = 'john.doe@example.com',
    @EventId = 2,
    @SessionId = 2,
    @IsAttended = 0;

--2. Stored Procedures to Delete Data
-- Delete User
CREATE PROCEDURE DeleteUserInfo
@EmailId VARCHAR(100)
AS
BEGIN
	DELETE FROM UserInfo WHERE EmailId = @EmailId
END;

-- Delete Speaker
CREATE PROCEDURE DeleteSpeakerDetails
@SpeakerId INT
AS
BEGIN
	DELETE FROM SpeakersDetails WHERE SpeakerId = @SpeakerId
END;

-- Delete Event
CREATE PROCEDURE DeleteEventDetails
@EventId INT
AS
BEGIN
	DELETE FROM EventDetails WHERE EventId = @EventId
END;

-- Delete Session
CREATE PROCEDURE DeleteSessionInfo
@SessionId INT
AS
BEGIN
	DELETE FROM SessionInfo WHERE SessionId = @SessionId
END;

-- Delete Participant
CREATE PROCEDURE DeleteParticipantEventDetails
@Id INT
AS
BEGIN
	DELETE FROM ParticipantEventDetails WHERE Id = @Id
END;

EXEC DeleteEventDetails @EventId = 2;
EXEC DeleteSessionInfo @SessionId = 2;
EXEC DeleteParticipantEventDetails @Id = 2;
EXEC DeleteUserInfo @EmailId = 'john.doe@example.com';
EXEC DeleteSpeakerDetails @SpeakerId = 201;

-- 3. Stored Procedures to Update Data
-- Update UserInfo
CREATE PROCEDURE UpdateUserInfo
@EmailId VARCHAR(100),
@UserName VARCHAR(50),
@Role VARCHAR(20),
@Password VARCHAR(20)
AS
BEGIN
	UPDATE UserInfo
	SET UserName = @UserName, Role = @Role, Password = @Password
	WHERE EmailId = @EmailId
END;

-- Update SpeakerDetails
CREATE PROCEDURE UpdateSpeakerDetails
@SpeakerId INT,
@SpeakerName VARCHAR(50)
AS
BEGIN
	UPDATE SpeakersDetails
	SET SpeakerName = @SpeakerName
	WHERE SpeakerId = @SpeakerId
END;

-- Update EventDetails
CREATE PROCEDURE UpdateEventDetails
@EventId INT,
@EventName VARCHAR(50),
@EventCategory VARCHAR(50),
@EventDate DATETIME,
@Description VARCHAR(MAX),
@Status VARCHAR(20)
AS
BEGIN
	UPDATE EventDetails
	SET EventName = @EventName, EventCategory = @EventCategory, EventDate = @EventDate,
		Description = @Description, Status = @Status
	WHERE EventId = @EventId
END;

-- Update SessionInfo
CREATE PROCEDURE UpdateSessionInfo
@SessionId INT,
@EventId INT,
@SessionTitle VARCHAR(50),
@SpeakerId INT,
@Description VARCHAR(MAX),
@SessionStart DATETIME,
@SessionEnd DATETIME,
@SessionUrl VARCHAR(MAX)
AS
BEGIN
	UPDATE SessionInfo
	SET EventId = @EventId, SessionTitle = @SessionTitle, SpeakerId = @SpeakerId,
		Description = @Description, SessionStart = @SessionStart,
		SessionEnd = @SessionEnd, SessionUrl = @SessionUrl
	WHERE SessionId = @SessionId
END;

-- Update ParticipantEventDetails
CREATE PROCEDURE UpdateParticipantEventDetails
@Id INT,
@ParticipantEmailId VARCHAR(100),
@EventId INT,
@SessionId INT,
@IsAttended BIT
AS
BEGIN
	UPDATE ParticipantEventDetails
	SET ParticipantEmailId = @ParticipantEmailId, EventId = @EventId,
		SessionId = @SessionId, IsAttended = @IsAttended
	WHERE Id = @Id
END;

--4. View: Session Details of Particular Event
CREATE VIEW View_SessionDetailsByEvent AS
SELECT
	SI.SessionId,
	SI.EventId,
	ED.EventName,
	SI.SessionTitle,
	SI.SpeakerId,
	SP.SpeakerName,
	SI.Description,
	SI.SessionStart,
	SI.SessionEnd,
	SI.SessionUrl
FROM SessionInfo SI
JOIN EventDetails ED ON SI.EventId = ED.EventId
JOIN SpeakersDetails SP ON SI.SpeakerId = SP.SpeakerId;

-- 5. View: Speaker Details of Particular Session
CREATE VIEW View_SpeakerDetailsBySession AS
SELECT
	SI.SessionId,
	SI.SessionTitle,
	SI.EventId,
	ED.EventName,
	SP.SpeakerId,
	SP.SpeakerName
FROM SessionInfo SI
JOIN SpeakersDetails SP ON SI.SpeakerId = SP.SpeakerId
JOIN EventDetails ED ON SI.EventId = ED.EventId;

-- 6. View: All Event Details (Sessions, Speakers, Participants)
CREATE VIEW View_EventFullDetails AS
SELECT
	ED.EventId,
	ED.EventName,
	ED.EventCategory,
	ED.EventDate,
	ED.Description AS EventDescription,
	ED.Status AS EventStatus,

	SI.SessionId,
	SI.SessionTitle,
	SI.Description AS SessionDescription,
	SI.SessionStart,
	SI.SessionEnd,
	SI.SessionUrl,

	SP.SpeakerId,
	SP.SpeakerName,

	PED.Id AS ParticipantId,
	PED.ParticipantEmailId,
	PED.IsAttended

FROM EventDetails ED
LEFT JOIN SessionInfo SI ON ED.EventId = SI.EventId
LEFT JOIN SpeakersDetails SP ON SI.SpeakerId = SP.SpeakerId
LEFT JOIN ParticipantEventDetails PED ON SI.SessionId = PED.SessionId;

--7. Apply Non-Clustered Indexes
-- UserInfo Table
CREATE NONCLUSTERED INDEX IDX_User_EmailId ON UserInfo(EmailId);
CREATE NONCLUSTERED INDEX IDX_User_Role ON UserInfo(Role);

-- EventDetails Table
CREATE NONCLUSTERED INDEX IDX_Event_EventCategory ON EventDetails(EventCategory);
CREATE NONCLUSTERED INDEX IDX_Event_Status ON EventDetails(Status);
CREATE NONCLUSTERED INDEX IDX_Event_EventDate ON EventDetails(EventDate);

-- SpeakersDetails Table
CREATE NONCLUSTERED INDEX IDX_Speaker_Name ON SpeakersDetails(SpeakerName);

-- SessionInfo Table
CREATE NONCLUSTERED INDEX IDX_Session_Title ON SessionInfo(SessionTitle);
CREATE NONCLUSTERED INDEX IDX_Session_StartTime ON SessionInfo(SessionStart);

-- ParticipantEventDetails Table
CREATE NONCLUSTERED INDEX IDX_Participant_EmailId ON ParticipantEventDetails(ParticipantEmailId);
CREATE NONCLUSTERED INDEX IDX_Participant_Attendance ON ParticipantEventDetails(IsAttended);








--