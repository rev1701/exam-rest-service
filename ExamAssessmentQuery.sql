use [ExamAssessment]
go
Create Table[ExamType](
[PKID] int IDENTITY(1,1) NOT NULL,
[ExamTypeName] varchar(100),
CONSTRAINT PK_ExamType Primary Key Clustered (PKID)
)

Create Table[ExamTemplate](
[PKID] int IDENTITY(1,1) NOT NULL,
[ExamTemplateName] varchar(45),
[CreatedDate] Datetime,
[ExamTemplateID] varchar(100),
[ExamTypeID] int,
CONSTRAINT PK_ExamTemplate Primary Key Clustered (PKID),
CONSTRAINT FK_ExamTypeID Foreign Key (ExamTypeID) REFERENCES [ExamType](PKID)
    ON DELETE CASCADE    
    ON UPDATE CASCADE ,
CONSTRAINT UQ_ExamTemplateID Unique(ExamTemplateID)
)

Create Table[QuestionType](
[PKID] int IDENTITY(1,1) NOT NULL,
[QuestionTypeName] varchar(100),
CONSTRAINT PK_QuestionType Primary Key Clustered (PKID)
)
Create Table[ExamTemplateQuestions](
[ExamTemplateID] varchar(100),
[ExamQuestionID] varchar(100),
QuestionWeight int,
CONSTRAINT PK_ExamTemplateQuestions Primary Key Clustered ([ExamTemplateID], [ExamQuestionID]),
CONSTRAINT FK_ExamTemplateID Foreign Key ([ExamTemplateID]) REFERENCES [ExamTemplate]([ExamTemplateID]),   
CONSTRAINT FK_ExamQuestionID Foreign Key ([ExamQuestionID]) REFERENCES [ExamQuestion]([ExamQuestionID])
    ON DELETE CASCADE    
    ON UPDATE CASCADE 
)

Create Table[ExamQuestion](
[PKID] int IDENTITY(1,1) NOT NULL,
[ExamQuestionName] varchar(45),
[QuestionTypeID] int,
[ExamQuestionID] varchar(100),
CONSTRAINT PK_ExamQuestionID Primary Key Clustered (PKID),
CONSTRAINT FK_QuesitonTypeID Foreign Key (QuestionTypeID) REFERENCES [QuestionType](PKID)
    ON DELETE CASCADE    
    ON UPDATE CASCADE ,
CONSTRAINT UQ_ExamQuestionID Unique(ExamQuestionID)
)

Create Table[Answer](
[PKID] int IDENTITY(1,1) NOT NULL,
[Answer] varchar(max),
CONSTRAINT PK_ANswerID Primary Key Clustered (PKID)
)
Alter Table [Answer]
	Add AddLanguageTypeID int NOt Null
Create Table[QuestionAnswers](
[QuestionID] int,
[AnswerID] int,
[IsCorrect] bit not null default(0)
CONSTRAINT PK_QuestionAnswers Primary Key Clustered ([QuestionID], [AnswerID]),
CONSTRAINT FK_QuestionID Foreign Key ([QuestionID]) REFERENCES [Question](PKID),   
CONSTRAINT FK_AnswerID Foreign Key ([AnswerID]) REFERENCES [Answer](PKID)
    ON DELETE CASCADE    
    ON UPDATE CASCADE 
)

Create Table[ExamQuestionList](
[ExamQuestionID] varchar(100),
[QuestionID] int,
CONSTRAINT PK_ExamQuestionList Primary Key Clustered ([ExamQuestionID], [QuestionID]),
CONSTRAINT FK_ExamQuestionListQuestionID Foreign Key ([QuestionID]) REFERENCES [Question](PKID),   
CONSTRAINT FK_ExamQuestionListExamQuestionID Foreign Key ([ExamQuestionId]) REFERENCES [ExamQuestion]([ExamQuestionID])
    ON DELETE CASCADE    
    ON UPDATE CASCADE 
)


Create Table[Question](
[PKID] int IDENTITY(1,1) NOT NULL,
[Description] varchar(max),
CONSTRAINT PK_QUestionID Primary Key Clustered (PKID)
)

Create Table[LanguageType] (
[PKID] int IDENTITY(1,1) NOT NULL,
[LanguageName] varchar(100)
CONSTRAINT PK_LanguageType Primary Key Clustered (PKID)

Select * From Categories_Subtopic
Select * From QuestionAnswers
Select * From ExamTemplate
Select * From ExamType

Delete From ExamTemplate where PKID=23
select * From QuestionType
Select * From ExamQuestionList
Select * From ExamQuestion
Select * From Question

Select * From ExamTemplateQuestions
Select * From Answer
Select * From Subject
Select * From Subject_Categories
Delete From ExamType where PKID=5
Insert into ExamType (ExamTypeName) Values ('Market')