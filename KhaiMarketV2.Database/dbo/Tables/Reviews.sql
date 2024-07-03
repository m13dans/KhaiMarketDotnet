CREATE TABLE [dbo].[Reviews] (
    [Id]            INT           IDENTITY (1, 1) NOT NULL,
    [Comment]       VARCHAR (500) NULL,
    [NumStars]      INT           NULL,
    [CreatedAt]     DATETIME      NULL,
    [AspNetUsersId] VARCHAR (256) NULL,
    [UserName]      VARCHAR (256) NULL,
    [ProductId]     INT           NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Reviews.AspNetUsersId] FOREIGN KEY ([AspNetUsersId]) REFERENCES [dbo].[AspNetUsers] ([Id])
);


GO

