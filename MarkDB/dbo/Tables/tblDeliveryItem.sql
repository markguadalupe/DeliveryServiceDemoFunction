CREATE TABLE [dbo].[tblDeliveryItem] (
    [ID]              BIGINT         IDENTITY (1, 1) NOT NULL,
    [DeliveryID]      BIGINT         NOT NULL,
    [ItemCount]       DECIMAL (18)   NOT NULL,
    [ItemUnit]        INT            NOT NULL,
    [ItemDescription] NVARCHAR (100) NOT NULL,
    [ItemStatus]      NCHAR (10)     NULL,
    CONSTRAINT [PK_tblDeliveryItem] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_tblDeliveryItem_tblDelivery] FOREIGN KEY ([DeliveryID]) REFERENCES [dbo].[tblDelivery] ([ID])
);

