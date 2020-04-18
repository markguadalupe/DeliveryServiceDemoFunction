CREATE TABLE [dbo].[tblDelivery] (
    [ID]          BIGINT   IDENTITY (1, 1) NOT NULL,
    [ConsignorID] BIGINT   NOT NULL,
    [ConsigneeID] BIGINT   NOT NULL,
    [CreatedByID] BIGINT   NOT NULL,
    [CreatedOn]   DATETIME NOT NULL,
    CONSTRAINT [PK_tblDelivery] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_tblCompany_ConsigneeID] FOREIGN KEY ([ConsigneeID]) REFERENCES [dbo].[tblCompany] ([ID]),
    CONSTRAINT [FK_tblCompany_ConsignorID] FOREIGN KEY ([ConsignorID]) REFERENCES [dbo].[tblCompany] ([ID])
);

