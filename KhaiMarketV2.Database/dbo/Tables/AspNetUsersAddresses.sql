CREATE TABLE [dbo].[AspNetUsersAddresses]
(
  [Id] INT NOT NULL PRIMARY KEY,
  AspNetUserId VARCHAR(256),
  AddressId int,
  CONSTRAINT FK_AspNetUsersAddress_AspNetUserId foreign key (aspnetuserid) references AspNetUsers (id),
  CONSTRAINT FK_AspNetUsersAddress_AdressId foreign key (AddressId) references [Addresses] (id)
)
