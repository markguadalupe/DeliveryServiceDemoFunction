CREATE TABLE [dbo].[tblEmployee] (
    [ID]        BIGINT         IDENTITY (1, 1) NOT NULL,
    [CompanyID] BIGINT         NOT NULL,
    [Name]      NVARCHAR (100) NOT NULL,
    CONSTRAINT [PK_tblEmployee] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_tblEmployee_tblCompany] FOREIGN KEY ([CompanyID]) REFERENCES [dbo].[tblCompany] ([ID])
);

