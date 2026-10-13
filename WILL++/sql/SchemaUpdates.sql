-- SchemaUpdates.sql
-- Adds Website and Address to Companies if missing and creates Opportunities table.

IF NOT EXISTS (SELECT * FROM sys.columns
			   WHERE Name = N'Website'
				 AND Object_ID = Object_ID(N'dbo.Companies'))
BEGIN
	ALTER TABLE dbo.Companies
	ADD Website NVARCHAR(256) NULL;
END

IF NOT EXISTS (SELECT * FROM sys.columns
			   WHERE Name = N'Address'
				 AND Object_ID = Object_ID(N'dbo.Companies'))
BEGIN
	ALTER TABLE dbo.Companies
	ADD Address NVARCHAR(512) NULL;
END

-- Ensure ContactPerson column exists
IF NOT EXISTS (SELECT * FROM sys.columns
			   WHERE Name = N'ContactPerson'
				 AND Object_ID = Object_ID(N'dbo.Companies'))
BEGIN
	ALTER TABLE dbo.Companies
	ADD ContactPerson NVARCHAR(200) NULL;
END

-- Ensure PhoneNumber column exists
IF NOT EXISTS (SELECT * FROM sys.columns
			   WHERE Name = N'PhoneNumber'
				 AND Object_ID = Object_ID(N'dbo.Companies'))
BEGIN
	ALTER TABLE dbo.Companies
	ADD PhoneNumber NVARCHAR(50) NULL;
END

-- Ensure Industry column exists
IF NOT EXISTS (SELECT * FROM sys.columns
			   WHERE Name = N'Industry'
				 AND Object_ID = Object_ID(N'dbo.Companies'))
BEGIN
	ALTER TABLE dbo.Companies
	ADD Industry NVARCHAR(150) NULL;
END

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'dbo.Opportunities') AND type in (N'U'))
BEGIN
	CREATE TABLE dbo.Opportunities
	(
		OpportunityID INT IDENTITY(1,1) PRIMARY KEY,
		UserID INT NOT NULL, -- FK to Users.UserID (company account)
		Title NVARCHAR(200) NOT NULL,
		Description NVARCHAR(MAX) NULL,
		Course NVARCHAR(150) NULL,
		Location NVARCHAR(200) NULL,
		Industry NVARCHAR(150) NULL,
		PostedAt DATETIME NOT NULL DEFAULT(GETDATE()),
		ClosingDate DATETIME NULL,
		IsActive BIT NOT NULL DEFAULT(1)
	);
END

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'dbo.Applications') AND type in (N'U'))
BEGIN
	CREATE TABLE dbo.Applications
	(
		ApplicationID INT IDENTITY(1,1) PRIMARY KEY,
		OpportunityID INT NOT NULL,
		StudentUserID INT NOT NULL,
		AppliedAt DATETIME NOT NULL DEFAULT(GETDATE()),
		Status NVARCHAR(50) NOT NULL DEFAULT('Applied')
	);
END

-- Ensure Companies table exists (UserID is the company account's UserID)
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'dbo.Companies') AND type in (N'U'))
BEGIN
	CREATE TABLE dbo.Companies
	(
		UserID INT PRIMARY KEY,
		CompanyName NVARCHAR(200) NOT NULL,
		ContactPerson NVARCHAR(200) NULL,
		PhoneNumber NVARCHAR(50) NULL,
		Industry NVARCHAR(150) NULL,
		Website NVARCHAR(256) NULL,
		Address NVARCHAR(512) NULL
	);
END

-- Add foreign key from Opportunities.UserID -> Users.UserID
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE name = 'FK_Opportunities_Users')
BEGIN
	ALTER TABLE dbo.Opportunities
	ADD CONSTRAINT FK_Opportunities_Users FOREIGN KEY (UserID) REFERENCES dbo.Users(UserID);
END

-- Add foreign keys for Applications
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE name = 'FK_Applications_Opportunities')
BEGIN
	ALTER TABLE dbo.Applications
	ADD CONSTRAINT FK_Applications_Opportunities FOREIGN KEY (OpportunityID) REFERENCES dbo.Opportunities(OpportunityID);
END

IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE name = 'FK_Applications_Users')
BEGIN
	ALTER TABLE dbo.Applications
	ADD CONSTRAINT FK_Applications_Users FOREIGN KEY (StudentUserID) REFERENCES dbo.Users(UserID);
END

-- Prevent duplicate applications by the same student for the same opportunity
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name = 'UX_Applications_Student_Opportunity')
BEGIN
	CREATE UNIQUE INDEX UX_Applications_Student_Opportunity ON dbo.Applications(StudentUserID, OpportunityID);
END
