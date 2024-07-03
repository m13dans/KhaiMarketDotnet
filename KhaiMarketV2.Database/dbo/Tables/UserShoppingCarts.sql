CREATE TABLE [dbo].[UserShoppingCarts] (
    [Id]            INT           IDENTITY (1, 1) NOT NULL,
    [AspNetUsersId] VARCHAR (256) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_UserShoppingCarts_AspNetUsers] FOREIGN KEY ([AspNetUsersId]) REFERENCES [dbo].[AspNetUsers] ([Id])
);


GO

