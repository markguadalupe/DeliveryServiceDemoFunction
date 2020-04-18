CREATE TABLE [dbo].[tblDeliveryStatus] (
    [ID]             BIGINT         IDENTITY (1, 1) NOT NULL,
    [DeliveryID]     BIGINT         NOT NULL,
    [DeliveryStatus] INT            NOT NULL,
    [Location]       NVARCHAR (100) NOT NULL,
    [CreatedByID]    BIGINT         NOT NULL,
    [CreatedOn]      DATETIME       NOT NULL,
    CONSTRAINT [PK_tblDeliveryStatus] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_tblDeliveryStatus_tblDeliveryID] FOREIGN KEY ([DeliveryID]) REFERENCES [dbo].[tblDelivery] ([ID])
);

