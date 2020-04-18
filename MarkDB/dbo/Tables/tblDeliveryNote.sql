CREATE TABLE [dbo].[tblDeliveryNote] (
    [ID]          BIGINT         IDENTITY (1, 1) NOT NULL,
    [DeliveryID]  BIGINT         NOT NULL,
    [Notes]       NVARCHAR (MAX) NOT NULL,
    [CreatedByID] BIGINT         NOT NULL,
    [CreatedOn]   DATETIME       NOT NULL,
    CONSTRAINT [PK_tblDeliveryNote] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_tblDeliveryNote_tblDelivery_DeliveryID] FOREIGN KEY ([DeliveryID]) REFERENCES [dbo].[tblDelivery] ([ID])
);

