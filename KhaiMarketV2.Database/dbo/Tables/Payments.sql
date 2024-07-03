CREATE TABLE [dbo].[Payments] (
    [Id]            INT           IDENTITY (1, 1) NOT NULL,
    [PaymentMethod] VARCHAR (20)  NULL,
    [PaymentDate]   DATETIME      NULL,
    [AspNetUsersId] VARCHAR (256) NULL,
    [Email]         VARCHAR (256) NULL,
    [TotalPayment]  MONEY         NULL,
    [Status]        VARCHAR (20)  NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Payments.AspNetUsersId] FOREIGN KEY ([AspNetUsersId]) REFERENCES [dbo].[AspNetUsers] ([Id])
);


GO

