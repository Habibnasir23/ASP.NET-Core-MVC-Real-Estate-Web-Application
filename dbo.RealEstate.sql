CREATE TABLE [dbo].[RealEstate] (
    [Id]             INT            IDENTITY (1, 1) NOT NULL,
    [propAvailable]  NVARCHAR (MAX) NOT NULL,
    [propSearch]     NVARCHAR (MAX) NOT NULL,
    [rent]           INT            DEFAULT ((0)) NOT NULL,
    [roomsAvailable] INT            DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_RealEstate] PRIMARY KEY CLUSTERED ([Id] ASC)
);
