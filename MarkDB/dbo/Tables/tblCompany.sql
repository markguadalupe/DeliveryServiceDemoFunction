CREATE TABLE [dbo].[tblCompany] (
    [ID]        BIGINT         IDENTITY (1, 1) NOT NULL,
    [Name]      NVARCHAR (100) NOT NULL,
    [CreatedOn] DATETIME       NOT NULL,
    CONSTRAINT [PK_tblCompany] PRIMARY KEY CLUSTERED ([ID] ASC)
);



